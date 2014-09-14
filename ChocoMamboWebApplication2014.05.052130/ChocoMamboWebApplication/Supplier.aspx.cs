using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class Supplier : System.Web.UI.Page
    { 
        #region Class Variables
        AppObjects.Supplier _supplier;

        long _pkID = 0;
        #endregion
        private void InitializeClass()
        {
            _supplier = new AppObjects.Supplier();
        }
        private void InitializeClass(long pLongID)
        {
            _supplier =  new AppObjects.Supplier(pLongID);
            if (!Page.IsPostBack)
                AssignDataToTextbox();
        }
        #region Accessors
        /// <summary>
        ///Pre-Condition:All properties have an assigned value
        ///Post-Condition:The current record is set to text boxes
        ///Description:Displays the current record in text boxes
        /// </summary>
        private void AssignDataToTextbox()
        {
            txt_Name.Text = _supplier.Name;
            txt_PhoneNumber.Text = _supplier.PhoneNumber;
            txt_HouseNumber.Text = _supplier.BuildingNumber;
            txt_Street.Text = _supplier.StreetName;
            txt_Suburb.Text = _supplier.Suburb;
            txt_State.Text = _supplier.State;
            txt_Postcode.Text = _supplier.Postcode;
            txt_ContactPerson.Text = _supplier.ContactPerson;
        }
        /// <summary>
        ///Pre-Condition:An instance of the class Validate.
        ///Post-Condition:Data in textboxes is checked and validated.
        ///Description:Checks all txtboxes for null entries and numberfields for text.
        /// </summary>
        /// <returns></returns>
      
        #endregion

        #region Mutators
        /// <summary>
        ///Pre-Condition:Textboxes are checked for correct format
        ///Post-Condition:Current record equals textbox values
        ///Description:Sets class properties to textbox values
        /// </summary>
        private void assignData()
        {
            _supplier.Name = txt_Name.Text;
            _supplier.PhoneNumber = txt_PhoneNumber.Text;
            _supplier.BuildingNumber = txt_HouseNumber.Text;
            _supplier.StreetName = txt_Street.Text;
            _supplier.Suburb = txt_Suburb.Text;
            _supplier.State = txt_State.Text;
            _supplier.Postcode = txt_Postcode.Text;
            _supplier.IsASupplier = true;
            _supplier.ContactPerson = txt_ContactPerson.Text;
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

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
                        _supplier.deleteSupplier(_pkID);
                        Response.Redirect("SupplierList.aspx");
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            assignData();
            _supplier.saveData();
            Response.Redirect("SupplierList.aspx");
        }
    }
}