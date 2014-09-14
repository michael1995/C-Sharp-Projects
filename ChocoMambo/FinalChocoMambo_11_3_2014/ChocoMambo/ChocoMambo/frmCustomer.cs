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
    public partial class frmCustomer : Form
    {

        #region instance variables 
        Customer _customer = null;
        Boolean _blnReadOnly;
        #endregion 

        #region Constructor

        public frmCustomer()
        {
            InitializeComponent();
            _customer = new Customer();
            _blnReadOnly = false;
            populateEmployeeCombo();
        }

        public frmCustomer(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _customer = new Customer(pLongID);
            _blnReadOnly = pBlnReadOnly;
            populateEmployeeCombo();
            displayRecord();
            OrganizeMenuButtons();
        }

        #endregion 

        #region Accessors

        private void displayRecord()
        {
            cboEmployee.SelectedValue = _customer.EmployeeID;
            txtCustomerName.Text = _customer.CustomerName;
            txtPhone.Text = _customer.Phone;
            txtAddress.Text = _customer.Address;
            txtSuburb.Text = _customer.Suburb;
            txtPostCode.Text = _customer.Postcode;
            txtState.Text = _customer.State;
            txtCreditLimit.Text = _customer.CreditLimit.ToString("c2");
            cbActive.Checked = _customer.Active;
        }

        private void populateEmployeeCombo()
        {
            cboEmployee.DataSource = _customer.getEmployees();
            cboEmployee.DisplayMember = "FirstName";
            cboEmployee.ValueMember = "EmployeeID";
            cboEmployee.SelectedIndex = -1;
        }

        #endregion 

        #region Mutators

        private void assignData()
        {
            _customer.EmployeeID = long.Parse(cboEmployee.SelectedValue.ToString());
            _customer.CustomerName = txtCustomerName.Text;
            _customer.Phone = txtPhone.Text;
            _customer.Address = txtAddress.Text;
            _customer.Suburb = txtSuburb.Text;
            _customer.Postcode = txtPostCode.Text;
            _customer.State = txtState.Text;
            _customer.CreditLimit = decimal.Parse(txtCreditLimit.Text.Substring
                                              (txtCreditLimit.Text.IndexOf('$') + 1));
            _customer.Active = cbActive.Checked;
        }
        public void CheckFields(TextBox[] pTxtArray)
        {
            for (int i = 0; i < pTxtArray.Length; i++)
            {
                if (isClear(pTxtArray[i]))
                {
                    ErrorProvider.SetError(this, "Fields Cannot Be Empty");
                    mnuSave.Enabled = false;
                }
                else
                {
                    ErrorProvider.Dispose();
                    mnuSave.Enabled = true;
                }
            }
        }

        private bool isClear(TextBox ptxtFields)
        {
            bool blnTemp = false;
            if (ptxtFields.Text.Equals(string.Empty))
                blnTemp = true;
            return blnTemp;
        }

        public void OrganizeMenuButtons()
        {
            if (_blnReadOnly.Equals(true))
            {
                mnuSave.Enabled = false; mnuDelete.Enabled = false;
            }
            else
            {
                mnuSave.Enabled = true; mnuDelete.Enabled = true;
            }
        }

        #endregion 

        #region Control Events

        private void mnuSave_Click(object sender, EventArgs e)
        {
            assignData();
            _customer.saveData();
            this.Close();
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (cbActive.Checked.Equals(true))
            {
                if (MessageBox.Show("Are you sure you want to delete the selected record?",
                              "ChocoMambo", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cbActive.Checked = false;
                    assignData();
                    _customer.saveData();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Cannot Delete. Please try again.", "ChocoMambo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtState_Leave(object sender, EventArgs e)
        {
            TextBox[] txtArray = new TextBox[7] { txtCustomerName, txtPhone, txtAddress,
                  txtPostCode, txtSuburb, txtState, txtCreditLimit };
            if (_blnReadOnly.Equals(false))
            {
                CheckFields(txtArray);
            }
        }

        #endregion
    }
}
