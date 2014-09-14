using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.RawIngredient
{
    public partial class RawIngredientList : System.Web.UI.UserControl
    {

        #region Variable Declaration

        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable _dtb;
        RawIngredientClass _rawingredient;
        long _PKID = 0;

        #endregion

        #region Accessors


        #endregion

        #region Mutators

        private void fillGridView()
        {
            _dtb = _dbConn.GetDataTable(("qryRawIngredients"));
            gvData.DataSource = _dtb.DefaultView;
            gvData.DataBind();
        }

        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            fillGridView();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Session["RawIngredientPKID"] = "";
            Response.Redirect("/RawIngredient/RawIngredient.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Session["RawIngredientPKID"].ToString() != "")
            {
                Response.Redirect("/RawIngredient/RawIngredient.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["RawIngredientPKID"].ToString() != "" && long.TryParse(Session["RawIngredientPKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["RawIngredientPKID"].ToString());
                _rawingredient = new RawIngredientClass(_PKID);
                _rawingredient.deleteRecord(_PKID);
                Session["RawIngredientPKID"] = "";
            }
            fillGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvData.SelectedRow;
            Session["RawIngredientPKID"] = row.Cells[1].Text;
        }
        #endregion 
    }
}