using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo.Purchase
{
    public partial class Purchase1 : System.Web.UI.UserControl
    {

        #region Variable Declaration

        PurchaseClass _purchase = null;
        long _PKID = 0;
        dbConnection _dbConn = new dbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        #endregion

        #region Accessor

        /// <summary>
        /// display the current record
        /// </summary>
        private void displayRecord()
        {
            cboSupplier.SelectedValue = _purchase.SupplierID.ToString();
            cboBranch.SelectedValue = _purchase.BranchID.ToString();
            dtpDatePurchased.Text = _purchase.DatePurchased;
            txtTotalAmount.Text = _purchase.PurchaseTotal.ToString("c2");
            gvPurchaseLines.DataSource = _purchase.getPurchaseLinesTable();
            txtPurchaseCode.Text = _purchase.PurchaseCode;
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
            PopulateDropDownList(cboSupplier, _purchase.getSupplier(), "SupplierName", "SupplierID");
            PopulateDropDownList(cboBranch, _purchase.getBranch(), "BranchOffice", "BranchID");
            PopulateDropDownList(cboRawIngredients, _purchase.getRawIngredients(), "IngredientName", "RawIngredientsID");
        }

        #endregion

        #region Mutator

        private void assignChildData()
        {
            // assign the values to the variables to be used for calculations
            _purchase.PurchaseLineClass.RawIngredientsID = long.Parse(cboRawIngredients.SelectedValue.ToString());
            _purchase.PurchaseLineClass.Price = decimal.Parse(txtPrice.Text.ToString().Substring
                                                          (txtPrice.Text.ToString().IndexOf('$') + 1));
            _purchase.PurchaseLineClass.SupplierLineQty = long.Parse(txtQuantity.Text);
            _purchase.PurchaseLineClass.SupplierLineSubTotal = LineTotal();
            _purchase.PurchaseLineClass.PurchaseID = _purchase.PKID;
            _purchase.PurchaseLineClass.IngredientName = cboRawIngredients.SelectedItem.Text;
        }

        /// <summary>
        /// Assign the class properties to the text field values
        /// </summary>
        private void assignData()
        {
            _purchase.PurchaseCode = txtPurchaseCode.Text;
            _purchase.BranchID = long.Parse(cboBranch.SelectedValue.ToString());
            _purchase.DatePurchased = dtpDatePurchased.Text;
            _purchase.SupplierID = long.Parse(cboSupplier.SelectedValue.ToString());
            _purchase.PurchaseTotal = decimal.Parse(txtTotalAmount.Text.ToString().Substring
                                              (txtTotalAmount.Text.ToString().IndexOf('$') + 1));
        }

        private void reloadGridView()
        {
            gvPurchaseLines.DataSource = _purchase.getPurchaseLinesTable();
            gvPurchaseLines.DataBind();
        }

        private decimal OrderTotal()
        {
            return decimal.Parse(_purchase.getPurchaseLinesTable().Compute
                                                      ("Sum(SupplierLineSubTotal)", "").ToString());
        }

        private void displayOrderTotal()
        {
            if (isGridViewEmpty(gvPurchaseLines) == true)
                txtTotalAmount.Text = "0";
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
            _purchase.saveData();
            _purchase.PurchaseLineClass.saveData();
        }

        private void clearSession()
        {
            Session["PurchasePKID"] = "";
        }

        private void saveSession()
        {
            Session["Purchase"] = _purchase;

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

        #region Control Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PurchasePKID"].ToString() != "" && long.TryParse(Session["PurchasePKID"].ToString(), out _PKID))
            {
                _PKID = long.Parse(Session["PurchasePKID"].ToString());
                if (!Page.IsPostBack)
                {
                    Session["Purchase"] = _purchase = new PurchaseClass(_PKID);
                    displayRecord();
                    PopulateDropDownList();
                }
                _purchase = (PurchaseClass)Session["Purchase"];
                reloadGridView();
                btnDeleteOrder.Enabled = true;
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    Session["Purchase"] = _purchase = new PurchaseClass();
                    PopulateDropDownList();
                }
                _purchase = (PurchaseClass)Session["Purchase"];
                reloadGridView();
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            save();
            clearSession();
            Response.Redirect("/Purchase/PurchaseList.aspx");
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            if (isCurrentTextFieldNotEmpty(txtPrice) && isCurrentTextFieldNotEmpty(txtQuantity))
            {
                txtLineTotal.Text = LineTotal().ToString("c2");
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (isCurrentTextFieldNotEmpty(txtLineTotal))
            {
                assignChildData(); // assign the child data to the class properties 
                _purchase.PurchaseLineClass.addNewRecord(); // add a new order line record

                saveSession();
                reloadGridView();

                displayOrderTotal();
                txtPurchaseCode.Text = cboBranch.SelectedItem.Text;
            }
        }

        protected void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (isGridViewEmpty(gvPurchaseLines) == true)
            {
                _PKID = long.Parse(Session["PurchasePKID"].ToString());

                save();

                _purchase.deleteRecord(_PKID);
                Response.Redirect("/Purchase/PurchaseList.aspx");
            }
        }

        protected void cboRawIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CurrentIngredient"] = cboRawIngredients.SelectedItem.Text;
            DataTable dtbTableData = _purchase.getRawIngredients();
            // grab all the data rows in the table 
            foreach (DataRow drw in dtbTableData.Rows)
            {
                // if the value in the combo box below matches any of the ProductNames
                // then fill the text field with the current price of that product
                if (Session["CurrentIngredient"].Equals(drw["IngredientName"].ToString()))
                {
                    txtPrice.Text = drw["Price"].ToString();
                }
            }
        }

        protected void gvPurchaseLines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deletePurchaseLine")
            {
                _purchase.PurchaseLineClass.deletePurchaseLine(long.Parse(gvPurchaseLines.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text));
                reloadGridView();
                displayOrderTotal();
            }
        }
        #endregion
    }
}