using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace PBA
{
    public partial class frmLogin : System.Web.UI.Page
    {
        string sqlconn = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                SqlConnection con = new SqlConnection(sqlconn);
                con.Open();
                string sqlstr = "select Role,UserName from tbl_Customer where UserName='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                string role = Convert.ToString(cmd.ExecuteScalar());
                if (role != "")
                {
                    Session["Role"] = role;
                    string homepage = @"~\Home.aspx";
                    Response.Redirect(homepage);
                }
                else
                    Response.Write("Incorrect Username or Password");
            }
            else
                Response.Write("Plz enter correct username and password");
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string signuppage = @"~\SignUp.aspx";
            Response.Redirect(signuppage);
        }
    }
}