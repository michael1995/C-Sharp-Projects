using ChocoMamboWebApplication.AppObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class ProductList : System.Web.UI.Page
    {
        AppObjects.Product _product;
        DataSet _dataset;
        protected void Page_Load(object sender, EventArgs e)
        {
            _product = new AppObjects.Product();
            _dataset = _product.GetDataSet();
            Session["ID"] = "";
            FillGridView();
        }


        private void FillGridView()
        {
            gv_Product.DataSource = _dataset;
            gv_Product.DataMember = _dataset.Tables[0].TableName;
            gv_Product.DataBind();
        }
        protected void btn_newProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx");
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            if (gv_Product.SelectedIndex > -1)
            {
                Session["ID"] = gv_Product.SelectedRow.Cells[1].Text;
                Response.Redirect("Product.aspx");
            }
        }
    }
}