using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.RawIngredient
{
    public partial class RawIngredient1 : System.Web.UI.UserControl
    {

        #region Variable Declaration

        RawIngredientClass _rawIngredient = null;
        long _PKID = 0;

        #endregion

        #region Accessor

        /// <summary>
        /// display the current record
        /// </summary>
        private void displayRecord()
        {
            txtIngredientName.Text = _rawIngredient.IngredientName;
            txtIngredientCode.Text = _rawIngredient.IngCode;
            txtPrice.Text = _rawIngredient.Price;
        }

        #endregion

        #region Mutator

        /// <summary>
        /// Assign the class properties to the text field values 
        /// </summary>
        private void AssignData()
        {
            _rawIngredient.IngredientName = txtIngredientName.Text;
            _rawIngredient.IngCode = txtIngredientCode.Text;
            _rawIngredient.Price = txtPrice.Text;
        }
        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RawIngredientPKID"].ToString() != "" && long.TryParse(Session["RawIngredientPKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["RawIngredientPKID"].ToString());
                _rawIngredient = new RawIngredientClass(_PKID);
                if (!Page.IsPostBack)
                {
                    displayRecord();
                }
            }
            else
            {
                _rawIngredient = new RawIngredientClass();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AssignData();
            _rawIngredient.saveData();
            Session["RawIngredientPKID"] = "";
            Response.Redirect("/RawIngredient/RawIngredientList.aspx");
        }
        #endregion 
    }
}