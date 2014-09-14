using ASPDemo.Employee;
using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Product
{
    public partial class ProductList : System.Web.UI.UserControl
    {

        #region Variable Declaration

        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable _dtb;
        ProductClass _product;
        long _PKID = 0;

        #endregion

        #region Accessors


        #endregion

        #region Mutators

        private void fillGridView()
        {
            _dtb = _dbConn.GetDataTable(("qryProduct"));
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
            Session["ProductPKID"] = "";
            Response.Redirect("/Product/Product.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Session["ProductPKID"].ToString() != "")
            {
                Response.Redirect("/Product/Product.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["ProductPKID"].ToString() != "" && long.TryParse(Session["ProductPKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["ProductPKID"].ToString());
                _product = new ProductClass(_PKID);
                _product.deleteRecord(_PKID);
                Session["ProductPKID"] = "";
            }
            fillGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvData.SelectedRow;
            Session["ProductPKID"] = row.Cells[1].Text;
        }
        #endregion 
    }
}