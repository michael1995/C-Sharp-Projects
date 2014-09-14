using ChocoMamboWebApplication.AppObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class NewEmployee : System.Web.UI.Page
    {
        Employee _employee;
        long _pkID=0;
      
        private void InitializeClass(){
            _employee = new Employee();
        }
        private void InitializeClass(long pLongID)
        {
            _employee = new Employee(pLongID);
            //Only display the record if is not a postback event
            if(!Page.IsPostBack)
            displayRecord();
        }
        #region Accessors
        /// <summary>
        ///Pre-Condition:All properties have an assigned value
        ///Post-Condition:The current record is set to text boxes
        ///Description:Displays the current record in text boxes
        /// </summary>
        private void displayRecord()
        {
            txt_Name.Text = _employee.Name;
            txt_PhoneNumber.Text = _employee.PhoneNumber;
            txt_HouseNumber.Text = _employee.BuildingNumber;
            txt_Street.Text = _employee.StreetName;
            txt_Suburb.Text = _employee.Suburb;
            txt_State.Text = _employee.State;
            txt_Postcode.Text = _employee.Postcode;
            txt_Department.Text = _employee.Department;
            txt_Salary.Text = _employee.Salary.ToString();
        }

        #endregion
        #region Mutators
        /// <summary>
        ///Pre-Condition:Textboxes are checked for correct format
        ///Post-Condition:Current record equals textbox values
        ///Description:Sets class properties to textbox values
        /// </summary>
        private void assignData()
        {
            _employee.Name = txt_Name.Text;
            _employee.PhoneNumber = txt_PhoneNumber.Text;
            _employee.BuildingNumber = txt_HouseNumber.Text;
            _employee.StreetName = txt_Street.Text;
            _employee.Suburb = txt_Suburb.Text;
            _employee.State = txt_State.Text;
            _employee.Postcode = txt_Postcode.Text;
            _employee.Department = txt_Department.Text;
            _employee.Salary = long.Parse(txt_Salary.Text);
        }



        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

           
                if (Session["ID"].ToString()!="" && long.TryParse(Session["ID"].ToString(), out _pkID))
                {
                    _pkID = long.Parse(Session["ID"].ToString());
                    InitializeClass(_pkID);

                }
                else
                    InitializeClass();
            
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            assignData();
            _employee.saveData();
            Response.Redirect("EmployeeList.aspx");
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            _employee.deleteEmployee(_pkID);
           
            Response.Redirect("EmployeeList.aspx");
        }

    }
}