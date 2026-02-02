using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PBA
{
    public partial class Income : System.Web.UI.Page
    {
        // ✅ Consistent connection string variable
        private readonly string cs = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
                FillCategory();
            }
        }

        // ================= LOAD CATEGORY =================
        protected void FillCategory()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = "SELECT Category_Id, Category_Type FROM BudgetCategories ORDER BY Category_Id";
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
        }

        // ================= LOAD GRID =================
        protected void FillGrid()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = "SELECT Income_Id, User_Id, Income_Source, Category, Amount, Description, Income_Date FROM Income ORDER BY Income_Id";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GvUserDetails.DataSource = dt;
                    GvUserDetails.DataBind();
                }
                else
                {
                    Response.Write("Records Not found");
                }
            }
        }

        // ================= CLEAR CONTROLS =================
        protected void ClearControls()
        {
            txtIncome_Id.Text = string.Empty;
            txtUser_Id.Text = string.Empty;
            txtIncome_Source.Text = string.Empty;
            ddlCategory.SelectedIndex = -1;
            txtAmount.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtIncome_Date.Text = string.Empty;
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
                string sqlstr = @"INSERT INTO Income 
                                  (Income_Id, User_Id, Income_Source, Category, Amount, Description, Income_Date) 
                                  VALUES (@Income_Id, @User_Id, @Income_Source, @Category, @Amount, @Description, @Income_Date)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@Income_Id", txtIncome_Id.Text);
                cmd.Parameters.AddWithValue("@User_Id", txtUser_Id.Text);
                cmd.Parameters.AddWithValue("@Income_Source", txtIncome_Source.Text);
                cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Income_Date", txtIncome_Date.Text);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Write("Inserted successfully");
                    FillGrid();
                }
            }
        }

        // ================= UPDATE =================
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = @"UPDATE Income 
                                  SET User_Id = @User_Id, Income_Source = @Income_Source, Category = @Category, 
                                      Amount = @Amount, Description = @Description, Income_Date = @Income_Date 
                                  WHERE Income_Id = @Income_Id";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@Income_Id", txtIncome_Id.Text);
                cmd.Parameters.AddWithValue("@User_Id", txtUser_Id.Text);
                cmd.Parameters.AddWithValue("@Income_Source", txtIncome_Source.Text);
                cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Income_Date", txtIncome_Date.Text);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Write("Record Updated Successfully");
                    FillGrid();
                }
                else
                {
                    Response.Write("Error Occurred while Updating");
                }
            }
        }

        // ================= DELETE =================
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = "DELETE FROM Income WHERE Income_Id = @Income_Id";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@Income_Id", txtIncome_Id.Text);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Response.Write("Deletion Successful");
                    FillGrid();
                }
                else
                {
                    Response.Write("Deletion Failed");
                }
            }
        }

        // ================= CLOSE =================
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        // ================= GRID SELECTION =================
        protected void GvUserDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIncome_Id.Text = GvUserDetails.SelectedRow.Cells[1].Text;
            txtUser_Id.Text = GvUserDetails.SelectedRow.Cells[2].Text;
            txtIncome_Source.Text = GvUserDetails.SelectedRow.Cells[3].Text;
            ddlCategory.SelectedValue = GvUserDetails.SelectedRow.Cells[4].Text;
            txtAmount.Text = GvUserDetails.SelectedRow.Cells[5].Text;
            txtDescription.Text = GvUserDetails.SelectedRow.Cells[6].Text;
            txtIncome_Date.Text = GvUserDetails.SelectedRow.Cells[7].Text;
        }

        // ================= USER DETAILS LOOKUP =================
        protected void txtUser_Id_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = "SELECT User_Id, UserName, PhoneNumber, Email FROM tbl_Customer WHERE User_Id = @User_Id";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@User_Id", txtUser_Id.Text);

                con.Open();
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
        }

        // ================= HELPER: GET USER DETAILS =================
        private DataTable GetUserDetails(string userId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "SELECT UserName, Email FROM tbl_Customer WHERE User_Id = @User_Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@User_Id", userId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}