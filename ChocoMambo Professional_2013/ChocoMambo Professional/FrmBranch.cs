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
    public partial class FrmBranch : Form
    {
        #region Variable Declaration 
        
        Branch _branch = null;
        Boolean _blnActive; // A boolean to pass the Current State of the Branch record 
        long _lngPKID = 0; // Set the primary to zero before we use it 
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb"); // connect to the database
        Boolean _blnReadOnly; // A boolean to determine if the current user permission is read

        #endregion 

        #region Constructor 
        /// <summary>
        /// Create a new Branch record
        /// </summary>
        public FrmBranch()
        {
            InitializeComponent();
            _branch = new Branch(); // a new instance of the branch

        }
        /// <summary>
        /// Load the Exisitng Branch record by getting the Primary Key 
        /// Pass a boolean to determine is the User Permission is read only for later use
        /// </summary>
        /// <param name="pLongID"></param>
        /// <param name="pBlnReadOnly"></param>
        public FrmBranch(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _branch = new Branch(pLongID); // create a new instance of the branch and pass it the Primary Key
            displayRecord(); // display the current record

            _blnReadOnly = pBlnReadOnly; // give the global boolean value the value of the parameter value
            _lngPKID = pLongID; // pass the parameter value of the Primary Key to the global Variable

            organizeFormForReadOnly(); // organize the form fields after we get the read only value
        }

        #endregion 

        #region Accessors

        /// <summary>
        /// Display the current Record
        /// </summary>
        private void displayRecord()
        {
            txtBranchOffice.Text = _branch.BranchOffice; // get the database values of this property to be displayed in this text box
            _blnActive = _branch.Active; // get the database values of this value and pass it to the global variable
        }

        /// <summary>
        /// pass the text fields to this method to determine if the text fields are empty
        /// </summary>
        /// <param name="pTxtBranchOffice"></param>
        public void checkIfTextBoxFieldsAreEmpty(TextBox pTxtBranchOffice)
        {
            TextBox[] temp = new TextBox[1] { pTxtBranchOffice }; // create a new text box and give an array item - the parameter 
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
        /// <returns> return a boolean value to see if the text field(s) are blank return it to be used in the method above</returns>
        private bool isClear(TextBox ptxtFields)
        {
            bool blnTemp = false;
            if (ptxtFields.Text.Equals(string.Empty))
                blnTemp = true;
            return blnTemp;
        }

        #endregion 
        
        #region Mutators

        /// <summary>
        /// Assign the class properties to the text field values 
        /// </summary>
        private void AssignData()
        {
            _branch.BranchOffice = txtBranchOffice.Text;
            _branch.Active = _blnActive;
        }
        /// <summary>
        /// check to see if the record exisits
        /// </summary>
        /// <returns> return a boolean if the record exisit of not </returns>
        private bool checkIfRecordExists()
        {
            bool blnReturnValue = false;
            Boolean blnActive = false;

            DataTable dtbTableData = _dbConn.GetDataTable("tblBranch");
            // grab all the data rows in the table 
            foreach (DataRow drw in dtbTableData.Rows)
            {
                // if the value in the text box below matches any of the BranchOffice's
                //values and if it is active then return true that the record exisits 
                if (txtBranchOffice.Text.Equals(drw["BranchOffice"].ToString()))
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
                groupBox1.Enabled = false; 
                mnuSave.Enabled = false; mnuDelete.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
                mnuSave.Enabled = true; mnuDelete.Enabled = true;
            }
        }

        #endregion 

        #region Control Events

        private void mnuSave_Click(object sender, EventArgs e)
        {
            _blnActive = true; // set this current active state to true
            AssignData(); // assign the values in the fields of this form the class properties
            _branch.saveData(); // save this record
            this.Close(); // close this form after a success save
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBranchOffice_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkIfTextBoxFieldsAreEmpty(txtBranchOffice); // check if the text fields are empty
            if (checkIfRecordExists()) // check if the record exisits
            {
                ErrorProvider.SetError(groupBox1, "This Customer Already Exisits");
            }
            else
            {
                ErrorProvider.Dispose();
            }
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?",
                             "Delete selected Record?", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _branch = new Branch(_lngPKID); // create a new istance of branch and pass it the primary key
                _blnActive = false; // set the current active state to false
                AssignData(); // assign the values of the fields in this forms to the class properties
                _branch.saveData(); // now save this current record
                this.Close(); // close after a succesfull save
            }
        }
        #endregion
    }
}
