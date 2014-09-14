using ChocoMambo.Properties;
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

namespace ChocoMambo
{
    public partial class frmOrders : Form
    {

        #region Instance Variables
        Order _order = null;
        #endregion

        #region Constructors
        public frmOrders()
        {
            InitializeComponent();
            _order = new Order();
            populateCustomerCombo();
            populateProductCombo();
            dgvOrderLines.DataSource = _order.getOrderLinesTable();
        }

        public frmOrders(long pLongID)
        {
            InitializeComponent();
            _order = new Order(pLongID);
            populateCustomerCombo();
            populateProductCombo();
            enableMenuButtons();
            displayRecord();
        }

        #endregion

        #region Accessors
        private void displayRecord()
        {
            cboCustomer.SelectedValue = _order.CustomerID;
            dtpOrderDate.Value = _order.OrderDate;
            dtpShipDate.Value = _order.OrderShippingDate;
            txtShipAddress.Text = _order.OrderShippingAddress;
            txtTotalAmount.Text = _order.OrderTotal.ToString("c2");
            dgvOrderLines.DataSource = _order.getOrderLinesTable();
            cbActive.Checked = _order.Active;
            txtOrderCode.Text = _order.OrderCode;
        }

        private void populateCustomerCombo()
        {
            cboCustomer.DataSource = _order.getCustomers();
            cboCustomer.DisplayMember = "CustomerName";
            cboCustomer.ValueMember = "CustomerID";
            cboCustomer.SelectedIndex = -1; //will make the combo box select nothing
        }

        private void populateProductCombo()
        {
            cboProduct.DataSource = _order.getProduct();
            cboProduct.DisplayMember = "ProductCode";
            cboProduct.ValueMember = "ProductID";
            cboProduct.SelectedIndex = -1; //will make the combo box select nothing
        }
        private void displayGridRecord()
        {
            // assign the values to the variables to be used for calculations
            decimal decPrice = decimal.Parse(dgvOrderLines["ProductPrice",
                                             dgvOrderLines.CurrentCell.RowIndex].Value.ToString());
            int intQty = int.Parse(dgvOrderLines["OrderLineQty",
                                   dgvOrderLines.CurrentCell.RowIndex].Value.ToString());

            cboProduct.SelectedValue = long.Parse(dgvOrderLines["ProductID",
                                             dgvOrderLines.CurrentCell.RowIndex].Value.ToString());
            txtPrice.Text = decPrice.ToString("c2");
            txtQuantity.Text = intQty.ToString();
            decimal decLineTotal = decPrice * intQty;
            txtLineTotal.Text = decLineTotal.ToString("c2");
            _order.OrderLineClass.PKID = long.Parse(dgvOrderLines["OrderLineID",
                                             dgvOrderLines.CurrentCell.RowIndex].Value.ToString());
        }

        #endregion

        #region Mutators
        
        private void emptyOrderLineControls()
        {
            cboProduct.SelectedIndex = -1;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtLineTotal.Text = string.Empty;
        }

        private void assignChildData()
        {
            _order.OrderLineClass.ProductID = long.Parse(cboProduct.SelectedValue.ToString());
            _order.OrderLineClass.OrderLineQty = long.Parse(txtQuantity.Text);
            _order.OrderLineClass.ProductPrice = decimal.Parse(txtPrice.Text.ToString().Substring
                                                          (txtPrice.Text.ToString().IndexOf('$')+1));
            _order.OrderLineClass.OrderNumber = _order.PKID;
            _order.OrderLineClass.OrderLineSubTotal = decimal.Parse(txtLineTotal.Text.ToString().Substring
                                                          (txtLineTotal.Text.ToString().IndexOf('$')+1));
            _order.OrderLineClass.ProductName = cboProduct.Text;
        }

        private void calculateGrandTotal()
        {
            try
            {
                decimal decGrandTotal = decimal.Parse(_order.getOrderLinesTable().Compute
                                                      ("Sum(OrderLineSubTotal)","").ToString());
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

        private void assignData()
        {
            _order.OrderCode = txtOrderCode.Text;
            _order.CustomerID = long.Parse(cboCustomer.SelectedValue.ToString());
            _order.OrderDate = dtpOrderDate.Value;
            _order.OrderShippingDate = dtpShipDate.Value;
            _order.OrderShippingAddress = txtShipAddress.Text;
            _order.OrderTotal = decimal.Parse(txtTotalAmount.Text.Substring
                                              (txtTotalAmount.Text.IndexOf('$')+1));
            _order.Active = cbActive.Checked;
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
        private void GenerateOrderCode(string pStrCustomer)
        {
            txtOrderCode.Text = pStrCustomer.ToString();
        }

        #endregion

        #region Control Events

        private void mnuSave_Click(object sender, EventArgs e)
        {
            assignData();
            _order.saveData();
            _order.OrderLineClass.saveData();
            this.Close();
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
                _order.OrderLineClass.deleteOrderLine(long.Parse(dgvOrderLines["OrderLineID",
                            dgvOrderLines.CurrentCell.RowIndex].Value.ToString()));
                calculateGrandTotal();
                emptyOrderLineControls();
                menuStrip1.Enabled = false;
            }
        }

        private void mnuInsert_Click(object sender, EventArgs e)
        {
           
            try
            {
                assignChildData();
                _order.OrderLineClass.addNewRecord();
                dgvOrderLines.Refresh();
                calculateGrandTotal();
                emptyOrderLineControls();
                if (cboCustomer.SelectedItem != null && txtShipAddress.Text != string.Empty)
                {
                    if (cbActive.Checked.Equals(true))
                    {
                        enableMenuButtons();
                        mnuInsert.Enabled = false;
                        GenerateOrderCode(cboCustomer.Text);
                    }
                    else
                    {
                        disableMenuButtons();
                    }
                }
                mnuInsert.Enabled = false;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Invalid operation.\n Please enter the " +
                                "order items and try again.", "ChocoMambo");
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
                    _order.saveData();
                    _order.OrderLineClass.saveData();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("This Item cannot be Deleted, becuase it has already been Deleted!");
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

        private void cboProduct_Leave(object sender, EventArgs e)
        {
            if (!cboProduct.Text.Equals(string.Empty))
            {
                Product _product = new Product(long.Parse(cboProduct.SelectedIndex.ToString()));
                txtPrice.Text = _product.Price.ToString();
            }
        }
        private void cboCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            cboCustomer.Text = string.Empty;
        }
        #endregion
    }
}
