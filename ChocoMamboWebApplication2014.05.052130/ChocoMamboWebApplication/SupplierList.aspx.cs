
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocoMamboWebApplication.AppObjects;

namespace ChocoMamboWebApplication
{
    public partial class SupplierList : System.Web.UI.Page
    {
        AppObjects.Supplier _supplier;
        DataSet _dataset;
       
        private void FillGridView()
        {
            gv_Supplier.DataSource = _dataset;
            gv_Supplier.DataMember = _dataset.Tables[0].TableName;
            gv_Supplier.DataBind();
        }

       
        protected void Page_Load(object sender, EventArgs e)
        {
            _supplier = new AppObjects.Supplier();
            _dataset = _supplier.GetDataSet();
            Session["ID"] = "";
            FillGridView();
        }

        protected void btn_newSupplier_Click(object sender, EventArgs e)
        {
            Response.Redirect("Supplier.aspx");
        }

        protected void btn_Edit_Click1(object sender, EventArgs e)
        {
            if (gv_Supplier.SelectedIndex > -1)
            {
                Session["ID"] = gv_Supplier.SelectedRow.Cells[1].Text;
                Response.Redirect("Supplier.aspx");
            }
        }
    }
}