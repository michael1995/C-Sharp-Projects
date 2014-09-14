using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class SaleList : System.Web.UI.Page
    {
        AppObjects.Sale _sale;
        DataSet _dataset;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _sale = new AppObjects.Sale();
            _dataset = _sale.GetDataSet();
            Session["ID"] = "";
            FillGridView();
            
        }
        private void FillGridView()
        {
            gv_Sale.DataSource = _dataset;
            gv_Sale.DataMember = _dataset.Tables[0].TableName;
            gv_Sale.DataBind();
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            if (gv_Sale.SelectedIndex > -1)
            {
                Session["ID"] = gv_Sale.SelectedRow.Cells[1].Text;
                Response.Redirect("Sale.aspx");
            }
        }

        protected void btn_newSale_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sale.aspx");
        }
    }
}