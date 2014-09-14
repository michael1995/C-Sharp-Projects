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
    public partial class Sale : System.Web.UI.Page
    {
        #region Class Variables
        AppObjects.Sale _sale;
        AppObjects.Product _product;
        AppObjects.Customer _customer;
        long _pkID=0;
        #endregion

        private void InitializePage()
        {

            if (!Page.IsPostBack)
            {
                Session["Sale"] = _sale = new AppObjects.Sale();
                loadDropDownLists();
                AssignDataToFields();
            }
            _sale = (AppObjects.Sale)Session["Sale"];
            refreshGridView();
           
        }
        private void InitializePage(long pLongID)
        {
           
            if (!Page.IsPostBack)
            {
                Session["Sale"] = _sale = new AppObjects.Sale(pLongID,false);
                loadDropDownLists();
                AssignDataToFields();
            }
            _sale = (AppObjects.Sale)Session["Sale"];
            refreshGridView();
        }

        private void AssignDataToFields()
        {
            dd_Customer.SelectedValue = _sale.CustomerNumber.ToString();
            c_SaleDate.SelectedDate = _sale.SaleDate;
            txt_SaleTotal.Text = _sale.SaleTotal.ToString();
            dd_salesManagers.SelectedValue = _sale.SaleMananger.ToString();
            txt_ShippingAddress.Text = _sale.SaleShippingAddress;

        }
        private void refreshGridView()
        {
            gv_SaleLines.DataSource = _sale.getSaleLinesTable();
            gv_SaleLines.DataMember = _sale.getSaleLinesTable().TableName;
            gv_SaleLines.DataBind();
        }



        private void loadDropDownLists()
        {
            PopulateDropDownList(dd_Customer, _sale.getCustomers(), "ContactName", "ID");
            PopulateDropDownList(dd_Product, _sale.getProducts(), "ProductName", "ID");
            PopulateDropDownList(dd_salesManagers, _sale.getSaleReps(), "EmployeeName", "ID");
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
        private void PopulateDropDownList(DropDownList ddlist,DataTable pDataTable,String pstrDataMember,String pstrDataValueField)
        {
            ddlist.DataSource = pDataTable;
            ddlist.DataTextField = pstrDataMember;
            ddlist.DataValueField = pstrDataValueField;
            ddlist.DataBind();
        }
       
        #endregion

        protected void btn_addToSale_Click(object sender, EventArgs e)
        {
            assignChildData();
            _sale.SaleLineClass.addNewRecord();
            UpdateSession();
            InitializePage(_pkID);
            txt_SaleTotal.Text = SaleTotal().ToString();
            
            
        }
        private void UpdateSession()
        {
            Session["Sale"] = _sale;
            DataSet ds = _sale.GetDataSet();
            
        }
        protected void dd_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            _product = new AppObjects.Product(long.Parse( dd_Product.SelectedValue));
            txt_Price.Text = _product.Price.ToString();
            Session["Product"] = _product;
            

        }

        #region Mutators

        /// <summary>
        ///Pre-Condition:Textboxes are checked for correct format
        ///Post-Condition:Child data associated with current record is assigned
        ///Description:Sets Assigns child data associated with current record
        /// </summary>
        private void assignChildData()
        {
            _product = (AppObjects.Product)Session["Product"];
            _sale.SaleLineClass.SaleNumber = _sale.PKID;
            _sale.SaleLineClass.ProductNumber = long.Parse(dd_Product.SelectedValue.ToString());
            _sale.SaleLineClass.productCode = _product.Code;
            _sale.SaleLineClass.ProductName = dd_Product.SelectedItem.ToString();
            _sale.SaleLineClass.ProductPrice = decimal.Parse(txt_Price.Text);
            _sale.SaleLineClass.SaleLineQty = long.Parse(txt_Qty.Text);
            _sale.SaleLineClass.SaleLineSubTotal = Decimal.Parse(txt_Qty.Text) * Decimal.Parse(txt_Price.Text);
        }
        #endregion

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            save();
            Response.Redirect("SaleList.aspx");
        }
        private void save()
        {
            assignData();
            _sale.saveData();
            _sale.SaleLineClass.saveData();
        }
        private void assignData()
        {
            _sale.SaleDate = c_SaleDate.SelectedDate;
            _sale.SaleShippingDate = c_SaleDate.SelectedDate;
            _sale.CustomerNumber = long.Parse(dd_Customer.SelectedValue.ToString());
            _sale.SaleShippingAddress = txt_ShippingAddress.Text;
            _sale.SaleTotal = decimal.Parse(txt_SaleTotal.Text);
            _sale.SaleMananger = long.Parse(dd_salesManagers.SelectedValue.ToString());
        }

        protected void gv_SaleLines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteSaleLine")
            {
                _sale.SaleLineClass.deleteSaleLine(long.Parse(gv_SaleLines.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text));
                UpdateSession();
                InitializePage(_pkID);
            }
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            _sale.deleteSale(_pkID);
            _sale.SaleLineClass.saveData();
            save();
            Response.Redirect("SaleList.aspx");
        }

        protected void dd_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Customer"] = _customer = new AppObjects.Customer(long.Parse(dd_Customer.SelectedValue));
            txt_ShippingAddress.Text = GetAddress();
        }
        private string GetAddress()
        {
            return _customer.BuildingNumber + " " + _customer.StreetName + " " + _customer.Suburb + " " + _customer.State + " " + _customer.Postcode;
        }
        private decimal SaleTotal()
        {
            return Decimal.Parse(_sale.getSaleLinesTable().Compute("Sum(SaleLineTotal)", "").ToString());

        }
    }
}