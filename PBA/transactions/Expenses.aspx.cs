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
    public partial class Expenses : System.Web.UI.Page
    {
        string sqlconn = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblMessage.Text = "First request";
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
                ddlCategory_Type.DataSource = dt;

                ddlCategory_Type.DataTextField = "Category_Type";
                ddlCategory_Type.DataValueField = "Category_Id";
                ddlCategory_Type.DataBind();
                ddlCategory_Type.Items.Insert(0, "--Select--");

            }
        }
        protected void fillgrid()
        {
            SqlConnection con = new SqlConnection(sqlconn);
            con.Open();
            string sqlstr = "select Expense_Id,User_Id,Category,Amount,Date_Spent from  Expenses order by Expense_Id ";
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
            txtExpense_Id.Text = string.Empty;
            txtUser_Id.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlCategory_Type.SelectedIndex = -1;
            txtAmount.Text = string.Empty;
            txtDate_Spent.Text = string.Empty;

        }


        

        protected void btnNew_click(object sender, EventArgs e)
        {

            clearControls();

        }

        protected void btnSave_click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconn);
            con.Open();
            string sqlstr = "Insert into Expenses (Expense_Id,User_Id,Category,Amount,Date_Spent) values('" + txtExpense_Id.Text + "','" + txtUser_Id.Text + "','" + ddlCategory_Type.SelectedValue + "','" + txtAmount.Text + "','" + txtDate_Spent.Text + "')";
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
            SqlConnection con = new SqlConnection(sqlconn);
            {
                con.Open();
                string sqlstr = "UPDATE Expenses set User_Id='" + txtUser_Id.Text + "',Category='" + ddlCategory_Type.SelectedValue + "',Amount='" + txtAmount.Text + "',Date_Spent='" + txtDate_Spent.Text + "' from Expenses where Expense_Id='" + txtExpense_Id.Text + "' ";
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
                string sqlstr = "DELETE FROM Expenses where Expense_Id='" + txtExpense_Id.Text + "'";
                using (SqlCommand cmd = new SqlCommand(sqlstr, con))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Response.Write("Deletion Successful");
                        fillgrid();
                        clearControls();
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
            txtExpense_Id.Text = GvUserDetails.SelectedRow.Cells[1].Text;
            txtUser_Id.Text = GvUserDetails.SelectedRow.Cells[2].Text;
            ddlCategory_Type.SelectedItem.Text = GvUserDetails.SelectedRow.Cells[3].Text;
            txtAmount.Text = GvUserDetails.SelectedRow.Cells[4].Text;
            txtDate_Spent.Text = GvUserDetails.SelectedRow.Cells[5].Text;

        }

        protected void txtUser_Id_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconn);
            con.Open();
            string sqlstr = "select User_Id,UserName,Password,CPassword,PhoneNumber,Email,Role from tbl_Customer where User_Id='" + txtUser_Id.Text + "' ";
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