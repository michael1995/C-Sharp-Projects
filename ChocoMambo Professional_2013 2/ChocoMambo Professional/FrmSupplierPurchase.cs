using ClassErrorCollection;
using DBConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChocoMambo_Professional
{
    public partial class FrmSupplierPurchase : Form
    {
        #region Variable Declaration
        public long _lngPKID = 0; // Set the primary key to zero before we use it 
        SupplierPurchase _supplierPurchase = null;
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb"); // create a new database connection
        DataTable _dtb = new DataTable(); // create a new datatable 
        Boolean _blnReadOnly; // A boolean to determine if the current user permission is read
        ErrorCollection _errorCollection; // create an instance of the error collection class;
        #endregion

        #region Constructor 
        /// <summary>
        /// Create a new supplier Purchase 
        /// </summary>
        public FrmSupplierPurchase()
        {
            InitializeComponent();
            _supplierPurchase = new SupplierPurchase(); // new instance of supplier purchase 

            populateSupplierCombo(); // populate supplier combo box
            populateRawIngredientsCombo(); // populate raw ingredient combo box
            populateBranchCombo(); // populate branch combo box

            dgvPurchaseLines.DataSource = _supplierPurchase.getSupplierLinesTable(); // get the supplier Purchase lines table
            dgvPurchaseLines.Columns[0].Visible = false; // set the columns to invisible
            dgvPurchaseLines.Columns["RawIngredientsID"].Visible = false;
            dgvPurchaseLines.Columns["PurchaseID"].Visible = false;
            dgvPurchaseLines.Columns["IngredientName"].HeaderText = "IngCode";
        }
        /// <summary>
        ///  load the current Purchase by getting the Primary key
        /// Pass a boolean to determine is the User Permission is read only for later use
        /// </summary>
        /// <param name="pLongID"></param>
        /// <param name="pBlnReadOnly"></param>
        public FrmSupplierPurchase(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _supplierPurchase = new SupplierPurchase(pLongID); // make an new instance of Supplier Purchase
          
            populateSupplierCombo(); // populate supplier combo box
            populateRawIngredientsCombo(); // populate raw ingredient combo box
            populateBranchCombo(); // populate branch combo box

            dgvPurchaseLines.DataSource = _supplierPurchase.getSupplierLinesTable(); // get the supplier Purchase lines table
            dgvPurchaseLines.Columns[0].Visible = false; // set the columns to invisible
            dgvPurchaseLines.Columns["RawIngredientsID"].Visible = false;
            dgvPurchaseLines.Columns["PurchaseID"].Visible = false;
            dgvPurchaseLines.Columns["IngredientName"].HeaderText = "IngCode";

            displayRecord();  // display the current record


            _lngPKID = pLongID; // pass the parameter value of the Primary Key to the global Variable
            _blnReadOnly = pBlnReadOnly; // give the global boolean value the value of the parameter value
             

            organizeFormForReadOnly(); // organize the form fields after we get the read only value
            mnuDeletePurchase.Enabled = true;
        } 

        #endregion 

        #region Accessors
        /// <summary>
        /// display the current record
        /// </summary>
        private void displayRecord()
        {
            cboSupplier.SelectedValue = _supplierPurchase.SupplierID;
            cboBranch.SelectedValue = _supplierPurchase.BranchID;
            dtpDatePurchased.Value = _supplierPurchase.DatePurchased;
            txtTotalAmount.Text = _supplierPurchase.PurchaseTotal.ToString("c2");
            dgvPurchaseLines.DataSource = _supplierPurchase.getSupplierLinesTable();
            txtPurchaseCode.Text = _supplierPurchase.PurchaseCode;
        }

        /// <summary>
        /// populate the supplier combo box and display the suuplier name but value the SupplierID
        /// </summary>
        private void populateSupplierCombo()
        {
            cboSupplier.DataSource = _supplierPurchase.getSupplier();
            cboSupplier.DisplayMember = "SupplierName";
            cboSupplier.ValueMember = "SupplierID";
            cboSupplier.SelectedIndex = -1;
        }
        /// <summary>
        /// populate the branch combo box and display the branch office but value the BranchID
        /// </summary>
        private void populateBranchCombo()
        {
            cboBranch.DataSource = _supplierPurchase.getBranch();
            cboBranch.DisplayMember = "BranchOffice";
            cboBranch.ValueMember = "BranchID";
            cboBranch.SelectedIndex = -1;
        }
        /// <summary>
        /// populate the raw ingredient combo box and display the second column[1] but value the first column[0]
        /// </summary>
        private void populateRawIngredientsCombo()
        {
            _dtb = _dbConn.GetDataTable("tblRawIngredients");
            cboRawIngredients.DataSource = _dtb;
            cboRawIngredients.DisplayMember = _dtb.Columns[1].ToString();
            cboRawIngredients.ValueMember = _dtb.Columns[0].ToString();
            cboRawIngredients.SelectedIndex = -1;
        }
        #endregion

        #region Mutators 
        /// <summary>
        /// empty the raw ingredients controls 
        /// </summary>
        private void emptyRawIngredientControls()
        {
            cboRawIngredients.SelectedIndex = -1;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtLineTotal.Text = string.Empty;
        }

        private void assignChildData()
        {
            // assign the values to the variables to be used for calculations
            _supplierPurchase.SupplierPurchaseLineClass.RawIngredientsID = long.Parse(cboRawIngredients.SelectedValue.ToString());
            _supplierPurchase.SupplierPurchaseLineClass.Price = decimal.Parse(txtPrice.Text.ToString().Substring
                                                          (txtPrice.Text.ToString().IndexOf('$') + 1));
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
        /// <summary>
        /// Assign the class properties to the text field values
        /// </summary>
        private void assignData()
        {
            _supplierPurchase.PurchaseCode = txtPurchaseCode.Text;
            _supplierPurchase.BranchID = long.Parse(cboBranch.SelectedValue.ToString());
            _supplierPurchase.DatePurchased = dtpDatePurchased.Value;
            _supplierPurchase.SupplierID = long.Parse(cboSupplier.SelectedValue.ToString());
            _supplierPurchase.PurchaseTotal = decimal.Parse(txtTotalAmount.Text.ToString().Substring
                                              (txtTotalAmount.Text.ToString().IndexOf('$') + 1));
        }
        /// <summary>
        /// pass the current key press event to this method to validate that field to only allow number and back space inputs
        /// </summary>
        /// <param name="e"></param>
        public void validateTextFieldsToNumbersOnly(KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
                if (e.KeyChar != (char)8)
                    e.KeyChar = (char)0;
        }
        /// <summary>
        /// Organize the form when the Users permission is read only or not read only.
        /// </summary>
        public void organizeFormForReadOnly()
        {
            if (_blnReadOnly.Equals(true))
            {
                grpSupplierPurchaseLine.Enabled = false;
                groupBox1.Enabled = false; groupBox2.Enabled = false; groupBox3.Enabled = false;
                mnuInsert.Enabled = false; mnuSave.Enabled = false; mnuDeleteLine.Enabled = false;
                mnuDeletePurchase.Enabled = false;
            }
            else
            {
                grpSupplierPurchaseLine.Enabled = true;
                groupBox1.Enabled = true; groupBox2.Enabled = true; groupBox3.Enabled = true;
                mnuInsert.Enabled = true; mnuSave.Enabled = true; mnuDeleteLine.Enabled = true;
                mnuDeletePurchase.Enabled = false;
            }
        }

        #endregion 
        
        #region Control Events

        private void mnuSave_Click(object sender, EventArgs e)
        {
            // if the data grid is not empty / is not less then 0. 
            // we increment this variable in the exisiting Order Constructor
            // or when you click insert
            if (dgvPurchaseLines.Rows.Count > 1)
            {
                ErrorProvider.Dispose(); // assign the values in the fields of this form the class properties
                assignData(); // assign the data
                _supplierPurchase.saveData(); // save the order record 
                _supplierPurchase.SupplierPurchaseLineClass.saveData(); // save the order line record
                this.Close(); // close after a successfull save
            }
            else
            {
                // if the data grid is empty 
                mnuSave.Enabled = false;
                ErrorProvider.SetError(this, "Can't Save if the OrderLine is Empty");
            } 
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
            try
            {
                assignChildData(); // assign the child data to the class properties 
                _supplierPurchase.SupplierPurchaseLineClass.addNewRecord(); // add a new supplier purchase line record
                dgvPurchaseLines.Refresh(); // refresh the datagrid view
                calculateGrandTotal(); // calculate the total
                emptyRawIngredientControls();
                // if the combo boxes selected items arent null
                if (cboSupplier.SelectedItem != null && cboBranch.Text != string.Empty)
                {
                    mnuInsert.Enabled = false; mnuSave.Enabled = true; mnuDeleteLine.Enabled = true;
                    // generate a code for the purhcase code by passing values from these two text boxes
                    txtPurchaseCode.Text = cboSupplier.Text + "_" + cboBranch.Text;
                }
                else
                {
                    mnuInsert.Enabled = false;
                }
                mnuInsert.Enabled = false;
            }
            catch (NullReferenceException ex)
            {
                _errorCollection = new ErrorCollection(ex.Message.ToString()); // write the error message to the file 
                _errorCollection.writeToFile(); // write to the error log by passing the exception 
            }
        }

        private void mnuDeleteLine_Click(object sender, EventArgs e)
        {
            // if the data grid isnt empty 
            if (dgvPurchaseLines.Rows.Count > 1)
            {
                if (dgvPurchaseLines["PurchaseID", dgvPurchaseLines.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected record?",
                              "ChocoMambo", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _supplierPurchase.SupplierPurchaseLineClass.deleteSupplierLine(long.Parse(dgvPurchaseLines["PurchaseLineID",
                                    dgvPurchaseLines.CurrentCell.RowIndex].Value.ToString())); // delete the order line by grabing the PurchaseLineID
                        calculateGrandTotal(); // calculate the total 
                        ErrorProvider.Dispose(); // dispose of the error message
                    }
                }
            } else {
                mnuDeleteLine.Enabled = false;
                ErrorProvider.SetError(this, "Can't Delete if the PurchaseLine is Empty");
            }
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextFieldsToNumbersOnly(e); // pass the current key press event to the method to vaildate this field 
        }


        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            // if the comb boxes and text fields are empty 
            if (cboSupplier.Text != string.Empty && cboBranch.Text != string.Empty)
            {
                if (cboRawIngredients.Text != string.Empty && txtQuantity.Text != string.Empty)
                {
                    calculateLineTotal(); // caclualte the total 
                        mnuInsert.Enabled = true;
                }
            }
        }

        private void cboRawIngredients_TextChanged(object sender, EventArgs e)
        {
            DataTable dtbTableData = _dbConn.GetDataTable("tblRawIngredients");
            // grab all the data rows in the table 
            foreach (DataRow drw in dtbTableData.Rows)
            {
                if (cboRawIngredients.Text.Equals(drw["IngCode"].ToString()))
                {
                    // if the value in the combo box below matches any of the ProductNames
                    // then fill the text field with the current price of that product
                    txtPrice.Text = drw["Price"].ToString();
                }
            }
        }

        private void mnuDeletePurchase_Click(object sender, EventArgs e)
        {
            // if the datagrid view has valid values from the database.
            if (dgvPurchaseLines.Rows.Count > 1)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected record?",
                          "ChocoMambo", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // get all the datarows and delete them if they have a valid PurchaseLine id 
                    foreach (DataGridViewRow row in dgvPurchaseLines.Rows)
                    {
                        _supplierPurchase.SupplierPurchaseLineClass.deleteSupplierLine(long.Parse(dgvPurchaseLines["PurchaseLineID",
                                    dgvPurchaseLines.CurrentCell.RowIndex].Value.ToString())); // delete the order line by grabing the OrderLineID
                        _supplierPurchase.SupplierPurchaseLineClass.saveData();
                    }
                }
            }
            else
            {
                // push back to the table to accept the changes before we delete the purchase
                _supplierPurchase.SupplierPurchaseLineClass.saveData();
                _supplierPurchase.delete(_lngPKID); // delete the order after everthing has been deleted
                this.Close();
            }
        }
        #endregion
    }
}
