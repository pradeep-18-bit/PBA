using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace PBA.reports
{
    public partial class ExpensesReport : System.Web.UI.Page
    {
        string sqlconstr = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        public override bool EnableEventValidation
        {
            get { return false; }
            // set { /Do nothing/ }
        }
        
        protected void txtExpense_Id_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "";
            if (txtExpense_Id.Text != "")

                sqlstr = "select Expense_Id,User_Id,Category,Amount,Date_Spent from  Expenses where Expense_Id='" + txtExpense_Id.Text + "' ";
            else
                sqlstr = "select Expense_Id,User_Id,Category,Amount,Date_Spent from  Expenses order by Expense_Id ";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvExpensesReport.DataSource = dt;
                GvExpensesReport.DataBind();

            }
            else
            {

                Response.Write("Record Not Found");
            }


        }

        protected void btnGetdata_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "";
            if (txtExpense_Id.Text != "")

                sqlstr = "select Expense_Id,User_Id,Category,Amount,Date_Spent from  Expenses where Expense_Id='"+ txtExpense_Id.Text +"' ";
            else
                sqlstr = "select Expense_Id,User_Id,Category,Amount,Date_Spent from  Expenses order by Expense_Id ";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvExpensesReport.DataSource = dt;
                GvExpensesReport.DataBind();

            }
            else
            {

                Response.Write("Record Not Found");
            }

        }

        protected void GvUserDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            GenerateExcelReport();    
        }
        protected void GenerateExcelReport()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Expenses Report" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GvExpensesReport.GridLines = GridLines.Both;
            GvExpensesReport.HeaderStyle.Font.Bold = true;
            GvExpensesReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void btnGenerateReports_Click(object sender, EventArgs e)
        {
            

        }

       
        }

      }
