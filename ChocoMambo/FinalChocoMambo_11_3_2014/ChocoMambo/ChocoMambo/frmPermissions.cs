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
    public partial class frmPermissions : Form
    {

        #region Global Declaration
        Permission _permissionform = null;
        Boolean _blnReadOnly;
        #endregion 

        #region Constructor

        public frmPermissions()
        {
            InitializeComponent();
            _permissionform = new Permission();
            _blnReadOnly = false;
            populateEmployeeCombo();
            populateFormsCombo();
        }

        public frmPermissions(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _permissionform = new Permission(pLongID);
            _blnReadOnly = pBlnReadOnly;
            populateEmployeeCombo();
            populateFormsCombo();
            populateAccessTypesCombo();

            displayRecord();
            OrganizeMenuButtons();
        }
        #endregion

        #region Accessors

        private void displayRecord()
        {
            cboEmployee.SelectedValue = _permissionform.EmployeeID;
            cboForm.SelectedValue = _permissionform.FormID;
            cboAccessTypes.SelectedValue = _permissionform.AccessType;
            txtAccessLevelCode.Text = _permissionform.AccessLevelCode;
        }

        private void populateEmployeeCombo()
        {
            cboEmployee.DataSource = _permissionform.getEmployees();
            cboEmployee.DisplayMember = "FirstName";
            cboEmployee.ValueMember = "EmployeeID";
            cboEmployee.SelectedIndex = -1;
        }
        private void populateFormsCombo()
        {
            cboForm.DataSource = _permissionform.getForms();
            cboForm.DisplayMember = "FormName";
            cboForm.ValueMember = "FormID";
            cboForm.SelectedIndex = -1;
        }
        private void populateAccessTypesCombo()
        {
            cboAccessTypes.DataSource = _permissionform.getAccessTypes();
            cboAccessTypes.DisplayMember = "AccessType";
            cboAccessTypes.ValueMember = "AccessType";
            cboAccessTypes.SelectedIndex = -1;
        }
        #endregion 

        #region Mutator

        private void assignData()
        {
            _permissionform.EmployeeID = long.Parse(cboEmployee.SelectedValue.ToString());
            _permissionform.FormID = long.Parse(cboForm.SelectedValue.ToString());
            _permissionform.AccessLevelCode = txtAccessLevelCode.Text;
            _permissionform.AccessType = cboAccessTypes.Text;
        }
        private void GenerateAccessLevelCode(string pStrEmployee, string pStrFormIndex, string pStrAccess)
        {
            txtAccessLevelCode.Text = pStrEmployee.ToString() + pStrFormIndex.ToString() + pStrAccess.ToString();
        }
        public void OrganizeMenuButtons()
        {
            if (_blnReadOnly.Equals(true))
            {
                mnuSave.Enabled = false;
            }
            else
            {
                mnuSave.Enabled = true;
            }
        }
        #endregion 

        #region Control Events
        
        private void mnuSave_Click(object sender, EventArgs e)
        {
            assignData();
            _permissionform.saveData();
            this.Close();
        }

        private void cboAccessTypes_Leave(object sender, EventArgs e)
        {
            if (cboEmployee.SelectedItem != null && cboForm.SelectedItem != null && cboAccessTypes.SelectedItem != null)
            {
                if (_blnReadOnly.Equals(false))
                {
                    GenerateAccessLevelCode(cboEmployee.Text, cboForm.SelectedValue.ToString(), cboAccessTypes.Text);
                    ErrorProvider.Dispose();
                    mnuSave.Enabled = true;
                }
            }
            else
            {
                ErrorProvider.SetError(this, "Fields Cannot Be Empty");
            }
        }
        private void cboEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            txtAccessLevelCode.Text = string.Empty;
        }

        private void cboForm_SelectedValueChanged(object sender, EventArgs e)
        {
            txtAccessLevelCode.Text = string.Empty;
        }

        private void cboAccessTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            txtAccessLevelCode.Text = string.Empty;
        }
        #endregion
    }
}
