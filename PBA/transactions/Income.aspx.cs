using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
namespace PBA
{
    public partial class Income : System.Web.UI.Page
    {
        string sqlconn = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //lblMessage.Text = "First request"
            if (!IsPostBack)
            {
                //if (Session["user"] != null)
                //{

                //}
                //fillRole();
                fillgrid();
                fillCategory();

            }
        }
        protected void fillCategory()
        {
            SqlConnection con = new SqlConnection(sqlconn);
            con.Open();
            string sqlstr = "Select Category_Id,Category_Type from BudgetCategories order by Category_Id";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlCategory.DataSource = dt;

                ddlCategory.DataTextField = "Category_Type";
                ddlCategory.DataValueField = "Category_Id";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "--Select--");

            }
        }
        protected void fillgrid()
        {
            SqlConnection con = new SqlConnection(sqlconn);
            con.Open();
            string sqlstr = "select Income_Id,User_Id,Income_Source,Category,Amount,Description,Income_Date from  Income order by Income_Id ";
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
        protected void clearControls()
        {
            txtIncome_Id.Text = string.Empty;
            txtUser_Id.Text = string.Empty;
            txtIncome_Source.Text = string.Empty;
            ddlCategory.SelectedIndex = -1;
            txtAmount.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtIncome_Date.Text = string.Empty;




        }

        protected void btnNew_click(object sender, EventArgs e)
        {
            clearControls();

        }

        protected void btnSave_click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=PBA;Persist Security Info=True;User ID=sa;Password=123456");
            con.Open();

            string sqlstr = "Insert into  Income(Income_Id,User_Id,Income_Source,Category,Amount,Description,Income_Date ) values('" + txtIncome_Id.Text + "','" + txtUser_Id.Text + "','" + txtIncome_Source.Text + "','" + ddlCategory.SelectedValue + "','" + txtAmount.Text + "','" + txtDescription.Text + "','" + txtIncome_Date.Text + "')";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("inserted successfully");
                fillgrid();
            }
            con.Close();

        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=PBA;Persist Security Info=True;User ID=sa;Password=123456");
            {
                con.Open();
                string sqlstr = "UPDATE Income set User_Id='" + txtUser_Id.Text + "',Income_Source='" + txtIncome_Source.Text + "',Category='" + ddlCategory.SelectedValue + "',Amount='" + txtAmount.Text + "',Description='" + txtDescription.Text + "',Income_Date='" + txtIncome_Date.Text + "' from Income where  Income_Id='" + txtIncome_Id.Text + "'";
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
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=PBA;Persist Security Info=True;User ID=sa;Password=123456");
            {
                con.Open();
                string sqlstr = "DELETE FROM Income where Income_Id ='" + txtIncome_Id.Text + "' ";
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

        protected void GvUserDetails_SelectedIndexChanged1(object sender, EventArgs e)
        {
            txtIncome_Id.Text = GvUserDetails.SelectedRow.Cells[1].Text;
            txtUser_Id.Text = GvUserDetails.SelectedRow.Cells[2].Text;
            txtIncome_Source.Text = GvUserDetails.SelectedRow.Cells[3].Text;
            ddlCategory.SelectedValue = GvUserDetails.SelectedRow.Cells[4].Text;
            txtAmount.Text = GvUserDetails.SelectedRow.Cells[5].Text;
            txtDescription.Text = GvUserDetails.SelectedRow.Cells[6].Text;
            txtIncome_Date.Text = GvUserDetails.SelectedRow.Cells[7].Text;


        }

        protected void txtUser_Id_TextChanged(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection(sqlconn);
            con.Open();
            string sqlstr = "select User_Id,UserName,PhoneNumber,Email from tbl_Customer where User_Id='" + txtUser_Id.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {

                    txtUser_Id.Text = rdr["User_Id"].ToString();
                    txtUserName.Text = rdr["UserName"].ToString();
                  
                    txtPhoneNumber.Text = rdr["PhoneNumber"].ToString();
                    txtEmail.Text = rdr["Email"].ToString();
                   
                }
            }
            else
            {
                Response.Write("Record Not Found");
            }
        }
        private DataTable GetUserDetails(string userId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                string query = "SELECT UserName, Email FROM tbl_Customer WHERE User_Id = User_Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@User_Id", User_Id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }


        public object User_Id { get; set; }
    }
        }


    
