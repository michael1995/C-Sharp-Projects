using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class OrderList : System.Web.UI.Page
    {
        AppObjects.Order _order;
        DataSet _dataset;
        protected void Page_Load(object sender, EventArgs e)
        {
            _order = new AppObjects.Order();
            _dataset = _order.GetDataSet();
            Session["ID"] = "";
            FillGridView();
            
        }
        private void FillGridView()
        {
            gv_Order.DataSource = _dataset;
            gv_Order.DataMember = _dataset.Tables[0].TableName;
            gv_Order.DataBind();
        }

        protected void btn_newOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("Order.aspx");
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            if (gv_Order.SelectedIndex > -1)
            {
                Session["ID"] = gv_Order.SelectedRow.Cells[1].Text;
                Response.Redirect("Order.aspx");
            }
        }
    }
}