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
        #endregion

        #region Constructor

        public frmEmployee()
        {
            InitializeComponent();
            _employee = new Employee();
        }

        public frmEmployee(long pLongID)
        {
            InitializeComponent();
            _employee = new Employee(pLongID);
            mnuSave.Enabled = true; mnuDelete.Enabled = true; mnuWindow.Enabled = true;
            displayRecord();
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
                    mnuSave.Enabled = false;
                }
                else
                {
                    mnuSave.Enabled = true;
                }
            }
        }

        private bool isClear(TextBox ptxtFields)
        {
            bool temp = false;
            if (ptxtFields.Text.Equals(string.Empty))
                temp = true;
            return temp;
        }

        #endregion 

        #region Control Events

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.ParentForm.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTitleHorizontal_Click(object sender, EventArgs e)
        {
            this.ParentForm.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTitleVertical_Click(object sender, EventArgs e)
        {
            this.ParentForm.LayoutMdi(MdiLayout.TileVertical);
        }
        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            TextBox[] txtArray = new TextBox[9] { txtFirstName, txtLastName, txtPhone, txtAddress,
                  txtPostCode, txtSuburb, txtState, txtUsername, txtPassword };
             CheckFields(txtArray);
        }
        #endregion
    }
}
