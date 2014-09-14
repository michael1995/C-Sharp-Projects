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

    public partial class FrmOrder : Form
    {

        #region Variable Declaration
        public long _lngPKID = 0; // Set the primary key to zero before we use it 
        Order _order = null;
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb"); // create a new database connection 
        DataTable _dtb = new DataTable(); // create a new datatable 
        Boolean _blnReadOnly;  // A boolean to determine if the current user permission is read
        ErrorCollection _errorCollection; // create an instance of the error collection class;
        #endregion

        #region Constructor 
        /// <summary>
        /// Create a new Order
        /// </summary>
        public FrmOrder()
        {
            InitializeComponent();
            _order = new Order(); // make an new instance of Order

            populateCustomerCombo(); // populate customer combo box
            populateProductCombo(); // populate product combo box

            dgvOrderLines.DataSource = _order.getOrderLinesTable(); // get the order lines table
            dgvOrderLines.Columns[0].Visible = false; // set the columns to invisible
            dgvOrderLines.Columns[6].Visible = false;
            dgvOrderLines.Columns["ProductID"].Visible = false;
        }
        /// <summary>
        /// load the current Order by getting the Primary key
        /// Pass a boolean to determine is the User Permission is read only for later use
        /// </summary>
        /// <param name="pLongID"></param>
        /// <param name="pBlnReadOnly"></param>
        public FrmOrder(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _order = new Order(pLongID); // make an new instance of Order
            populateCustomerCombo(); // populate customer combo box
            populateProductCombo(); // populate product combo box

            dgvOrderLines.DataSource = _order.getOrderLinesTable(); // get the order lines table
            dgvOrderLines.Columns[0].Visible = false; // set the columns to invisible
            dgvOrderLines.Columns[6].Visible = false;
            dgvOrderLines.Columns["ProductID"].Visible = false;

            displayRecord(); // display the current record

            _lngPKID = pLongID; // pass the parameter value of the Primary Key to the global Variable
            _blnReadOnly = pBlnReadOnly; // give the global boolean value the value of the parameter value

            organizeFormForReadOnly(); // organize the form fields after we get the read only value
            mnuDeleteOrder.Enabled = true;
        }

        #endregion 

        #region Accessors
        /// <summary>
        /// display the current record
        /// </summary>
        private void displayRecord()
        {
            cboCustomer.SelectedValue = _order.CustomerID;
            dtpOrderDate.Value = _order.OrderDate;
            dtpShipDate.Value = _order.OrderShippingDate;
            txtShipAddress.Text = _order.OrderShippingAddress;
            txtTotalAmount.Text = _order.OrderTotal.ToString("c2");
            dgvOrderLines.DataSource = _order.getOrderLinesTable();
            txtOrderName.Text = _order.OrderName;
        }
        /// <summary>
        /// populate the customer combo box and display the customer name but value the CustomerID
        /// </summary>
        private void populateCustomerCombo()
        {
            cboCustomer.DataSource = _order.getCustomers();
            cboCustomer.DisplayMember = "CustomerName";
            cboCustomer.ValueMember = "CustomerID";
            cboCustomer.SelectedIndex = -1;
        }
        /// <summary>
        /// populate the Product combo box and display the second column[1] but value the first column[0]
        /// </summary>
        private void populateProductCombo()
        {
            _dtb  = _dbConn.GetDataTable("Product");
            cboProduct.DataSource = _dtb;
            cboProduct.DisplayMember = _dtb.Columns[1].ToString();
            cboProduct.ValueMember = _dtb.Columns[0].ToString();
            cboProduct.SelectedIndex = -1;
        }


        #endregion

        #region Mutators 
        /// <summary>
        /// Empty the product controls
        /// </summary>
        private void emptyProductControls()
        {
            cboProduct.SelectedIndex = -1;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtLineTotal.Text = string.Empty;
        }

        private void assignChildData()
        {
            // assign the values to the variables to be used for calculations
            _order.OrderLineClass.ProductID = long.Parse(cboProduct.SelectedValue.ToString());
            _order.OrderLineClass.OrderLineQty = long.Parse(txtQuantity.Text);
            _order.OrderLineClass.ProductPrice = decimal.Parse(txtPrice.Text.ToString().Substring
                                                          (txtPrice.Text.ToString().IndexOf('$') + 1));
            _order.OrderLineClass.OrderNumber = _order.PKID;
            _order.OrderLineClass.OrderLineSubTotal = decimal.Parse(txtLineTotal.Text.ToString().Substring
                                                          (txtLineTotal.Text.ToString().IndexOf('$') + 1));
            _order.OrderLineClass.ProductName = cboProduct.Text;
        }
        /// <summary>
        /// Calculate the grand total
        /// </summary>
        private void calculateGrandTotal()
        {
            try
            {
                decimal decGrandTotal = decimal.Parse(_order.getOrderLinesTable().Compute
                                                      ("Sum(OrderLineSubTotal)", "").ToString());
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
                DataRowView drvCost = (DataRowView)cboProduct.SelectedItem;
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
            _order.OrderName = txtOrderName.Text;
            _order.CustomerID = long.Parse(cboCustomer.SelectedValue.ToString());
            _order.OrderDate = dtpOrderDate.Value;
            _order.OrderShippingDate = dtpShipDate.Value;
            _order.OrderShippingAddress = txtShipAddress.Text;
            _order.OrderTotal = decimal.Parse(txtTotalAmount.Text.Substring
                                              (txtTotalAmount.Text.IndexOf('$') + 1));
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
                grpOrderLine.Enabled = false;
                groupBox1.Enabled = false; groupBox2.Enabled = false; groupBox3.Enabled = false;
                mnuInsert.Enabled = false; mnuSave.Enabled = false; mnuDeleteLine.Enabled = false;
                mnuDeleteOrder.Enabled = false;
            }
            else
            {
                grpOrderLine.Enabled = true;
                groupBox1.Enabled = true; groupBox2.Enabled = true; groupBox3.Enabled = true;
                mnuInsert.Enabled = true; mnuSave.Enabled = true; mnuDeleteLine.Enabled = true;
                mnuDeleteOrder.Enabled = false;
            }
        }

        #endregion 
        
        #region Control Events

        private void mnuSave_Click(object sender, EventArgs e)
        {
            
            // if the data grid is not empty / is not less then 0. 
            // we increment this variable in the exisiting Order Constructor
            // or when you click insert
            if (dgvOrderLines.Rows.Count > 1)
            {
                ErrorProvider.Dispose(); // assign the values in the fields of this form the class properties
                assignData(); // assign the data
                _order.saveData(); // save the order record 
                _order.OrderLineClass.saveData(); // save the order line record
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
                _order.OrderLineClass.addNewRecord(); // add a new order line record
                dgvOrderLines.Refresh(); // refresh the datagrid view
                calculateGrandTotal(); // calculate the total
                emptyProductControls();
                // if the combo boxes selected items arent null
                if (cboCustomer.SelectedItem != null && txtShipAddress.Text != string.Empty)
                {
                    mnuInsert.Enabled = false; mnuSave.Enabled = true; mnuDeleteLine.Enabled = true;
                    // generate a code for the purhcase code by passing a value from this text boxe
                        txtOrderName.Text = cboCustomer.Text;
                 
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
            if (dgvOrderLines.Rows.Count > 1)
            {
                if (dgvOrderLines["OrderNumber", dgvOrderLines.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected record?",
                          "ChocoMambo", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _order.OrderLineClass.deleteOrderLine(long.Parse(dgvOrderLines["OrderLineID",
                                    dgvOrderLines.CurrentCell.RowIndex].Value.ToString())); // delete the order line by grabing the OrderLineID
                        calculateGrandTotal(); // calculate the total 
                        ErrorProvider.Dispose(); // dispose of the error message
                    }
                }
            } else {
                mnuDeleteLine.Enabled = false;
                ErrorProvider.SetError(this, "Can't Delete if the OrderLine is Empty");
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

        private void cboProduct_TextChanged(object sender, EventArgs e)
        {
            DataTable dtbTableData = _dbConn.GetDataTable("Product");
            // grab all the data rows in the table 
            foreach (DataRow drw in dtbTableData.Rows)
            {
                // if the value in the combo box below matches any of the ProductNames
                // then fill the text field with the current price of that product
                if (cboProduct.Text.Equals(drw["ProductName"].ToString()))
                {
                    txtPrice.Text = drw["Price"].ToString();
                }
            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            // if the comb boxes and text fields are empty 
            if (cboProduct.Text != string.Empty && txtQuantity.Text != string.Empty)
            {
                if (cboCustomer.Text != string.Empty && txtShipAddress.Text != string.Empty)
                {
                        calculateLineTotal(); // caclualte the total 
                        mnuInsert.Enabled = true; 
                }
            }
        }

        private void mnuDeleteOrder_Click(object sender, EventArgs e)
        {
            // if the datagrid is empty 
            if (dgvOrderLines.Rows.Count > 1)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected record?",
                          "ChocoMambo", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // get all the datarows and delete them if they have a valid OrderLine id 
                    foreach (DataGridViewRow row in dgvOrderLines.Rows)
                    {
                        _order.OrderLineClass.deleteOrderLine(long.Parse(dgvOrderLines["OrderLineID",
                                    dgvOrderLines.CurrentCell.RowIndex].Value.ToString())); // delete the order line by grabing the OrderLineID
                        _order.OrderLineClass.saveData();
                    }
                }
            }
            else 
            {
                // push back to the table to accept the changes before we delete the order. 
                _order.OrderLineClass.saveData();
                _order.delete(_lngPKID); // delete the order after everthing has been deleted
                this.Close();
            }
        }
        #endregion
    }
}
