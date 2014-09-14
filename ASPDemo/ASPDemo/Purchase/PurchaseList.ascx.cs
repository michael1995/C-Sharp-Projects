using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Purchase
{
    public partial class PurchaseList : System.Web.UI.UserControl
    {

        #region Variable Declaration

        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable _dtb;
        PurchaseClass _purchase;
        long _PKID = 0;

        #endregion

        #region Accessors


        #endregion

        #region Mutators

        private void fillGridView()
        {
            _dtb = _dbConn.GetDataTable(("qryPurchases"));
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
            Session["PurchasePKID"] = "";
            Response.Redirect("/Purchase/Purchase.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Session["PurchasePKID"].ToString() != "")
            {
                Response.Redirect("/Purchase/Purchase.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvData.SelectedRow;
            Session["PurchasePKID"] = row.Cells[1].Text;
        }
        #endregion 
    }
}