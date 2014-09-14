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

namespace ASPDemo
{
    public partial class UserLogin : System.Web.UI.UserControl
    {
        public long _lngPKID = 0;
        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Contents.Clear();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (allowLogin())
            {
                Session["AccessRight"] = getAccessRightsHashTable();
                Response.Redirect("/Home/Home.aspx");
            }
        }

        private bool allowLogin()
        {
            bool blnReturnValue = false;
            DataTable dtbStaff = _dbConn.GetDataTable("tblEmployees");
            foreach (DataRow drw in dtbStaff.Rows)
            {
                if (txtUsername.Text.Equals(drw["UserName"].ToString()) &&
                    txtPassword.Text.Equals(drw["UserPassword"].ToString()))
                {
                    _lngPKID = long.Parse(drw["EmployeeID"].ToString());
                    blnReturnValue = true;
                    break;
                }
            }
            return blnReturnValue;
        }

        private Hashtable getAccessRightsHashTable()
        {
            Hashtable hshAccessRights = new Hashtable();
            long lngFormID = 0;
            DataTable dtbForms = _dbConn.GetDataTable("tblForms");
            DataTable dtbEmployeeForms = _dbConn.GetDataTable("SELECT * FROM tblEmployeeForms " + "WHERE EmployeeID = " + _lngPKID, "tblEmployeeForms");
            foreach (DataRow drwForms in dtbForms.Rows)
            {
                foreach (DataRow drwEmployeeForms in dtbEmployeeForms.Rows)
                {
                    lngFormID = long.Parse(drwForms["PageID"].ToString());

                    if (lngFormID == long.Parse(drwEmployeeForms["PageID"].ToString()) &&
                        _lngPKID == long.Parse(drwEmployeeForms["EmployeeID"].ToString()))
                    {
                        hshAccessRights.Add(drwForms["PageName"].ToString(), drwEmployeeForms["AccessType"].ToString());
                    }
                }
            }
            return hshAccessRights;
        }
    }
}