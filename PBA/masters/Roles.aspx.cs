using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PBA.masters
{
    public partial class Roles : System.Web.UI.Page
    {
        // ✅ Consistent connection string variable
        private readonly string cs = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillRole();
            }
        }

        // ================= CLEAR CONTROLS =================
        protected void ClearControls()
        {
            txtRoleId.Text = string.Empty;
            txtRoleName.Text = string.Empty;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        // ================= SAVE =================
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = "INSERT INTO tbl_Roles (RoleId, RoleName) VALUES (@RoleId, @RoleName)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@RoleId", txtRoleId.Text);
                cmd.Parameters.AddWithValue("@RoleName", txtRoleName.Text);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Write("Record inserted successfully");
                    FillRole();
                }
            }
        }

        // ================= UPDATE =================
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = "UPDATE tbl_Roles SET RoleName = @RoleName WHERE RoleId = @RoleId";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@RoleId", txtRoleId.Text);
                cmd.Parameters.AddWithValue("@RoleName", txtRoleName.Text);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Write("Record updated successfully");
                    FillRole();
                }
                else
                {
                    Response.Write("Error occurred while updating");
                }
            }
        }

        // ================= DELETE =================
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = "DELETE FROM tbl_Roles WHERE RoleId = @RoleId";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@RoleId", txtRoleId.Text);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Write("Deletion successful");
                    FillRole();
                }
                else
                {
                    Response.Write("Deletion failed");
                }
            }
        }

        // ================= SEARCH BY ROLE ID OR NAME =================
        protected void txtRoleId_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = "SELECT RoleId, RoleName FROM tbl_Roles WHERE RoleId = @RoleId OR RoleName = @RoleName";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@RoleId", txtRoleId.Text);
                cmd.Parameters.AddWithValue("@RoleName", txtRoleName.Text);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        txtRoleId.Text = rdr["RoleId"].ToString();
                        txtRoleName.Text = rdr["RoleName"].ToString();
                    }
                }
                else
                {
                    Response.Write("Record not found");
                }
            }
        }

        // ================= LOAD ROLES =================
        protected void FillRole()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = "SELECT RoleId, RoleName FROM tbl_Roles ORDER BY RoleId";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Gvtbl_RoleDetails.DataSource = dt;
                    Gvtbl_RoleDetails.DataBind();
                }
            }
        }

        // ================= CLOSE =================
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        // ================= GRID SELECTION =================
        protected void Gvtbl_RoleDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoleId.Text = Gvtbl_RoleDetails.SelectedRow.Cells[1].Text;
            txtRoleName.Text = Gvtbl_RoleDetails.SelectedRow.Cells[2].Text;
        }
    }
}