using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Customer
{
    public partial class Customer : System.Web.UI.UserControl
    {

        #region Variable Declaration

        CustomerClass _customer = null;
        long _PKID = 0;

        #endregion

        #region Accessor

        /// <summary>
        /// Display the current Record
        /// </summary>
        private void displayRecord()
        {
            cboEmployee.SelectedValue = _customer.EmployeeID.ToString();
            txtCustomerName.Text = _customer.CustomerName;
            txtPhone.Text = _customer.Phone;
            txtAddress.Text = _customer.Address;
            txtPostCode.Text = _customer.Postcode;
            txtSuburb.Text = _customer.Suburb;
            txtState.Text = _customer.State;
        }

        private void populateEmployeeComboBox()
        {
            cboEmployee.DataSource = _customer.getEmployees();
            cboEmployee.DataValueField = "EmployeeID";
            cboEmployee.DataTextField = "FirstName";
            cboEmployee.DataBind();
        }

        #endregion

        #region Mutator

        /// <summary>
        /// Assign the class properties to the text field values 
        /// </summary>
        private void AssignData()
        {
            _customer.EmployeeID = long.Parse(cboEmployee.SelectedValue.ToString());
            _customer.CustomerName = txtCustomerName.Text;
            _customer.Phone = txtPhone.Text;
            _customer.Address = txtAddress.Text;
            _customer.Postcode = txtPostCode.Text;
            _customer.Suburb = txtSuburb.Text;
            _customer.State = txtState.Text;
        }
        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerPKID"].ToString() != "" && long.TryParse(Session["CustomerPKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["CustomerPKID"].ToString());
                _customer = new CustomerClass(_PKID);
                if (!Page.IsPostBack)
                {
                    displayRecord();
                }
            }
            else
            {
                _customer = new CustomerClass();
            }
            populateEmployeeComboBox();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AssignData();
            _customer.saveData();
            Session["CustomerPKID"] = "";
            Response.Redirect("/Customer/CustomerList.aspx");
        }
        #endregion 
    }
}