using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.AdminHub
{
    public partial class Permission1 : System.Web.UI.UserControl
    {
        #region Variable Declaration

        PermissionClass _permission = null;
        long _PKID = 0;

        #endregion

        #region Accessor

        /// <summary>
        /// display the current record
        /// </summary>
        private void displayRecord()
        {
            cboEmployee.SelectedValue = _permission.EmployeeID.ToString();
            cboForm.SelectedValue = _permission.PageID.ToString();
            cboAccessTypes.Text = _permission.AccessType;
        }

        #endregion

        #region Mutator

        /// <summary>
        /// Assign the class properties to the text field values 
        /// </summary>
        private void assignData()
        {
            _permission.EmployeeID = long.Parse(cboEmployee.SelectedValue.ToString());
            _permission.PageID = long.Parse(cboForm.SelectedValue.ToString());
            _permission.Page = cboForm.SelectedItem.Text;
            _permission.Employee = cboEmployee.SelectedItem.Text;
            _permission.AccessType = cboAccessTypes.Text;
        }

        private void PopulateDropDownList(DropDownList pdlist, DataTable pDataTable, String pstrDataMember, String pstrDataValueField)
        {
            pdlist.DataSource = pDataTable;
            pdlist.DataTextField = pstrDataMember;
            pdlist.DataValueField = pstrDataValueField;
            pdlist.DataBind();
        }

        private void PopulateDropDownList()
        {
            PopulateDropDownList(cboEmployee, _permission.getEmployees(), "FirstName", "EmployeeID");
            PopulateDropDownList(cboForm, _permission.getForms(), "PageName", "PageID");
        }

        private void clearSession()
        {
            Session["EmployeeFormID"] = "";
        }

        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeFormID"].ToString() != "" && long.TryParse(Session["EmployeeFormID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["EmployeeFormID"].ToString());
                if (!Page.IsPostBack)
                {
                    Session["Permission"] = _permission = new PermissionClass(_PKID);
                    displayRecord();
                    PopulateDropDownList();
                }
                _permission = (PermissionClass)Session["Permission"];
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    Session["Permission"] = _permission = new PermissionClass();
                    PopulateDropDownList();
                }
                _permission = (PermissionClass)Session["Permission"];
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            assignData();
            _permission.saveData();
            clearSession();
            Response.Redirect("/AdminHub/PermissionList.aspx");
        }
        #endregion 
    }
}