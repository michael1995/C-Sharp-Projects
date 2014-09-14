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

namespace ASPDemo.Employee
{
    public partial class EmployeeList : System.Web.UI.UserControl
    {

        #region Variable Declaration

        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable _dtb;
        EmployeeClass _employee;
        long _PKID = 0;

        #endregion 

        #region Accessors


        #endregion 

        #region Mutators

        private void fillGridView()
        {
            _dtb = _dbConn.GetDataTable(("qryEmployee"));
            gvData.DataSource = _dtb.DefaultView;
            gvData.DataBind();
        }

        private void hideButton(Button pbtnTemp)
        {
            pbtnTemp.Visible = false;
        }

        public void CheckAccessRights(string pStrFormName, Hashtable phshTemp)
        {
            if (phshTemp[pStrFormName].ToString() == "Deny")
            {
                Response.Redirect("/Home/Home.aspx");
            }
            if (phshTemp[pStrFormName].ToString() == "Read")
            {
                hideButton(btnDelete);
                hideButton(btnEdit);
            }
            if (phshTemp[pStrFormName].ToString() == "Write")
            {
                //do nothing here because nothing needs to be changed
            }
            if (phshTemp[pStrFormName].ToString() == "Admin")
            {
                //do nothing here because nothing needs to be changed
            }
        }

        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            Hashtable AccessRights = (Hashtable)Session["AccessRight"];
            if (AccessRights.Contains(("Employee")))
            {
                CheckAccessRights("Employee", AccessRights);
            }
            if (AccessRights.Contains(("AllPages")))
            {
                CheckAccessRights("AllPages", AccessRights);
            }
            fillGridView();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Session["EmployeePKID"] = "";
            Response.Redirect("/Employee/Employee.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Session["EmployeePKID"].ToString() != "")
            {
                Response.Redirect("/Employee/Employee.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["EmployeePKID"].ToString() != "" && long.TryParse(Session["EmployeePKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["EmployeePKID"].ToString());
                _employee = new EmployeeClass(_PKID);
                _employee.deleteRecord(_PKID);
                Session["EmployeePKID"] = "";
            }
            fillGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvData.SelectedRow;
            Session["EmployeePKID"] = row.Cells[1].Text;
        }

        #endregion 
    }
}