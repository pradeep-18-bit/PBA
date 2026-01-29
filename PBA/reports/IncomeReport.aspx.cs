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
    public partial class IncomeReport : System.Web.UI.Page
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
        protected void txtIncome_Id_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "";
            if (txtIncome_Id.Text != "")

                sqlstr = "select Income_Id,User_Id,Income_Source,Category,Amount,Description,Income_Date from  Income where Income_Id='"+ txtIncome_Id.Text +"' ";
            else
                sqlstr = "select Income_Id,User_Id,Income_Source,Category,Amount,Description,Income_Date from Income order by Income_Id ";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvIncomeReport.DataSource = dt;
                GvIncomeReport.DataBind();

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
            if (txtIncome_Id.Text != "")

                sqlstr = "select Income_Id,User_Id,Income_Source,Category,Amount,Description,Income_Date from  Income where Income_Id='"+ txtIncome_Id.Text +"'";
            else
                sqlstr = "select  Income_Id,User_Id,Income_Source,Category,Amount,Description,Income_Date from  Income order by Income_Id ";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GvIncomeReport.DataSource = dt;
                GvIncomeReport.DataBind();

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
            string FileName = "UserProfileManagement1" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GvIncomeReport.GridLines = GridLines.Both;
            GvIncomeReport.HeaderStyle.Font.Bold = true;
            GvIncomeReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
        protected void btnGenerateReports_Click(object sender, EventArgs e)
        {


        }

    }
}