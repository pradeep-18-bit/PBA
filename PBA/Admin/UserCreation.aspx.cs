using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace PBA.Admin
{
    public partial class UserCreation : System.Web.UI.Page
    {
        string cs = WebConfigurationManager
                    .ConnectionStrings["conn"]
                    .ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillRoles();
                FillGrid();
            }
        }

        // ================== LOAD GRID ==================
        void FillGrid()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = @"SELECT User_Id, UserName, Email, Role
                             FROM tbl_Customer
                             ORDER BY User_Id";

                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GvUserDetails.DataSource = dt;
                GvUserDetails.DataBind();
            }
        }

        // ================== LOAD ROLES ==================
        void FillRoles()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "SELECT RoleId, RoleName FROM tbl_Roles";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlRole.DataSource = dt;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleId";
                ddlRole.DataBind();

                ddlRole.Items.Insert(0, "--Select--");
            }
        }

        // ================== NEW ==================
        protected void btnNew_click(object sender, EventArgs e)
        {
            Clear();
        }

        // ================== SAVE ==================
        protected void btnSave_click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = @"INSERT INTO tbl_Customer
                            (UserName, Password, CPassword, PhoneNumber, Email, Role)
                            VALUES
                            (@UserName, @Password, @CPassword, @Phone, @Email, @Role)";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@CPassword", txtCpassword.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Clear();
            FillGrid();
        }

        // ================== UPDATE ==================
        protected void btnUpdate_click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvUserDetails.SelectedDataKey.Value);

            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = @"UPDATE tbl_Customer SET
                             UserName=@UserName,
                             Password=@Password,
                             CPassword=@CPassword,
                             PhoneNumber=@Phone,
                             Email=@Email,
                             Role=@Role
                             WHERE User_Id=@Id";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@CPassword", txtCpassword.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Clear();
            FillGrid();
        }

        // ================== DELETE ==================
        protected void btnDelete_click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvUserDetails.SelectedDataKey.Value);

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("DELETE FROM tbl_Customer WHERE User_Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Clear();
            FillGrid();
        }

        // ================== GRID SELECT ==================
        protected void GvUserDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserName.Text = GvUserDetails.SelectedRow.Cells[2].Text;
            txtEmail.Text = GvUserDetails.SelectedRow.Cells[3].Text;
            ddlRole.SelectedValue = GvUserDetails.SelectedRow.Cells[4].Text;
        }

        // ================== CLEAR ==================
        void Clear()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtCpassword.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            ddlRole.SelectedIndex = 0;
        }
    }
}
