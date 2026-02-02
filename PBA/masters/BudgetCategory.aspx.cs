using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PBA.masters
{
    public partial class BudgetCategory : System.Web.UI.Page
    {
        // ✅ Consistent connection string variable
        private readonly string cs = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCategoryType();
                FillGrid();
            }
        }

        // ================= LOAD CATEGORY TYPES =================
        protected void FillCategoryType()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = "SELECT Category_Id, Category_Type FROM BudgetCategories ORDER BY Category_Id";
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
        }

        // ================= LOAD GRID =================
        protected void FillGrid()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sqlstr = "SELECT Category_Id, Category_Name, Category_Type FROM BudgetCategories ORDER BY Category_Id";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GvBudgetCategory.DataSource = dt;
                    GvBudgetCategory.DataBind();
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
            txtCategory_Id.Text = string.Empty;
            txtCategory_Name.Text = string.Empty;
            ddlCategory_Type.SelectedIndex = -1;
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
                string sqlstr = "INSERT INTO BudgetCategories (Category_Id, Category_Name, Category_Type) VALUES (@Id, @Name, @Type)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@Id", txtCategory_Id.Text);
                cmd.Parameters.AddWithValue("@Name", txtCategory_Name.Text);
                cmd.Parameters.AddWithValue("@Type", ddlCategory_Type.SelectedValue);

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
                string sqlstr = "UPDATE BudgetCategories SET Category_Name = @Name, Category_Type = @Type WHERE Category_Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@Id", txtCategory_Id.Text);
                cmd.Parameters.AddWithValue("@Name", txtCategory_Name.Text);
                cmd.Parameters.AddWithValue("@Type", ddlCategory_Type.SelectedValue);

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
                string sqlstr = "DELETE FROM BudgetCategories WHERE Category_Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.AddWithValue("@Id", txtCategory_Id.Text);

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
        protected void GvBudgetCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCategory_Id.Text = GvBudgetCategory.SelectedRow.Cells[1].Text;
            txtCategory_Name.Text = GvBudgetCategory.SelectedRow.Cells[2].Text;
            ddlCategory_Type.SelectedValue = GvBudgetCategory.SelectedRow.Cells[3].Text;
        }

        protected void ddlCategory_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: reload categories if needed
        }
    }
}