using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Order
{
    public partial class Order1 : System.Web.UI.UserControl
    {

        #region Variable Declaration

        OrderClass _order = null;
        long _PKID = 0;
        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        #endregion

        #region Accessor

        /// <summary>
        /// display the current record
        /// </summary>
        private void displayRecord()
        {
            cboCustomer.SelectedValue = _order.CustomerID.ToString();
            dtpOrderDate.Text = _order.OrderDate.ToString();
            dtpShipDate.Text = _order.OrderShippingDate.ToString();
            txtShipAddress.Text = _order.OrderShippingAddress;
            txtTotalAmount.Text = _order.OrderTotal.ToString("c2");
            gvOrderLines.DataSource = _order.getOrderLinesTable();
            txtOrderName.Text = _order.OrderName;
        }

        private void PopulateDropDownList(DropDownList pdlist, DataTable pDataTable, String pstrDataMember, String pstrDataValueField)
        {
            pdlist.DataSource = pDataTable;
            pdlist.DataTextField = pstrDataMember;
            pdlist.DataValueField = pstrDataValueField;
            pdlist.DataBind();
        }

        private void PopulateDropDownList()
        {
            PopulateDropDownList(cboCustomer, _order.getCustomers(), "CustomerName", "CustomerID");
            PopulateDropDownList(cboProduct, _order.getProduct(), "ProductName", "ProductID");
        }

        #endregion

        #region Mutator

        private void assignChildData()
        {
            // assign the values to the variables to be used for calculations
            _order.OrderLineClass.ProductID = long.Parse(cboProduct.SelectedValue.ToString());
            _order.OrderLineClass.OrderLineQty = long.Parse(txtQuantity.Text);
            _order.OrderLineClass.ProductPrice = decimal.Parse(txtPrice.Text.ToString().Substring
                                                          (txtPrice.Text.ToString().IndexOf('$') + 1));
            _order.OrderLineClass.OrderNumber = _order.PKID;
            _order.OrderLineClass.OrderLineSubTotal = LineTotal();
            _order.OrderLineClass.ProductName = cboProduct.SelectedItem.Text;
        }

        /// <summary>
        /// Assign the class properties to the text field values 
        /// </summary>
        private void assignData()
        {
            _order.OrderName = txtOrderName.Text;
            _order.CustomerID = long.Parse(cboCustomer.SelectedValue.ToString());
            _order.OrderDate = dtpOrderDate.Text;
            _order.OrderShippingDate = dtpShipDate.Text;
            _order.OrderShippingAddress = txtShipAddress.Text;
            _order.OrderTotal = decimal.Parse(txtTotalAmount.Text.Substring
                                              (txtTotalAmount.Text.IndexOf('$') + 1));
        }

        private void reloadGridView()
        {
            gvOrderLines.DataSource = _order.getOrderLinesTable();
            gvOrderLines.DataBind();
        }

        private decimal OrderTotal()
        {
            return Decimal.Parse(_order.getOrderLinesTable().Compute("Sum(OrderLineSubTotal)", "").ToString());
        }

        private void displayOrderTotal()
        {
            if (isGridViewEmpty(gvOrderLines) == true)
                txtTotalAmount.Text =   "0";
            else
                txtTotalAmount.Text = OrderTotal().ToString("c2");
        }

        private decimal LineTotal()
        {
            int intQty = int.Parse(txtQuantity.Text);
            decimal decPrice = decimal.Parse(txtPrice.Text.ToString().Substring(txtPrice.Text.ToString().IndexOf('$') + 1));

            return decPrice * intQty;
        }

        private void save()
        {
            assignData();
            _order.saveData();
            _order.OrderLineClass.saveData();
        }

        private void clearSession()
        {
            Session["OrderPKID"] = "";
        }

        private void saveSession()
        {
            Session["Order"] = _order;

        }

        private Boolean isGridViewEmpty(GridView pgvTemp)
        {
            if (pgvTemp.Rows.Count == 0)
                return true;
            else
                return false;
        }

        private Boolean isCurrentTextFieldNotEmpty(TextBox ptxtTemp)
        {
            Boolean blnTemp;
            if (ptxtTemp.Text != string.Empty)
                blnTemp = true;
            else
                blnTemp = false;

            return blnTemp;
        }

        #endregion 

        #region Control Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrderPKID"].ToString() != "" && long.TryParse(Session["OrderPKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["OrderPKID"].ToString());
                if (!Page.IsPostBack)
                {
                    Session["Order"] = _order = new OrderClass(_PKID);
                    displayRecord();
                    PopulateDropDownList();
                }
                _order = (OrderClass)Session["Order"];
                reloadGridView();
                btnDeleteOrder.Enabled = true;
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    Session["Order"] = _order = new OrderClass();
                    PopulateDropDownList();
                }
                _order = (OrderClass)Session["Order"];
                reloadGridView();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            save();
            clearSession();
            Response.Redirect("/Order/OrderList.aspx");
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (isCurrentTextFieldNotEmpty(txtLineTotal))
            {
                assignChildData(); // assign the child data to the class properties 
                _order.OrderLineClass.addNewRecord(); // add a new order line record

                saveSession();
                reloadGridView();

                displayOrderTotal();
                txtOrderName.Text = cboCustomer.SelectedItem.Text;
            }
        }

        protected void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (isGridViewEmpty(gvOrderLines) == true)
            {
                _PKID = long.Parse(Session["OrderPKID"].ToString());

                save();

                _order.deleteRecord(_PKID);
                Response.Redirect("/Order/OrderList.aspx");
            }
        }

        protected void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CurrentProduct"] = cboProduct.SelectedItem.Text;
            DataTable dtbTableData = _order.getProduct();
            // grab all the data rows in the table 
            foreach (DataRow drw in dtbTableData.Rows)
            {
                // if the value in the combo box below matches any of the ProductNames
                // then fill the text field with the current price of that product
                if (Session["CurrentProduct"].Equals(drw["ProductName"].ToString()))
                {
                    txtPrice.Text = drw["Price"].ToString();
                }
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            if (isCurrentTextFieldNotEmpty(txtPrice) && isCurrentTextFieldNotEmpty(txtQuantity))
            {
                txtLineTotal.Text = LineTotal().ToString("c2");
            }
        }

        protected void gvOrderLines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteOrderLine")
            {
                _order.OrderLineClass.deleteOrderLine(long.Parse(gvOrderLines.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text));
                reloadGridView();
                displayOrderTotal();
            }
        }
        #endregion 
    }
}