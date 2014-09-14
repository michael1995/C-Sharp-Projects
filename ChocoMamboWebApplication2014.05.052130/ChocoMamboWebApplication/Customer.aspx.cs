using ChocoMamboWebApplication.AppObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class CustomerList : System.Web.UI.Page
    {
        Customer _customer;
        long _pkID = 0;
        private void InitializeClass()
        {
            _customer = new Customer();
        }
        private void InitializeClass(long pLongID)
        {
            _customer = new Customer(pLongID);
            if (!Page.IsPostBack)
            AssignDataToTextbox();
        }
        #region Accessors
        /// <summary>
        /// Pre-Condition: All properties have an assigned value
        /// Post-Condition: The current record is set to text boxes
        /// Description:Displays the current record in text boxes
        /// </summary>
        private void AssignDataToTextbox()
        {
            txt_Name.Text = _customer.Name;
            txt_PhoneNumber.Text = _customer.PhoneNumber;
            txt_HouseNumber.Text = _customer.BuildingNumber;
            txt_Street.Text = _customer.StreetName;
            txt_Suburb.Text = _customer.Suburb;
            txt_State.Text = _customer.State;
            txt_Postcode.Text = _customer.Postcode;
            txt_SalesManager.Text = _customer.SalesMananger.ToString();
            txt_ContactPerson.Text = _customer.ContactPerson;
        }
        /// <summary>
        /// Pre-Condition: Table must contain the columns "EmployeeName" and "ID"
        /// Post-Condition: cbo_saleManangers filled with the names of sales manangers.
        /// Description:Populates the combobox cbo_saleManangers
        /// </summary>
        //private void populateSaleManangersComboBox()
        //{
        //    cbo_saleManangers.DataSource = _customer.getSaleManangers();
        //    cbo_saleManangers.DisplayMember = "EmployeeName";
        //    cbo_saleManangers.ValueMember = "ID";
        //}
        /// <summary>
        /// Pre-Condition: An instance of the class Validate.
        /// Post-Condition: Data in textboxes is checked and validated.
        /// Description:Checks all txtboxes for null entries and numberfields for text.
        /// </summary>
       

        #endregion

        #region Mutators
        /// <summary>
        /// Pre-Condition: Textboxes are checked for correct format
        /// Post-Condition: Current record equals textbox values
        /// Description: Sets class properties to textbox values
        /// </summary>
        private void assignData()
        {
            _customer.Name = txt_Name.Text;
            _customer.PhoneNumber = txt_PhoneNumber.Text;
            _customer.BuildingNumber = txt_HouseNumber.Text;
            _customer.StreetName = txt_Street.Text;
            _customer.Suburb = txt_Suburb.Text;
            _customer.State = txt_State.Text;
            _customer.Postcode = txt_Postcode.Text;
            _customer.SalesMananger = int.Parse(txt_SalesManager.Text);
            _customer.ContactPerson = txt_ContactPerson.Text;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["ID"].ToString() != "" && long.TryParse(Session["ID"].ToString(), out _pkID))
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
            _customer.saveData();
            Response.Redirect("CustomerList.aspx");
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            _customer.deleteCustomer(_pkID);
            Response.Redirect("CustomerList.aspx");
        }
    }
}