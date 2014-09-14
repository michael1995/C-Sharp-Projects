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
    public partial class CustomerList1 : System.Web.UI.Page
    {
        Customer _customer;
        DataSet _dataset;
        protected void Page_Load(object sender, EventArgs e)
        {
            _customer = new Customer();
            _dataset = _customer.GetDataSet();
            Session["ID"] = "";
            FillGridView();
        }
        private void FillGridView()
        {
            gv_Customer.DataSource = _dataset;
            gv_Customer.DataMember = _dataset.Tables[0].TableName;
            gv_Customer.DataBind();
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            if (gv_Customer.SelectedIndex > -1)
            {
                Session["ID"] = gv_Customer.SelectedRow.Cells[1].Text;
                Response.Redirect("Customer.aspx");
            }
        }

        protected void btn_newCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer.aspx");
        }
    }
}