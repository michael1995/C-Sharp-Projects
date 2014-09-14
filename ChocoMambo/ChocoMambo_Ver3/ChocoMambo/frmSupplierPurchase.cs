using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChocoMambo
{
    public partial class frmSupplierPurchase : Form
    {
        #region Instance Variables
        SupplierPurchase _supplierPurchase = null;      
        #endregion

        #region Constructors

        public frmSupplierPurchase()
        {
            InitializeComponent();
            _supplierPurchase = new SupplierPurchase();
            populateSupplierCombo();
            populateBranchCombo();
            populateRawIngredientsCombo();
            populateRawIngredientsPriceCombo();
            dgvOrderLines.DataSource = _supplierPurchase.getSupplierLinesTable();
        }

        public frmSupplierPurchase(long pLongID)
        {
            InitializeComponent();
            _supplierPurchase = new SupplierPurchase(pLongID);
            populateSupplierCombo();
            populateBranchCombo();
            populateRawIngredientsCombo();
            populateRawIngredientsPriceCombo();
            enableMenuButtons();
            displayRecord();
        }

        #endregion

        #region Accessors

        private void displayRecord()
        {
            cboSupplier.SelectedValue = _supplierPurchase.SupplierID;
            cboBranch.SelectedValue = _supplierPurchase.BranchID;
            dtpDatePurchased.Value = _supplierPurchase.DatePurchased;
            txtTotalAmount.Text = _supplierPurchase.PurchaseTotal.ToString("c2");
            dgvOrderLines.DataSource = _supplierPurchase.getSupplierLinesTable();
            cbActive.Checked = _supplierPurchase.Active;
        }

        private void populateSupplierCombo()
        {
            cboSupplier.DataSource = _supplierPurchase.getSupplier();
            cboSupplier.DisplayMember = "SupplierName";
            cboSupplier.ValueMember = "SupplierID";
            cboSupplier.SelectedIndex = -1; //will make the combo box select nothing
        }

        private void populateBranchCombo()
        {
            cboBranch.DataSource = _supplierPurchase.getBranch();
            cboBranch.DisplayMember = "BranchOffice";
            cboBranch.ValueMember = "BranchID";
            cboBranch.SelectedIndex = -1; //will make the combo box select nothing
        }

        private void populateRawIngredientsCombo()
        {
            cboRawIngredients.DataSource = _supplierPurchase.getRawIngredients();
            cboRawIngredients.DisplayMember = "IngredientName";
            cboRawIngredients.ValueMember = "RawIngredientsID";
            cboRawIngredients.SelectedIndex = -1;
        }

        private void populateRawIngredientsPriceCombo()
        {
            cboPrice.DataSource = _supplierPurchase.getRawIngredients();
            cboPrice.DisplayMember = "Price";
            cboPrice.ValueMember = "Price";
            cboPrice.SelectedIndex = -1;
        }

        private void displayGridRecord()
        {
            // assign the values to the variables to be used for calculations
            decimal decPrice = decimal.Parse(dgvOrderLines["Price",
                                             dgvOrderLines.CurrentCell.RowIndex].Value.ToString());
            int intQty = int.Parse(dgvOrderLines["SupplierLineQty",
                                   dgvOrderLines.CurrentCell.RowIndex].Value.ToString());

            cboRawIngredients.SelectedValue = long.Parse(dgvOrderLines["RawIngredientsID",
                                             dgvOrderLines.CurrentCell.RowIndex].Value.ToString());
            cboPrice.SelectedValue = decPrice.ToString("c2");
            txtQuantity.Text = intQty.ToString();
            decimal decLineTotal = decPrice * intQty;
            txtQuantity.Text = decLineTotal.ToString("c2");
            _supplierPurchase.SupplierPurchaseLineClass.PKID = long.Parse(dgvOrderLines["PurchaseLineID",
                                             dgvOrderLines.CurrentCell.RowIndex].Value.ToString());
        }

        #endregion

        #region Mutators

        private void emptySupplierLineControls()
        {
            cboRawIngredients.SelectedIndex = -1;
            cboPrice.SelectedIndex = -1;
            txtQuantity.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }

        private void assignChildData()
        {
            _supplierPurchase.SupplierPurchaseLineClass.RawIngredientsID = long.Parse(cboRawIngredients.SelectedValue.ToString());
            _supplierPurchase.SupplierPurchaseLineClass.Price = decimal.Parse(cboPrice.SelectedValue.ToString().Substring
                                                          (cboPrice.SelectedValue.ToString().IndexOf('$') + 1));
            _supplierPurchase.SupplierPurchaseLineClass.SupplierLineQty = long.Parse(txtQuantity.Text);
            _supplierPurchase.SupplierPurchaseLineClass.SupplierLineSubTotal = decimal.Parse(txtQuantity.Text.Substring
                                                          (txtQuantity.Text.IndexOf('$') + 1));
            _supplierPurchase.SupplierPurchaseLineClass.PurchaseID = _supplierPurchase.PKID;
            _supplierPurchase.SupplierPurchaseLineClass.IngredientName = cboRawIngredients.Text;
        }

        private void calculateGrandTotal()
        {
            try
            {
                decimal decGrandTotal = decimal.Parse(_supplierPurchase.getSupplierLinesTable().Compute
                                                      ("Sum(SupplierLineSubTotal)", "").ToString());
                txtTotalAmount.Text = decGrandTotal.ToString("c2");
            }
            catch (FormatException)
            {
                //this exception will occur if tblOrderLine is empty which we can safely ignore
            }
        }

        private void calculateLineTotal()
        {
            int intQty = 0;
            decimal decPrice = 0.0M;

            try
            {
                DataRowView drvCost = (DataRowView)cboRawIngredients.SelectedItem;
                intQty = int.Parse(txtQuantity.Text);
                decPrice = decimal.Parse(cboPrice.SelectedValue.ToString().Substring(cboPrice.SelectedValue.ToString().IndexOf('$') + 1));
            }
            catch (FormatException)
            {
                //this exception will occur if txtPrice, txtQuantity, and cboProduct is
                //empty, and which we can safely ignore.
            }
            catch (NullReferenceException)
            {
                //this exception will occur if cboProduct is empty, which we can safely ignore
            }

            decimal decLineTotal = decPrice * intQty;
            txtQuantity.Text = decLineTotal.ToString("c2");
            calculateGrandTotal();  
        }

        private void assignData()
        {
            _supplierPurchase.BranchID = long.Parse(cboBranch.SelectedValue.ToString());
            _supplierPurchase.DatePurchased = dtpDatePurchased.Value;
            _supplierPurchase.SupplierID = long.Parse(cboSupplier.SelectedValue.ToString());
            _supplierPurchase.PurchaseTotal = decimal.Parse(txtTotalAmount.Text.Substring
                                              (txtTotalAmount.Text.IndexOf('$') + 1));
            _supplierPurchase.Active = cbActive.Checked;
        }

        public void disableMenuButtons()
        {
            for (int i = 0; i < 5; i++)
            {
                menuStrip1.Items[i].Enabled = false;
            }
        }

        public void enableMenuButtons()
        {
            for (int i = 0; i < 5; i++)
            {
                menuStrip1.Items[i].Enabled = true;
            }
        }

        #endregion

        #region Control Events

        private void mnuSave_Click(object sender, EventArgs e)
        {
            assignData();
            _supplierPurchase.saveData();
            _supplierPurchase.SupplierPurchaseLineClass.saveData();
            this.Close();
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                assignChildData();
                _supplierPurchase.SupplierPurchaseLineClass.addNewRecord();
                dgvOrderLines.Refresh();
                calculateGrandTotal();
                emptySupplierLineControls();
                if (cboSupplier.SelectedValue.ToString() != "" || dtpDatePurchased.Value != null)
                {
                    if (cboBranch.SelectedValue.ToString() != "" || txtTotalAmount.Text != null)
                    {
                        if (cbActive.Checked.Equals(true))
                        {
                            enableMenuButtons();
                        }
                    }
                }
                else
                {
                    disableMenuButtons();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Invalid operation.\nPlease enter the " +
                                "order items and try again.", "ChocoMambo");

            }
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?",
                          "ChocoMambo", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _supplierPurchase.SupplierPurchaseLineClass.deleteSupplierLine(long.Parse(dgvOrderLines["PurchaseLineID",
                            dgvOrderLines.CurrentCell.RowIndex].Value.ToString()));
                calculateGrandTotal();
                emptySupplierLineControls();
                disableMenuButtons();
            }
        }
        private void mnuDeleteOrder_Click(object sender, EventArgs e)
        {
            if (cbActive.Checked.Equals(true))
            {
                if (MessageBox.Show("Are you sure you want to delete the selected record?",
                              "ChocoMambo", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cbActive.Checked = false;
                    assignData();
                    _supplierPurchase.saveData();
                    _supplierPurchase.SupplierPurchaseLineClass.saveData();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("This Item cannot be Restored, becuase it has not been Deleted!");
            }
        }

      

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (cbActive.Checked.Equals(true))
            {
                calculateLineTotal();
                mnuInsert.Enabled = true;
            }
        }
        #endregion
    }
}
