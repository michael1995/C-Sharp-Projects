using DBConnection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.AdminHub
{
    public partial class PermissionList : System.Web.UI.UserControl
    {

        #region Variable Declaration

        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable _dtb;
        PermissionClass _permission;
        long _PKID = 0;

        #endregion

        #region Accessors


        #endregion

        #region Mutators

        private void fillGridView()
        {
            _dtb = _dbConn.GetDataTable(("qryAccessLevels"));
            gvData.DataSource = _dtb.DefaultView;
            gvData.DataBind();
        }

        private Boolean isAdmin(String pstrPage, Hashtable phshTemp)
        {
            if (phshTemp[pstrPage].ToString().Equals("Admin"))
                return true;
            else
                return false;
        }

        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            Hashtable AccessRight = (Hashtable)Session["AccessRight"];
            if (isAdmin("AdminHub", AccessRight) == false)
            {
                Response.Redirect("/Home/Home.aspx");
            }
            else
            {
                fillGridView();
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Session["EmployeeFormID"] = "";
            Response.Redirect("/AdminHub/Permission.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Session["EmployeeFormID"].ToString() != "")
            {
                Response.Redirect("/AdminHub/Permission.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["EmployeeFormID"].ToString() != "" && long.TryParse(Session["EmployeeFormID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["EmployeeFormID"].ToString());
                _permission = new PermissionClass(_PKID);
                _permission.deleteRecord(_PKID);
                Session["EmployeeFormID"] = "";
            }
            fillGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvData.SelectedRow;
            Session["EmployeeFormID"] = row.Cells[1].Text;
        }

        #endregion 
    }
}