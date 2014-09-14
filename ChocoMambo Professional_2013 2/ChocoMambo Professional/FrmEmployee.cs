using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBConnection;

namespace ChocoMambo_Professional
{
    public partial class FrmEmployee : Form
    {

        #region Variable Declaration 

        Employee _employee = null;
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb"); // connect to the database
        Boolean _blnActive; // A boolean to pass the Current State of the Employee record 
        long _lngPKID = 0; // Set the primary key to zero before we use it 
        Boolean _blnReadOnly; // A boolean to determine if the current user permission is read

        #endregion 

        #region Constructor 
        /// <summary>
        /// Create a new Employee
        /// </summary>
        public FrmEmployee()
        {
            InitializeComponent();
            _employee = new Employee(); // create a new employee instance
        }
        /// <summary>
        /// load the current Employee Record by getting the Primary key
        /// Pass a boolean to determine is the User Permission is read only for later use
        /// </summary>
        /// <param name="pLongID"></param>
        /// <param name="pBlnReadOnly"></param>
        public FrmEmployee(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _employee = new Employee(pLongID);  // create a new instance of the Employee and pass it the Primary Key
            displayRecord(); // display the current record

            _lngPKID = pLongID; // pass the parameter value of the Primary Key to the global Variable
            _blnReadOnly = pBlnReadOnly; // give the global boolean value the value of the parameter value

            organizeFormForReadOnly(); // organize the form fields after we get the read only value
        }

        #endregion 

        #region Accessors
        /// <summary>
        /// Display the current Record
        /// </summary>
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
            txtSalary.Text = _employee.Salary.ToString();
            txtUsername.Text = _employee.UserName;
            txtPassword.Text = _employee.UserPassword;
            _blnActive = _employee.Active;
        }
        /// <summary>
        /// pass the text fields to this method to determine if the text fields are empty
        /// </summary>
        /// <param name="pTxtFirstName"></param>
        /// <param name="pTxtLastName"></param>
        /// <param name="pTxtPhone"></param>
        /// <param name="pTxtAddress"></param>
        /// <param name="pTxtPostCode"></param>
        /// <param name="pTxtSuburb"></param>
        /// <param name="pTxtState"></param>
        /// <param name="pTxtSalary"></param>
        public void checkIfTextBoxFieldsAreEmpty(TextBox pTxtFirstName, TextBox pTxtLastName, TextBox pTxtPhone, TextBox pTxtAddress, TextBox pTxtPostCode, TextBox pTxtSuburb, TextBox pTxtState, TextBox pTxtSalary)
        {
            // create a new text box and give an array item(s) - using the parameter values 
            TextBox[] temp = new TextBox[8] { pTxtFirstName, pTxtLastName, pTxtPhone, pTxtAddress, pTxtPostCode, pTxtSuburb, pTxtState, pTxtSalary };
            for (int i = 0; i < temp.Length; i++)
            {
                if (isClear(temp[i]))
                {
                    mnuSave.Enabled = false;
                }
                else
                {
                    mnuSave.Enabled = true;
                }
            }
        }
        /// <summary>
        /// determine if the text field(s) are emtpy 
        /// </summary>
        /// <param name="ptxtFields"></param>
        /// <returns> return a boolean value to see if the text field(s) are blank return it to be used in the method above </returns>
        private bool isClear(TextBox ptxtFields)
        {
            bool blnTemp = false;
            if (ptxtFields.Text.Equals(string.Empty))
                blnTemp = true;
            return blnTemp;
        }

        #endregion 

        #region Mutator 
        /// <summary>
        /// Assign the class properties to the text field values 
        /// </summary>
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
            _employee.Salary = txtSalary.Text;
            _employee.UserName = txtUsername.Text;
            _employee.UserPassword = txtPassword.Text;
            _employee.Active = _blnActive;
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
        ///  check to see if the record exisits
        /// </summary>
        /// <returns> return a boolean if the record exisit of not </returns>
        private bool checkIfRecordExists()
        {
            bool blnReturnValue = false;
            Boolean blnActive = false;

            DataTable dtbTableData = _dbConn.GetDataTable("tblEmployees");
            // grab all the data rows in the table 
            foreach (DataRow drw in dtbTableData.Rows)
            {
                // if the value in the text box below matches any of the FirstNames
                //values and if it is active then return true that the record exisits 
                if (txtFirstName.Text.Equals(drw["FirstName"].ToString()) &&
                    txtLastName.Text.Equals(drw["LastName"].ToString()))
                {
                    blnActive = Boolean.Parse(drw["Active"].ToString());
                    if (blnActive.Equals(true))
                    {
                        blnReturnValue = true;
                        break;
                    }
                }
            }

            return blnReturnValue;
        }
        /// <summary>
        /// Organize the form when the Users permission is read only or not read only.
        /// </summary>
        public void organizeFormForReadOnly()
        {
            if (_blnReadOnly.Equals(true))
            {
                groupBox1.Enabled = false; groupBox2.Enabled = false; groupBox3.Enabled = false; groupBox4.Enabled = false;
                mnuSave.Enabled = false; mnuDelete.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true; groupBox2.Enabled = true; groupBox3.Enabled = true; groupBox4.Enabled = true;
                mnuSave.Enabled = true; mnuDelete.Enabled = true;
            }
        }

        #endregion 

        #region Control Events

        private void mnuSave_Click(object sender, EventArgs e)
        {
            _blnActive = true; // set this current active state to true
            AssignData(); // assign the values in the fields of this form the class properties
            _employee.saveData(); // save this record
            this.Close(); // close this form after a success save
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?",
                              "Delete selected Record?", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _employee = new Employee(_lngPKID);  // create a new istance of branch and pass it the primary key
                _blnActive = false; // set the current active state to false
                AssignData(); // assign the values of the fields in this forms to the class properties
                _employee.saveData(); // now save this current record
                this.Close(); // close after a succesfull save
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextFieldsToNumbersOnly(e); // pass the current key press event to the method to vaildate this field 
        }

        private void txtPostCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextFieldsToNumbersOnly(e); // pass the current key press event to the method to vaildate this field 
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextFieldsToNumbersOnly(e); // pass the current key press event to the method to vaildate this field 
        }

        private void txtSalary_Leave(object sender, EventArgs e)
        {
            // check if the text fields are empty by pass the text fields to the method
            if (cboDepartment.Text != string.Empty)
            checkIfTextBoxFieldsAreEmpty(txtFirstName, txtLastName, txtPhone, txtAddress, txtPostCode, txtSuburb, txtState, txtSalary);
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            // check if the record exisits
            if (checkIfRecordExists())
            {
                ErrorProvider.SetError(groupBox1, "This Employee Already Exisits");
            }
            else
            {
                ErrorProvider.Dispose();
            }
        }
        #endregion
    }
}
