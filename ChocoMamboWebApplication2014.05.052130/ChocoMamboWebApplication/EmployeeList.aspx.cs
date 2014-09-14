using ChocoMamboWebApplication.AppObjects;
using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class employee : System.Web.UI.Page
    {
        Employee _employee;
        DataSet _dataset;
        protected void Page_Load(object sender, EventArgs e)
        {
            _employee = new Employee();
            _dataset = _employee.GetDataset();
            Session["ID"] = "";
            String jgbej = Session["ID"].ToString();
            FillGridView();
        }

        private void FillGridView()
        {
            gv_Employee.DataSource = _dataset;
            gv_Employee.DataMember = _dataset.Tables[0].TableName;
            gv_Employee.DataBind();
        }

        protected void btn_newEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee.aspx");
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            if (gv_Employee.SelectedIndex > -1)
            {
                Session["ID"] = gv_Employee.SelectedRow.Cells[1].Text;
                Response.Redirect("Employee.aspx");
            }
        }
    }
}