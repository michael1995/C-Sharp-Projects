using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Product
{
    public partial class Product1 : System.Web.UI.UserControl
    {

        #region Variable Declaration

        ProductClass _product = null;
        long _PKID = 0;

        #endregion

        #region Accessor

        /// <summary>
        /// display the current record
        /// </summary>
        private void displayRecord()
        {
            txtProductName.Text = _product.ProductName;
            txtProductCode.Text = _product.ProductCode;
            txtQauntity.Text = _product.QuantityInStock;
            txtPrice.Text = _product.Price;
            txtComment.Text = _product.Comments;
        }

        #endregion

        #region Mutator

        /// <summary>
        /// Assign the class properties to the text field values 
        /// </summary>
        private void AssignData()
        {
            _product.ProductName = txtProductName.Text;
            _product.ProductCode = txtProductCode.Text;
            _product.QuantityInStock = txtQauntity.Text;
            _product.Price = txtPrice.Text;
            _product.Comments = txtComment.Text;
        }
        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ProductPKID"].ToString() != "" && long.TryParse(Session["ProductPKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["ProductPKID"].ToString());
                _product = new ProductClass(_PKID);
                if (!Page.IsPostBack)
                {
                    displayRecord();
                }
            }
            else
            {
                _product = new ProductClass();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AssignData();
            _product.saveData();
            Session["ProductPKID"] = "";
            Response.Redirect("/Product/ProductList.aspx");
        }
        #endregion 
    }
}