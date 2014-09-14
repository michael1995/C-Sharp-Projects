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
    public partial class frmSupplier : Form
    {
       
        #region variables declarations
        Supplier _supplier = null;
        Boolean _blnReadOnly;
        #endregion

        #region Constructor
         public frmSupplier()
        {
            InitializeComponent();
            _supplier = new Supplier();
            _blnReadOnly = false;
        }

         public frmSupplier(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _supplier = new Supplier(pLongID);
            _blnReadOnly = pBlnReadOnly;
            displayRecord();
            OrganizeMenuButtons();
        }

        #endregion 

        #region Accessors 

        private void displayRecord()
        {
            txtSupplierName.Text = _supplier.SupplierName;
            txtAddress.Text = _supplier.Address;
            txtSuburb.Text = _supplier.Suburb;
            txtState.Text = _supplier.State;
            txtPostCode.Text = _supplier.Postcode;
            txtPhone.Text = _supplier.Phone;
            cbActive.Checked = _supplier.Active;
        }

        #endregion 

        #region Mutator

        private void AssignData()
        {
            _supplier.SupplierName = txtSupplierName.Text;
            _supplier.Address = txtAddress.Text;
            _supplier.Suburb = txtSuburb.Text;
            _supplier.State = txtState.Text;
            _supplier.Postcode = txtPostCode.Text;
            _supplier.Phone = txtPhone.Text;
            _supplier.Active = cbActive.Checked;
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
            _supplier.saveData();
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
                    _supplier.saveData();
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
            TextBox[] txtArray = new TextBox[6] { txtSupplierName, txtAddress, txtSuburb, txtState,
                  txtPostCode, txtPhone };
            if (_blnReadOnly.Equals(false))
            {
                CheckFields(txtArray);
            }
        }
        #endregion

    }
}
