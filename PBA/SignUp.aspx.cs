using System;
using System.Configuration;
using System.Data.SqlClient;

namespace PBA
{
    public partial class SignUp1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtCpassword.Text)
            {
                Response.Write("<script>alert('Passwords do not match');</script>");
                return;
            }

            if (ddlRole.SelectedValue == "0")
            {
                Response.Write("<script>alert('Please select a role');</script>");
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string query = @"
                        INSERT INTO tbl_Customer
                        (UserName, Password, CPassword, PhoneNumber, Email, Role)
                        VALUES
                        (@UserName, @Password, @CPassword, @PhoneNumber, @Email, @Role)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@CPassword", txtCpassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt64(txtPhoneNumber.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", Convert.ToInt32(ddlRole.SelectedValue));

                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('User registered successfully');</script>");
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.Replace("'", "") + "');</script>");
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }

        private void ClearForm()
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
