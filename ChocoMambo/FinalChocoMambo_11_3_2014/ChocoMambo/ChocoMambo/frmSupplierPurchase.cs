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
        Boolean _blnReadOnly;
        #endregion

        #region Constructors

        public frmSupplierPurchase()
        {
            InitializeComponent();
            _supplierPurchase = new SupplierPurchase();
            populateSupplierCombo();
            populateBranchCombo();
            populateRawIngredientsCombo();
            dgvOrderLines.DataSource = _supplierPurchase.getSupplierLinesTable();
            _blnReadOnly = false;
        }

        public frmSupplierPurchase(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _supplierPurchase = new SupplierPurchase(pLongID);
            _blnReadOnly = pBlnReadOnly;
            populateSupplierCombo();
            populateBranchCombo();
            populateRawIngredientsCombo();
            displayRecord();
            OrganizeMenuButtons();
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
            txtPurchaseCode.Text = _supplierPurchase.PurchaseCode;
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
        }

        #endregion

        #region Mutators

        private void emptySupplierLineControls()
        {
            cboRawIngredients.SelectedIndex = -1;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtLineTotal.Text = string.Empty;
        }

        private void assignChildData()
        {
            _supplierPurchase.SupplierPurchaseLineClass.RawIngredientsID = long.Parse(cboRawIngredients.SelectedValue.ToString());
            _supplierPurchase.SupplierPurchaseLineClass.Price = decimal.Parse(txtPrice.Text.ToString().Substring
                                                          (txtPrice.Text.ToString().IndexOf('$')+1));
            _supplierPurchase.SupplierPurchaseLineClass.SupplierLineQty = long.Parse(txtQuantity.Text);
            _supplierPurchase.SupplierPurchaseLineClass.SupplierLineSubTotal = decimal.Parse(txtLineTotal.Text.ToString().Substring
                                                          (txtLineTotal.Text.ToString().IndexOf('$') + 1));
            _supplierPurchase.SupplierPurchaseLineClass.PurchaseID = _supplierPurchase.PKID;
            _supplierPurchase.SupplierPurchaseLineClass.IngredientName = cboRawIngredients.Text;
        }

        private void calculateGrandTotal()
        {
            try
            {
                decimal decGrandTotal = decimal.Parse(_supplierPurchase.getSupplierLinesTable().Compute
                                                      ("Sum(SupplierLineSubTotal)","").ToString());
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
                decPrice = decimal.Parse(txtPrice.Text.ToString().Substring(txtPrice.Text.ToString().IndexOf('$') + 1));
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
            txtLineTotal.Text = decLineTotal.ToString("c2");
            calculateGrandTotal();
        }

        private void assignData()
        {
            _supplierPurchase.PurchaseCode = txtPurchaseCode.Text;
            _supplierPurchase.BranchID = long.Parse(cboBranch.SelectedValue.ToString());
            _supplierPurchase.DatePurchased = dtpDatePurchased.Value;
            _supplierPurchase.SupplierID = long.Parse(cboSupplier.SelectedValue.ToString());
            _supplierPurchase.PurchaseTotal = decimal.Parse(txtTotalAmount.Text.ToString().Substring
                                              (txtTotalAmount.Text.ToString().IndexOf('$')+1));
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

        public void OrganizeMenuButtons()
        {
            if (_blnReadOnly.Equals(true))
            {
                disableMenuButtons();
            }
            else
            {
                enableMenuButtons();
            }
        }

        private void GenerateOrderCode(string pStrSupplier, string pStrSupplierID,  string pStrBranch)
        {
            txtPurchaseCode.Text = pStrSupplier.ToString() + "_" +pStrSupplierID.ToString() + "_" + pStrBranch.ToString();
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
                if (cboSupplier.SelectedItem != null && cboBranch.SelectedItem != null)
                {
                    if (cbActive.Checked.Equals(true))
                    {
                        OrganizeMenuButtons();
                        mnuInsert.Enabled = false;
                        GenerateOrderCode(cboSupplier.Text, cboSupplier.SelectedValue.ToString(), cboBranch.Text);
                    }
                    else
                    {
                        disableMenuButtons();
                    }
                    mnuInsert.Enabled = false;
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
            if (cboRawIngredients.Text != string.Empty && txtQuantity.Text != string.Empty)
            {
                if (cbActive.Checked.Equals(true))
                {
                    if (_blnReadOnly.Equals(false))
                    {
                        ErrorProvider.Dispose();
                        calculateLineTotal();
                        mnuInsert.Enabled = true;
                    }
                }
            }
            else
            {
                ErrorProvider.SetError(this, "Fields Cannot Be Empty");
            }
        }
        private void cboSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            txtPurchaseCode.Text = String.Empty;
        }

        private void cboBranch_SelectedValueChanged(object sender, EventArgs e)
        {
            txtPurchaseCode.Text = String.Empty;
        }
       
        private void cboRawIngredients_SelectedValueChanged(object sender, EventArgs e)
        {
            RawIngredients _rawIngredients = new RawIngredients(long.Parse(cboRawIngredients.SelectedIndex.ToString()));
                txtPrice.Text = _rawIngredients.Price.ToString();
        }
        #endregion
    }
}
