using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace PBA.Admin
{
    public partial class UserPermission : System.Web.UI.Page
    {
        // ✅ Consistent connection string variable
        private readonly string cs = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillRoles();
            }
        }

        // ================= LOAD ROLES =================
        protected void fillRoles()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "SELECT RoleId, RoleName FROM tbl_Roles ORDER BY RoleId";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlRole.DataSource = dt;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleId";
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        // ================= LOAD USERS BY ROLE =================
        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlUsers.Items.Clear();

            if (ddlRole.SelectedIndex > 0)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = @"SELECT User_Id, UserName 
                                   FROM tbl_Customer 
                                   WHERE Role = @Role";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ddlUsers.DataSource = dt;
                    ddlUsers.DataTextField = "UserName";
                    ddlUsers.DataValueField = "User_Id";
                    ddlUsers.DataBind();
                    ddlUsers.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
        }

        // ================= LOAD USER PERMISSIONS =================
        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsers.SelectedIndex > 0)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = @"SELECT 
                                    User_Id,
                                    RoleName,
                                    UserName,
                                    ScreenName,
                                    IsCreate,
                                    IsUpdate,
                                    IsDelete,
                                    IsView
                                   FROM tbl_UserPermission1
                                   WHERE User_Id = @User_Id";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@User_Id", ddlUsers.SelectedValue);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    Gvuserpermission.DataSource = dt;
                    Gvuserpermission.DataBind();
                }
            }
            else
            {
                Gvuserpermission.DataSource = null;
                Gvuserpermission.DataBind();
            }
        }
    }
}