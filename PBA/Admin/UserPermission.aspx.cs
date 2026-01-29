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
    public partial class UserPermission : System.Web.UI.Page
    {
        string sqlconn = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillroles();
            }
        }

        protected void fillroles()
        {
            SqlConnection con = new SqlConnection(sqlconn);
            {
                con.Open();
                string sqlstr = "Select RoleId, RoleName from tbl_Roles order by RoleId";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlRole.DataSource = dt;
                    ddlRole.DataTextField = "RoleName";
                    ddlRole.DataValueField = "RoleId";
                    ddlRole.DataBind();
                    ddlRole.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRole.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(sqlconn);
                {
                    con.Open();
                    string sqlstr = "select Id, UserName from tbl_Customer where Role = " + ddlRole.SelectedValue;
                    SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ddlUsers.DataSource = dt;
                        ddlUsers.DataTextField = "UserName";
                        ddlUsers.DataValueField = "Id";
                        ddlUsers.DataBind();
                        ddlUsers.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            else
            {
                ddlUsers.Items.Clear();
            }
        }



        protected void Gvuserpermission_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlUsers_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddlUsers.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(sqlconn);
                {
                    con.Open();
                    string sqlstr = "select id, RoleName, UserName, ScreenName, IsCreate, IsUpdate, IsDelete, IsView from tbl_UserPermission1 where UserName = '" + ddlUsers.SelectedItem.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Gvuserpermission.DataSource = dt;
                        Gvuserpermission.DataBind();
                    }
                }
            }
            else
            {
                Gvuserpermission.DataSource = null;

                Gvuserpermission.DataBind();
            }
        }


    }
}