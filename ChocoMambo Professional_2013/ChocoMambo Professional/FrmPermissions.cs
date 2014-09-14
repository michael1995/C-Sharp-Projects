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
    public partial class FrmPermissions : Form
    {
        #region Global Declaration
        Permission _permission = null;
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb"); // connect to the database
        DataTable _dtb; // create a datatable
        String _strQuery; // create a global string query
        long _lngPKID = 0; // Primary key variable set it to 0
        #endregion 

        #region Constructor
        /// <summary>
        /// load the query that has been passed to the first parameter value
        /// and place it in a datatable
        /// </summary>
        /// <param name="pStrQuery"></param>
        /// <param name="pDtb"></param>
        public FrmPermissions(String pStrQuery, DataTable pDtb)
        {
            InitializeComponent();
            _permission = new Permission(); // create a new instance 
            pDtb = _dbConn.GetDataTable(pStrQuery); // get the current query and place it into the datatable
            dgvData.DataSource = pDtb; // display datatable in the datagrid view
            dgvData.Columns[0].Visible = false; // set the first row to invisible 

            populateEmployeeCombo(); //populate the employee combo box
            populateFormsCombo(); // populate the forms combo box

            _dtb = pDtb; // set the global value to the paremeter value
            _strQuery = pStrQuery; // set the global variable to the parameter value
        }
        #endregion 

        #region Accessors
        /// <summary>
        /// display the current record
        /// </summary>
        private void displayRecord()
        {
            cboEmployee.SelectedValue = _permission.EmployeeID;
            cboForm.SelectedValue = _permission.FormID;
            cboAccessTypes.Text = _permission.AccessType;
            txtAccessLevelCode.Text = _permission.AccessLevelCode;
        }
        /// <summary>
        /// Populate employee combo box 
        /// set the datasource of the combo box from a method 
        /// that gets all the employees
        /// display only the employee name 
        /// make the value memeber the ID
        /// </summary>
        private void populateEmployeeCombo()
        {
            cboEmployee.DataSource = _permission.getEmployees();
            cboEmployee.DisplayMember = "LastName";
            cboEmployee.ValueMember = "EmployeeID";
            cboEmployee.SelectedIndex = -1;
        }
        /// <summary>
        /// Populate forms combo box 
        /// set the datasource of the combo box from a method 
        /// that gets all the forms
        /// display only the forms name 
        /// make the value memeber the ID
        /// </summary>
        private void populateFormsCombo()
        {
            cboForm.DataSource = _permission.getForms();
            cboForm.DisplayMember = "FormName";
            cboForm.ValueMember = "FormID";
            cboForm.SelectedIndex = -1;
        }
        /// <summary>
        /// Populate access types combo box 
        /// set the datasource of the combo box from a method 
        /// that gets all the access types
        /// display only the access type
        /// make the value memeber the ID
        /// </summary>
        private void populateAccessTypesCombo()
        {
            cboAccessTypes.DataSource = _permission.getAccessTypes();
            cboAccessTypes.DisplayMember = "AccessType";
            cboAccessTypes.ValueMember = "AccessType";
            cboAccessTypes.SelectedIndex = -1;
        }
        #endregion 

        #region Mutator
        /// <summary>
        /// Assign the class properties to the text field values 
        /// </summary>
        private void assignData()
        {
            _permission.EmployeeID = long.Parse(cboEmployee.SelectedValue.ToString());
            _permission.FormID = long.Parse(cboForm.SelectedValue.ToString());
            _permission.AccessLevelCode = txtAccessLevelCode.Text;
            _permission.AccessType = cboAccessTypes.Text;
        }
        /// <summary>
        /// Generate the access level code 
        /// pass the combo box values to the paremeter values 
        /// and then get the text box to equal the strings 
        /// </summary>
        /// <param name="pStrEmployee"></param>
        /// <param name="pStrFormIndex"></param>
        /// <param name="pStrAccess"></param>
        private void GenerateAccessLevelCode(string pStrEmployee, string pStrFormIndex, string pStrAccess)
        {
            txtAccessLevelCode.Text = pStrEmployee.ToString() + pStrFormIndex.ToString() + pStrAccess.ToString();
        }
        // clear all the fields
        private void clearFields()
        {
            cboEmployee.Text = string.Empty;
            cboForm.Text = string.Empty;
            cboAccessTypes.Text = string.Empty;
            txtAccessLevelCode.Text = string.Empty;
        }
        /// <summary>
        /// Rrefresh the table by crating a datatable by grabbing the table data from the acces 
        /// Databse and binding the datatable to the datagrid source
        /// </summary>
        private void refreshTable()
        {
            _dtb = _dbConn.GetDataTable(_strQuery);
            dgvData.DataSource = _dtb;
            dgvData.Refresh();
        }
       
        #endregion 

        #region Control Events
        
        private void mnuSave_Click(object sender, EventArgs e)
        {
            assignData(); // assign the values in the fields of this form the class properties
            _permission.saveData(); // save this record
            refreshTable(); // refresh the table after the save 
        }

        private void cboAccessTypes_Leave(object sender, EventArgs e)
        {
            // if all the combo boxes arent empty 
            if (cboEmployee.SelectedItem != null && cboForm.SelectedItem != null && cboAccessTypes.SelectedItem != null)
            {
               // generate the access level code and pass the combo box values
                    GenerateAccessLevelCode(cboEmployee.Text, cboForm.SelectedValue.ToString(), cboAccessTypes.Text);
                    ErrorProvider.Dispose(); // dispose of the error message
                    mnuSave.Enabled = true; // enable the save button
            }
            else
            {
                ErrorProvider.SetError(this, "Fields Cannot Be Empty"); // set the error message
            }
        }
        private void cboEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            txtAccessLevelCode.Text = string.Empty; // empty the combo box text
        }

        private void cboForm_SelectedValueChanged(object sender, EventArgs e)
        {
            txtAccessLevelCode.Text = string.Empty; // empty the combo box text
        }

        private void cboAccessTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            txtAccessLevelCode.Text = string.Empty; // empty the combo box text
        }

        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            // the there are no id values in this current row 
            if (dgvData["EmployeeFormID", dgvData.CurrentCell.RowIndex].Value.ToString() == string.Empty)
            {
                _lngPKID = 0; // set the primary key to 0
                clearFields(); // clear the fields 
                _permission = new Permission(); // and make a new instance of permissions
                groupBox1.Enabled = true; groupBox2.Enabled = true; groupBox3.Enabled = true; groupBox4.Enabled = true;
            } 
        }

        private void dgvData_Click(object sender, EventArgs e)
        {
            mnuSave.Enabled = false;
            ErrorProvider.Dispose();
            // if there is an id value in this current row
            if (dgvData["EmployeeFormID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
            {
                // give the primary key variable the current id of the current row selected
                _lngPKID = long.Parse(dgvData["EmployeeFormID", dgvData.CurrentCell.RowIndex].Value.ToString());
                _permission = new Permission(_lngPKID); // create a new instance of the permission but pass it the id
                displayRecord(); // display the current record
                groupBox1.Enabled = true; groupBox2.Enabled = true; groupBox3.Enabled = true; groupBox4.Enabled = true;
                mnuSave.Enabled = true;
            }
        }
        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (dgvData["EmployeeFormID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
            {
                if (MessageBox.Show("Are you sure you want to, delete the selected User Permission?",
                    "ChocoMambo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // give the primary key variable the current id of the current row selected
                    _lngPKID = long.Parse(dgvData["EmployeeFormID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    _permission.delete(_lngPKID); // and delete that user. 
                    clearFields(); // clear the all the fields in this form
                    refreshTable(); // refresh the datatable
                }
            }
            else
            {
                ErrorProvider.SetError(this, "Can't delete, if you have not selected a record!!");
            }
        #endregion
        }
    }
}
