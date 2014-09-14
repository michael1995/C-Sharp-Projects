using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoMamboWebApplication
{
    public partial class OrderLines : System.Web.UI.Page
    {
        #region Class Variables
        AppObjects.Order _order;
        AppObjects.RawIngredient _rawIngredient;
        AppObjects.Supplier _supplier;
        long _pkID = 0;
        #endregion


        private void InitializePage()
        {

            if (!Page.IsPostBack)
            {
                Session["Order"] = _order = new AppObjects.Order();
                loadDropDownLists();
                AssignDataToFields();
            }
            _order = (AppObjects.Order)Session["Order"];
            refreshGridView();

        }
        private void loadDropDownLists()
        {
            PopulateDropDownList(dd_Supplier, _order.getSuppliers(), "ContactName", "ID");
            PopulateDropDownList(dd_Product, _order.getRawIngredients(long.Parse(dd_Supplier.SelectedValue),"tbl_RawIngredients"), "IngName", "ID");
            PopulateDropDownList(dd_branch, _order.getBranch(), "BranchName", "ID");
            
        }
        private void AssignDataToFields()
        {
            dd_Supplier.SelectedValue = _order.SupplierNumber.ToString();
            c_OrderDate.SelectedDate = _order.OrderDate;
            txt_OrderTotal.Text = _order.OrderTotal.ToString();
            dd_branch.SelectedValue = _order.Branch.ToString();
           

        }
        private void refreshGridView()
        {
            gv_OrderLines.DataSource = _order.getOrderLinesTable();
           // gv_OrderLines.DataMember = _sale.getSaleLinesTable().TableName;
            gv_OrderLines.DataBind();
        }

        private void assignData()
        {
            _order.OrderDate = c_OrderDate.SelectedDate;
            _order.OrderExpectedDeliveryDate = c_OrderDate.SelectedDate;
            _order.SupplierNumber = long.Parse(dd_Supplier.SelectedValue.ToString());
           
            _order.OrderTotal = decimal.Parse(txt_OrderTotal.Text);
            _order.Branch = long.Parse(dd_branch.SelectedValue.ToString());
        }
        private void InitializePage(long pLongID)
        {

            if (!Page.IsPostBack)
            {
                Session["Order"] = _order = new AppObjects.Order(pLongID);
                loadDropDownLists();
                AssignDataToFields();
            }
            _order = (AppObjects.Order)Session["Order"];
            refreshGridView();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"].ToString() != "" && long.TryParse(Session["ID"].ToString(), out _pkID))
            {
                _pkID = long.Parse(Session["ID"].ToString());

                InitializePage(_pkID);

            }
            else
                InitializePage();
        }

        #region Accessors
        private void PopulateDropDownList(DropDownList ddlist, DataTable pDataTable, String pstrDataMember, String pstrDataValueField)
        {
            ddlist.DataSource = pDataTable;
            ddlist.DataTextField = pstrDataMember;
            ddlist.DataValueField = pstrDataValueField;
            ddlist.DataBind();
        }

        #endregion

        protected void dd_Supplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dd_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rawIngredient = new AppObjects.RawIngredient(long.Parse(dd_Product.SelectedValue));
            txt_Price.Text = _rawIngredient.Price.ToString();
            Session["RawIngredient"] = _rawIngredient;
        }
        /// <summary>
        ///Pre-Condition:Textboxes are checked for correct format
        ///Post-Condition:Child data associated with current record is assigned
        ///Description:Sets Assigns child data associated with current record
        /// </summary>
        private void assignChildData()
        {
            _order.OrderLineClass.OrderNumber = _order.PKID;
            _order.OrderLineClass.IngNumber = long.Parse(dd_Product.SelectedValue.ToString());
            _order.OrderLineClass.IngPrice = decimal.Parse(txt_Price.Text);
            _order.OrderLineClass.OrderLineQty = long.Parse(txt_Qty.Text);
            _order.OrderLineClass.OrderLineSubTotal = Decimal.Parse(txt_Qty.Text) * Decimal.Parse(txt_Price.Text);
        }
        protected void btn_addToOrder_Click(object sender, EventArgs e)
        {
            assignChildData();
            _order.OrderLineClass.addNewRecord();
            UpdateSession();
            InitializePage(_pkID);
            txt_OrderTotal.Text = OrderTotal().ToString();
        }
        private void UpdateSession()
        {
            Session["Order"] = _order;

        }
        private void save()
        {
            assignData();
            _order.saveData();
            _order.OrderLineClass.saveData();
        }
        private decimal OrderTotal()
        {
            return Decimal.Parse(_order.getOrderLinesTable().Compute("Sum(OrderLineSubTotal)", "").ToString());

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            save();
            Response.Redirect("OrderList.aspx");
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            _order.deleteOrder(_pkID);
            _order.OrderLineClass.saveData();
            save();
            Response.Redirect("OrderList.aspx");
        }
    }
}