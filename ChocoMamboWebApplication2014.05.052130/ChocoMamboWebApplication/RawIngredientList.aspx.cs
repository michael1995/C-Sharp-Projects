using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class RawIngredientList : System.Web.UI.Page
    {
        AppObjects.RawIngredient _rawIngredient;
        DataSet _dataset;
        protected void Page_Load(object sender, EventArgs e)
        {
            _rawIngredient = new AppObjects.RawIngredient();
            _dataset = _rawIngredient.GetDataSet();
            Session["ID"] = "";
            FillGridView();
        }
        private void FillGridView()
        {
            gv_RawIngredient.DataSource = _dataset;
            gv_RawIngredient.DataMember = _dataset.Tables[0].TableName;
            gv_RawIngredient.DataBind();
        }

        protected void btn_newRawIngredient_Click(object sender, EventArgs e)
        {
            Response.Redirect("RawIngredient.aspx");
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            if (gv_RawIngredient.SelectedIndex > -1)
            {
                Session["ID"] = gv_RawIngredient.SelectedRow.Cells[1].Text;
                Response.Redirect("RawIngredient.aspx");
            }
        }

      
    }
}