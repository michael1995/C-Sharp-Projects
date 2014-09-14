using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Customer
{
    public partial class CustomerList : System.Web.UI.UserControl
    {

        #region Variable Declaration

        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataTable _dtb;
        CustomerClass _customer;
        long _PKID = 0;

        #endregion 

        #region Accessors


        #endregion

        #region Mutators

        private void fillGridView()
        {
            _dtb = _dbConn.GetDataTable(("qryCustomer"));
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
            Session["CustomerPKID"] = "";
            Response.Redirect("/Customer/Customer.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Session["CustomerPKID"].ToString() != "")
            {
                Response.Redirect("/Customer/Customer.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["CustomerPKID"].ToString() != "" && long.TryParse(Session["CustomerPKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["CustomerPKID"].ToString());
                _customer = new CustomerClass(_PKID);
                _customer.deleteRecord(_PKID);
                Session["CustomerPKID"] = "";
            }
            fillGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvData.SelectedRow;
            Session["CustomerPKID"] = row.Cells[1].Text;
        }
        #endregion
    }
}