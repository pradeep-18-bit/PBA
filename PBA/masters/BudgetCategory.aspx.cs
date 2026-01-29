using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace PBA.masters
{
    public partial class BudgetCategory : System.Web.UI.Page
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
                fillCategory_Type();
                fillgrid();

            }
        }
        protected void fillCategory_Type()
        {
            SqlConnection con = new SqlConnection(sqlconn);
            con.Open();
            string sqlstr = "select Category_Id,Category_Type from BudgetCategories order by Category_Id ";
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
            string sqlstr = "select Category_Id,Category_Name,Category_Type from  BudgetCategories order by Category_Id ";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvBudgetCategory.DataSource = dt;
                GvBudgetCategory.DataBind();

            }
            else
                Response.Write("Records Not found");
        }
        protected void clearControls()
        {
            txtCategory_Id.Text = string.Empty;
            txtCategory_Name.Text = string.Empty;
            ddlCategory_Type.SelectedIndex = -1;
            
        }

        protected void btnNew_click(object sender, EventArgs e)
        {
            clearControls();
        }

        protected void btnSave_click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=PBA;Persist Security Info=True;User ID=sa;Password=123456");
            con.Open();
            string sqlstr = "Insert into BudgetCategories (Category_Id,Category_Name,Category_Type) values('" + txtCategory_Id.Text + "','" + txtCategory_Name.Text + "','" + ddlCategory_Type.SelectedValue + "')";
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
                string sqlstr = "UPDATE BudgetCategories set Category_Id = '" + txtCategory_Id.Text + "',Category_Name='" + txtCategory_Name.Text + "',Category_Type='" + ddlCategory_Type.SelectedValue + "' from BudgetCategories where Category_Id = '" + txtCategory_Id.Text + "'";
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
                string sqlstr = "DELETE FROM BudgetCategories where Category_Id='" + txtCategory_Id.Text + "'";
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
            txtCategory_Id.Text = GvBudgetCategory.SelectedRow.Cells[1].Text;
            txtCategory_Name.Text = GvBudgetCategory.SelectedRow.Cells[2].Text;
            ddlCategory_Type.SelectedValue = GvBudgetCategory.SelectedRow.Cells[3].Text;

        }

        protected void ddlCategory_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(sqlconn);
            //con.Open();
            //string sqlstr = "select Category_Type from BudgetCategories order by Category_Id ";
            //SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    ddlCategory_Type.DataSource = dt;
            //    ddlCategory_Type.DataTextField = "Category_Type";
            //    ddlCategory_Type.DataBind();
            //    ddlCategory_Type.Items.Insert(0, "--select--");

            //}
        
        }
    }
}