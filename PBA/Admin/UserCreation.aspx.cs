using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;


namespace PBA.Admin
{
    public partial class UserCreation : System.Web.UI.Page
    {
        string sqlconn = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
               // if (Session["User"] != null)
                {
                    fillgrid();

                }
                fillRole();
            }
        }
        protected void fillgrid()
        {
            SqlConnection con = new SqlConnection(sqlconn);
            con.Open();
            string sqlstr = "select  Id,UserName,Password,CPassword,PhoneNumber,Email,Role from tbl_Customer order by Id ";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvUserDetails.DataSource = dt;
                GvUserDetails.DataBind();

            }
            else
                Response.Write("Records Not found");
        }
        protected void fillRole()
        {
            SqlConnection con = new SqlConnection(sqlconn);
            con.Open();
            string sqlstr = "Select RoleId,RoleName from tbl_Roles order by RoleId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlRole.DataSource = dt;

                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleId";
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, "--Select--");

            }
        }
        protected void clearControls()
        {
            txtUser_Id.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtCpassword.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlRole.SelectedIndex = -1;

        }

        protected void btnNew_click(object sender, EventArgs e)
        {
            clearControls();

        }

        protected void btnSave_click(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection(sqlconn);
            con.Open();
            string sqlstr = "insert into tbl_Customer(User_Id, UserName,Password,CPassword,PhoneNumber,Email,Role)Values('"+ txtUser_Id.Text + "','" + txtUserName.Text + "','" + txtPassword.Text + "','" + txtCpassword.Text + "'," + txtPhoneNumber.Text + ",'" + txtEmail.Text + "','" + ddlRole.SelectedValue + "')";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("Record Insterted Successfully");
                fillgrid();
            }
            else
            {
                Response.Write("Insertion failed");
            }
            con.Close();

        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection(sqlconn);
            {
                con.Open();
                string sqlstr = "UPDATE tbl_Customer SET UserName='" +txtUserName.Text +"', Password = '" + txtPassword.Text + "', CPassword = '" + txtCpassword.Text + "', PhoneNumber = '" + txtPhoneNumber.Text + "', Email = '" + txtEmail.Text + "', Role = '" + ddlRole.SelectedValue + "'from tbl_Customer WHERE User_Id = '" + txtUser_Id.Text + "'";
                using (SqlCommand cmd = new SqlCommand(sqlstr, con))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Response.Write("Record Updated Successfully");
                        fillgrid();
                    }
                    else
                    {
                        Response.Write("Error Occurred while Updating");
                    }
                }
            }

        }

        protected void btnDelete_click(object sender, EventArgs e)
        {
              SqlConnection con = new SqlConnection(sqlconn);
            {
                con.Open();
                string sqlstr = "DELETE FROM tbl_Customer WHERE User_Id = '" + txtUser_Id.Text + "'";
                using (SqlCommand cmd = new SqlCommand(sqlstr, con))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Response.Write("Deletion Successful");
                        fillgrid();
                    }
                    else
                    {
                        Response.Write("Deletion Failed");
                    }
                }
            }

        }

        protected void btnClose_click(object sender, EventArgs e)
        {
             string homepage = @"~\Home.aspx";
            Response.Redirect(homepage);

        }

        

        protected void GvUserDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserName.Text = GvUserDetails.SelectedRow.Cells[2].Text;
            txtPassword.Text = GvUserDetails.SelectedRow.Cells[3].Text;
            txtPhoneNumber.Text = GvUserDetails.SelectedRow.Cells[5].Text;
            txtEmail.Text = GvUserDetails.SelectedRow.Cells[6].Text;
            //ddlRole.SelectedValue = GvUserDetails.SelectedRow.Cells[7].Text;
        }

        protected void txtUser_Id_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconn);
            con.Open();
            string sqlstr = "select UserName,Password,CPassword,PhoneNumber,Email,Role from tbl_Customer where User_Id='" + txtUser_Id.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {

                    txtUser_Id.Text = rdr["User_Id"].ToString();
                    txtUserName.Text = rdr["UserName"].ToString();
                    txtPassword.Text = rdr["Password"].ToString();
                    txtCpassword.Text = rdr["CPassword"].ToString();
                    txtPhoneNumber.Text = rdr["PhoneNumber"].ToString();
                    txtEmail.Text = rdr["Email"].ToString();
                    ddlRole.SelectedValue = rdr["Role"].ToString();
                }
            }
            else
            {
                Response.Write("Record Not Found");
            }
        }
    }
}