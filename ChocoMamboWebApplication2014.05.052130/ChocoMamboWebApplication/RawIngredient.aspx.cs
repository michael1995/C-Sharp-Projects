using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class RawIngredient : System.Web.UI.Page
    {
        #region Class Variables
        AppObjects.RawIngredient _rawIngredient;
        long _pkID = 0;
        #endregion
        private void InitializeClass()
        {
            _rawIngredient = new AppObjects.RawIngredient();
        }
        private void InitializeClass(long pLongID)
        {
            _rawIngredient = new AppObjects.RawIngredient(pLongID);
            if (!Page.IsPostBack)
                AssignDataToTextbox();
        }
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
        #region Accessors
       
        /// <summary>
        ///Description:Populates Supplier comboBox
        /// </summary>
        //private void populateSupplierComboBox()
        //{
        //    cbo_supplier.DataSource = _rawIngredient.getSuppliers();
        //    cbo_supplier.DisplayMember = "ContactName";
        //    cbo_supplier.ValueMember = "ID";
        //}
        /// <summary>
        ///Pre-Condition:All properties have an assigned value
        ///Post-Condition:The current record is set to text boxes
        ///Description:Displays the current record in text boxes
        /// </summary>
        private void AssignDataToTextbox()
        {
            txt_Name.Text = _rawIngredient.Name;
            txt_Code.Text = _rawIngredient.Code;
            txt_Price.Text = _rawIngredient.Price.ToString();
            txt_QtyOnHand.Text = _rawIngredient.QtyOnHand.ToString();
            txt_QtyOnOrder.Text = _rawIngredient.QtyOnOrder.ToString();
            txt_Supplier.Text = _rawIngredient.SupplierNumber.ToString();
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
            _rawIngredient.Name = txt_Name.Text;
            _rawIngredient.Code = txt_Code.Text;
            _rawIngredient.Price = decimal.Parse(txt_Price.Text);
            _rawIngredient.QtyOnHand = long.Parse(txt_QtyOnHand.Text);
            _rawIngredient.QtyOnOrder = long.Parse(txt_QtyOnOrder.Text);
            _rawIngredient.SupplierNumber = long.Parse(txt_Supplier.Text);
        }
        #endregion

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            assignData();
            _rawIngredient.saveData();
            Response.Redirect("RawIngredientList.aspx");
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            _rawIngredient.deleteRawIngredient(_pkID);
            Response.Redirect("RawIngredientList.aspx");
        }
    }
}