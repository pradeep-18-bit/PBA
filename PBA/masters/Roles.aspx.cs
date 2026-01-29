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
    public partial class Roles : System.Web.UI.Page
    {
        string sqlconstr = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // if (Session["Role"].ToString() == "1".ToString())
                //  {
                //fillgrid();
                // }
                fillRole();


            }
        }

        protected void clearControls()
        {
            txtRoleId.Text = string.Empty;
            txtRoleName.Text = string.Empty;

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "Insert into tbl_Roles (RoleId,RoleName)values('"+ txtRoleId.Text +"','" + txtRoleName.Text + "')";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("Record inserted Sucessfully");
                //if (Session["User"] != null)
                //{
                fillRole();
                //}

            }
            con.Close();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "Update tbl_Roles set RoleName='" + txtRoleName.Text + "' from tbl_Roles where RoleId='" + txtRoleId.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Response.Write("Record Updated Sucessfully");
                fillRole();
            }
            else
            {

                Response.Write("Error Occured while Updating");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            {
                con.Open();
                string sqlstr = "DELETE FROM tbl_Roles WHERE RoleId = '" + txtRoleId.Text + "'";
                using (SqlCommand cmd = new SqlCommand(sqlstr, con))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Response.Write("Deletion Successful");
                        fillRole();
                    }
                    else
                    {
                        Response.Write("Deletion Failed");
                    }
                }
            }
        }

        protected void txtRoleId_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "select RoleId,RoleName from tbl_Roles where RoleId=" + txtRoleId.Text + " or RoleName='" + txtRoleName.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {

                    txtRoleId.Text = rdr["RoleId"].ToString();
                    txtRoleName.Text = rdr["RoleName"].ToString();

                }
            }

            else
            {
                //ClearControls();
                Response.Write("Record Not Found");
            }
        }


        protected void fillRole()
        {
            SqlConnection con = new SqlConnection(sqlconstr);
            con.Open();
            string sqlstr = "Select RoleId,RoleName from tbl_Roles order by RoleId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Gvtbl_RoleDetails.DataSource = dt;
                Gvtbl_RoleDetails.DataBind();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            string homepage = @"~\Home.aspx";
            Response.Redirect(homepage);

        }

        protected void Gvtbl_RoleDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoleId.Text = Gvtbl_RoleDetails.SelectedRow.Cells[1].Text;
            txtRoleName.Text = Gvtbl_RoleDetails.SelectedRow.Cells[2].Text;
          
        }
    }
}
       