using System;
using System.Configuration;
using System.Data.SqlClient;

namespace PBA
{
    public partial class SignUp1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    // ✅ Generate new User_Id
                    int newUserId = 1;
                    SqlCommand getIdCmd = new SqlCommand(
                        "SELECT ISNULL(MAX(User_Id),0) + 1 FROM tbl_Customer", con);

                    newUserId = Convert.ToInt32(getIdCmd.ExecuteScalar());

                    // ✅ INSERT QUERY (User_Id INCLUDED)
                    string query = @"INSERT INTO tbl_Customer
                        (User_Id, UserName, Password, CPassword, PhoneNumber, Email, Role)
                        VALUES
                        (@User_Id, @UserName, @Password, @CPassword, @PhoneNumber, @Email, @Role)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@User_Id", newUserId);
                    cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@CPassword", txtCpassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Response.Write("<script>alert('User registered successfully');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Insertion failed');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.Replace("'", "") + "');</script>");
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmLogin.aspx");
        }

        protected void btnNew_Click(object sender, EventArgs e)
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
