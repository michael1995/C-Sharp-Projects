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
    public partial class frmBranch : Form
    {

        #region Variable Declarations
        Branch _branch = null;
        Boolean _blnReadOnly;
        #endregion 

        #region Constructors
        public frmBranch()
        {
            InitializeComponent();
            _branch = new Branch();
            _blnReadOnly = false;
        }
        public frmBranch(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _branch = new Branch(pLongID);
            _blnReadOnly = pBlnReadOnly;
            displayRecord();
            OrganizeMenuButtons();
        }

        #endregion 

        #region Accessor 

        private void displayRecord()
        {
            txtBranchOffice.Text = _branch.BranchOffice;
            cbActive.Checked = _branch.Active;
        }

        #endregion 

        #region Mutators

        private void assignData()
        {
            _branch.BranchOffice = txtBranchOffice.Text;
            _branch.Active = cbActive.Checked;
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
            bool temp = false;
            if (ptxtFields.Text.Equals(string.Empty))
                temp = true;
            return temp;
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
            _branch.saveData();
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
                    _branch.saveData();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Cannot Delete. Please try again.", "ChocoMambo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtBranchOffice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox[] txtArray = new TextBox[1] { txtBranchOffice };
            if (_blnReadOnly.Equals(false))
            {
                CheckFields(txtArray);
            }
        }
        #endregion

    }
}
