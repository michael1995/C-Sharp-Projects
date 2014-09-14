using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Supplier
{
    public partial class Supplier1 : System.Web.UI.UserControl
    {

        #region Variable Declaration

        SupplierClass _supplier = null;
        long _PKID = 0;

        #endregion

        #region Accessor

        /// <summary>
        /// display the current record
        /// </summary>
        private void displayRecord()
        {
            txtSupplierName.Text = _supplier.SupplierName;
            txtPhone.Text = _supplier.Phone;
            txtAddress.Text = _supplier.Address;
            txtPostCode.Text = _supplier.Postcode;
            txtSuburb.Text = _supplier.Suburb;
            txtState.Text = _supplier.State;
        }

        #endregion

        #region Mutator

        /// <summary>
        /// Assign the class properties to the text field values
        /// </summary>
        private void AssignData()
        {
            _supplier.SupplierName = txtSupplierName.Text;
            _supplier.Phone = txtPhone.Text;
            _supplier.Address = txtAddress.Text;
            _supplier.Postcode = txtPostCode.Text;
            _supplier.Suburb = txtSuburb.Text;
            _supplier.State = txtState.Text;
        }
        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SuplierPKID"].ToString() != "" && long.TryParse(Session["SuplierPKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["SuplierPKID"].ToString());
                _supplier = new SupplierClass(_PKID);
                if (!Page.IsPostBack)
                {
                    displayRecord();
                }
            }
            else
            {
                _supplier = new SupplierClass();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AssignData();
            _supplier.saveData();
            Session["SuplierPKID"] = "";
            Response.Redirect("/Supplier/SupplierList.aspx");
        }
        #endregion 
    }
}