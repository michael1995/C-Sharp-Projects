using DBConnection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Employee
{
    public partial class Employee : System.Web.UI.UserControl
    {

        #region Variable Declaration

        EmployeeClass _employee = null;
        long _PKID = 0;

        #endregion 

        #region Accessor

        private void displayRecord()
        {
            txtFirstName.Text = _employee.FirstName;
            txtLastName.Text = _employee.LastName;
            txtPhone.Text = _employee.Phone;
            txtAddress.Text = _employee.AddressLine1;
            txtPostCode.Text = _employee.Postcode;
            txtSuburb.Text = _employee.Suburb;
            txtState.Text = _employee.State;
            cboDepartment.Text = _employee.Department;
            txtSalary.Text = _employee.Salary;
            txtUsername.Text = _employee.UserName;
            txtPassword.Text = _employee.UserPassword;
        }

        #endregion 

        #region Mutator

        private void AssignData()
        {
            _employee.FirstName = txtFirstName.Text;
            _employee.LastName = txtLastName.Text;
            _employee.Phone = txtPhone.Text;
            _employee.AddressLine1 = txtAddress.Text;
            _employee.Postcode = txtPostCode.Text;
            _employee.Suburb = txtSuburb.Text;
            _employee.State = txtState.Text;
            _employee.Department = cboDepartment.Text;
            _employee.Salary = txtSalary.Text;
            _employee.UserName = txtUsername.Text;
            _employee.UserPassword = txtPassword.Text;
        }

        private void hideButton(Button pbtnTemp)
        {
            pbtnTemp.Visible = false;
        }

        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeePKID"].ToString() != "" && long.TryParse(Session["EmployeePKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["EmployeePKID"].ToString());
                _employee = new EmployeeClass(_PKID);
                if (!Page.IsPostBack)
                {
                    displayRecord();  
                }
            }
            else
            {
                _employee = new EmployeeClass();
            }
            
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AssignData();
            _employee.saveData();
            Session["EmployeePKID"] = "";
            Response.Redirect("/Employee/EmployeeList.aspx");
        }
        #endregion 
    }
}