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
    public partial class frmEmployee : Form
    {
        #region variables declarations
        Employee _employee = null;
        Boolean _blnReadOnly;
        #endregion

        #region Constructor

        public frmEmployee()
        {
            InitializeComponent();
            _employee = new Employee();
            _blnReadOnly = false;
        }

        public frmEmployee(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _employee = new Employee(pLongID);
            _blnReadOnly = pBlnReadOnly;
            displayRecord();
            OrganizeMenuButtons();
        }

        #endregion 

        #region Accessors 

        private void displayRecord()
        {
            txtFirstName.Text = _employee.FirstName;
            txtLastName.Text = _employee.LastName;
            txtPhone.Text = _employee.Phone;
            txtAddress.Text = _employee.AddressLine1;
            txtPostCode.Text = _employee.Postcode;
            txtSuburb.Text = _employee.Suburb;
            txtState.Text = _employee.State;
            cboDepartment.Text = _employee.Department;
            txtSalary.Text = _employee.Salary.ToString("c2");
            txtUsername.Text = _employee.UserName;
            txtPassword.Text = _employee.UserPassword;
            cbActive.Checked = _employee.Active;
        }

        #endregion 

        #region Mutator

        private void AssignData()
        {
            _employee.FirstName = txtFirstName.Text;
            _employee.LastName = txtLastName.Text;
            _employee.Phone = txtPhone.Text;
            _employee.AddressLine1 = txtAddress.Text;
            _employee.Postcode = txtPostCode.Text;
            _employee.Suburb = txtSuburb.Text;
            _employee.State = txtState.Text;
            _employee.Department = cboDepartment.Text;
            _employee.Salary = decimal.Parse(txtSalary.Text.Substring
                                              (txtSalary.Text.IndexOf('$') + 1));
            _employee.UserName = txtUsername.Text;
            _employee.UserPassword = txtPassword.Text;
            _employee.Active = cbActive.Checked;
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
            AssignData();
            _employee.saveData();
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
                    AssignData();
                    _employee.saveData();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Cannot Delete. Please try again.", "ChocoMambo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSalary_Leave(object sender, EventArgs e)
        {
            TextBox[] txtArray = new TextBox[10] { txtFirstName, txtLastName, txtPhone, txtAddress,
                  txtPostCode, txtSuburb, txtState, txtSalary, txtUsername, txtPassword };
            if (_blnReadOnly.Equals(false))
            {
                CheckFields(txtArray);
            }
        }
        #endregion
    }
}
