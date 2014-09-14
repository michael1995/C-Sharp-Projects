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
    public partial class FrmProduct : Form
    {
        #region Variable Declaration 
        
        Product _product = null;
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb"); // connect to the database 
        Boolean _blnActive; // A boolean to pass the Current State of the Customer record 
        long _lngPKID = 0; // Set the primary key to zero before we use it 
        Boolean _blnReadOnly; // A boolean to determine if the current user permission is read only

        #endregion 

        #region Constructor 
        /// <summary>
        /// Create a new Product
        /// </summary>
        public FrmProduct()
        {
            InitializeComponent();
            _product = new Product(); // new product instance 

        }
        /// <summary>
        /// load the current product record by getting the Primary key
        /// Pass a boolean to determine is the User Permission is read only for later use
        /// 
        /// </summary>
        /// <param name="pLongID"></param>
        /// <param name="pBlnReadOnly"></param>
        public FrmProduct(long pLongID, Boolean pBlnReadOnly)
        {
            InitializeComponent();
            _product = new Product(pLongID); // create a new instance of the Product and pass it the Primary Key
            displayRecord(); // display the current record

            _blnReadOnly = pBlnReadOnly; // pass the parameter value of the Primary Key to the global Variable
            _lngPKID = pLongID; // give the global boolean value the value of the parameter value

            organizeFormForReadOnly(); // organize the form fields after we get the read only value
        }

        #endregion 

        #region Accessors
        /// <summary>
        /// display the current record
        /// </summary>
        private void displayRecord()
        {
            txtProductName.Text = _product.ProductName;
            txtProductCode.Text = _product.ProductCode;
            txtQauntity.Text = _product.QuantityInStock;
            txtPrice.Text = _product.Price;
            txtComment.Text = _product.Comments;
            _blnActive = _product.Active;
        }
        /// <summary>
        /// pass the text fields to this method to determine if the text fields are empty
        /// </summary>
        /// <param name="pTxtProductName"></param>
        /// <param name="pTxtProductCode"></param>
        /// <param name="pTxtQuantity"></param>
        /// <param name="pTxtPrice"></param>
        /// <param name="pTxtComment"></param>
        public void checkIfTextBoxFieldsAreEmpty(TextBox pTxtProductName, TextBox pTxtProductCode, TextBox pTxtQuantity, TextBox pTxtPrice, TextBox pTxtComment)
        {
            // create a new text box and give an array item(s) - using the parameter values 
            TextBox[] temp = new TextBox[5] { pTxtProductName, pTxtProductCode, pTxtQuantity, pTxtPrice, pTxtComment };
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
        
        #region Mutators
        /// <summary>
        /// Assign the class properties to the text field values 
        /// </summary>
        private void AssignData()
        {
            _product.ProductName = txtProductName.Text;
            _product.ProductCode = txtProductCode.Text;
            _product.QuantityInStock = txtQauntity.Text;
            _product.Price = txtPrice.Text;
            _product.Comments = txtComment.Text;
            _product.Active = _blnActive;
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

            DataTable dtbTableData = _dbConn.GetDataTable("Product");
            // grab all the data rows in the table
            foreach (DataRow drw in dtbTableData.Rows)
            {
                // if the value in the text box below matches any of the ProductCodes
                //values and if it is active then return true that the record exisits 
                if (txtProductCode.Text.Equals(drw["ProductCode"].ToString()))
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
                groupBox1.Enabled = false; groupBox2.Enabled = false; groupBox3.Enabled = false;
                mnuSave.Enabled = false; mnuDelete.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true; groupBox2.Enabled = true; groupBox3.Enabled = true;
                mnuSave.Enabled = true; mnuDelete.Enabled = true;
            }
        }

        #endregion 

        #region Control Events

        private void txtComment_Leave(object sender, EventArgs e)
        {
            // check if the text fields are empty by pass the text fields to the method
            checkIfTextBoxFieldsAreEmpty(txtProductName, txtProductCode, txtQauntity, txtPrice, txtComment);
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            // if the record exisits
            if (checkIfRecordExists())
            {
                ErrorProvider.SetError(groupBox1, "This Product Code is already being used");
            }
            else
            {
                ErrorProvider.Dispose();
            }
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQauntity_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextFieldsToNumbersOnly(e); // pass the current key press event to the method to vaildate this field 
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateTextFieldsToNumbersOnly(e); // pass the current key press event to the method to vaildate this field 
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected record?",
                             "Delete selected Record?", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _product = new Product(_lngPKID);  // create a new istance of branch and pass it the primary key
                _blnActive = false; // set the current active state to false
                AssignData(); // assign the values of the fields in this forms to the class properties
                _product.saveData(); // now save this current record
                this.Close(); // close after a succesfull save
            }
        }
        private void mnuSave_Click(object sender, EventArgs e)
        {
            _blnActive = true; // set this current active state to true
            AssignData(); // assign the values in the fields of this form the class properties
            _product.saveData(); // save this record
            this.Close(); // close this form after a success save
        }
        #endregion
    }
}
