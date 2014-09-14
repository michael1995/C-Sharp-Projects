﻿using DBConnection;
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
    public partial class FrmSupplier : Form
    {
        
        #region Variable Declaration 

        Supplier _supplier = null;
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb");  // connect to the database 
        Boolean _blnActive; // A boolean to pass the Current State of the Customer record 
        long _lngPKID = 0; // Set the primary key to zero before we use it 
        Boolean _blnReadOnly; // A boolean to determine if the current user permission is read only

        #endregion 

        #region Constructor 
        /// <summary>
        /// Create a new supplier
        /// </summary>
        public FrmSupplier()
        {
            InitializeComponent();
            _supplier = new Supplier(); // new instance of supplier
        }
        /// <summary>
        /// Load an exisiting Supplier by getting the Primary key
        /// Pass a boolean to determine is the User Permission is read only for later use
        /// </summary>
        /// <param name="pLongID"></param>
        /// <param name="pBlnReadOnly"></param>
        public FrmSupplier(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _supplier = new Supplier(pLongID); // create a new instance of the Supplier and pass it the Primary Key
            displayRecord(); // display the current record

            _blnReadOnly = pBlnReadOnly; // give the global boolean value the value of the parameter value
            _lngPKID = pLongID; // pass the parameter value of the Primary Key to the global Variable

            organizeFormForReadOnly(); // organize the form fields after we get the read only value
        }

        #endregion 

        #region Accessors
        /// <summary>
        /// display the current record
        /// </summary>
        private void displayRecord()
        {
            txtSupplierName.Text = _supplier.SupplierName;
            txtPhone.Text = _supplier.Phone;
            txtAddress.Text = _supplier.Address;
            txtPostCode.Text = _supplier.Postcode;
            txtSuburb.Text = _supplier.Suburb;
            txtState.Text = _supplier.State;
            _blnActive = _supplier.Active;
        }
        /// <summary>
        /// pass the text fields to this method to determine if the text fields are empty
        /// </summary>
        /// <param name="pTxtSupplierName"></param>
        /// <param name="pTxtPhone"></param>
        /// <param name="pTxtAddress"></param>
        /// <param name="pTxtPostCode"></param>
        /// <param name="pTxtSuburb"></param>
        /// <param name="pTxtState"></param>
        public void checkIfTextBoxFieldsAreEmpty(TextBox pTxtSupplierName, TextBox pTxtPhone, TextBox pTxtAddress, TextBox pTxtPostCode, TextBox pTxtSuburb, TextBox pTxtState)
        {
            // create a new text box and give an array item(s) - using the parameter values 
            TextBox[] temp = new TextBox[6] { pTxtSupplierName, pTxtPhone, pTxtAddress, pTxtPostCode, pTxtSuburb, pTxtState };
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
        /// Clear the fields
        /// </summary>
        private void clearFields()
        {
            txtSupplierName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPostCode.Text = string.Empty;
            txtSuburb.Text = string.Empty;
            txtState.Text = string.Empty;
            _blnActive = false;
        }
        /// <summary>
        /// Assign the class properties to the text field values
        /// </summary>
        private void AssignData()
        {
            _supplier.SupplierName = txtSupplierName.Text;
            _supplier.Phone = txtPhone.Text;
            _supplier.Address = txtAddress.Text;
            _supplier.Postcode = txtPostCode.Text;
            _supplier.Suburb = txtSuburb.Text;
            _supplier.State = txtState.Text;
            _supplier.Active = _blnActive;
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
        /// check to see if the record exisits
        /// </summary>
        /// <returns> return a boolean if the record exisit of not </returns>
        private bool checkIfRecordExists()
        {
            bool blnReturnValue = false;
            Boolean blnActive = false;

            DataTable dtbTableData = _dbConn.GetDataTable("tblSuppliers");
            // grab all the data rows in the table 
            foreach (DataRow drw in dtbTableData.Rows)
            {
                // if the value in the text box below matches any of the SupplierNames
                //values and if it is active then return true that the record exisits
                if (txtSupplierName.Text.Equals(drw["SupplierName"].ToString()))
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
                groupBox1.Enabled = false; groupBox2.Enabled = false;
                mnuSave.Enabled = false; mnuDelete.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true; groupBox2.Enabled = true;
                mnuSave.Enabled = true; mnuDelete.Enabled = true;
            }
        }

        #endregion 

        #region Control Events

       
        private void mnuSave_Click(object sender, EventArgs e)
        {
            _blnActive = true;  // set this current active state to true
            AssignData(); // assign the values in the fields of this form the class properties
            _supplier.saveData();  // save this record
            this.Close(); // close this form after a success save
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?",
                                "Delete selected Record?", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _supplier = new Supplier(_lngPKID);  // create a new istance of branch and pass it the primary key
                _blnActive = false; // set the current active state to false
                AssignData(); // assign the values of the fields in this forms to the class properties
                _supplier.saveData();   // now save this current record
                this.Close(); // close after a succesfull save
            }
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void txtState_Leave(object sender, EventArgs e)
        {
            // check if the text fields are empty by pass the text fields to the method
            checkIfTextBoxFieldsAreEmpty(txtSupplierName, txtPhone, txtAddress, txtPostCode, txtSuburb, txtState);
        }

        private void txtSupplierName_Leave(object sender, EventArgs e)
        {
            // if the record exisits
            if (checkIfRecordExists())
            {
                ErrorProvider.SetError(groupBox1, "This Supplier Already Exisits");
            }
            else
            {
                ErrorProvider.Dispose();
            }
        }

        private void txtPostCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextFieldsToNumbersOnly(e); // pass the current key press event to the method to vaildate this field 
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextFieldsToNumbersOnly(e); // pass the current key press event to the method to vaildate this field 
        }

        #endregion
    }
}
