using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class Product : System.Web.UI.Page
    {
        #region Class Variables
        AppObjects.Product _product;
        long _pkID = 0;
        #endregion
        private void InitializeClass()
        {
            _product = new AppObjects.Product();
        }
        private void InitializeClass(long pLongID)
        {
            _product = new AppObjects.Product(pLongID);
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
        ///Pre-Condition:All properties have an assigned value
        ///Post-Condition:The current record is set to text boxes
        ///Description:Displays the current record in text boxes
        /// </summary>
        private void AssignDataToTextbox()
        {
            txt_Name.Text = _product.Name;
            txt_Code.Text = _product.Code;
            txt_Price.Text = _product.Price.ToString();
            txt_QtyOnHand.Text = _product.QtyOnHand.ToString();
            txt_QtyOnOrder.Text = _product.QtyOnOrder.ToString();
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
            _product.Name = txt_Name.Text;
            _product.Code = txt_Code.Text;
            _product.Price = decimal.Parse(txt_Price.Text);
            _product.QtyOnHand = long.Parse(txt_QtyOnHand.Text);
            _product.QtyOnOrder = long.Parse(txt_QtyOnOrder.Text);
        }
        #endregion

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            assignData();
            _product.saveData();
            Response.Redirect("ProductList.aspx");
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            _product.deleteProduct(_pkID);
            Response.Redirect("ProductList.aspx");
        }
    }
}