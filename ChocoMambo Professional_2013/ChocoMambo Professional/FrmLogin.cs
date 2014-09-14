using ClassErrorCollection;
using DBConnection;
using System;
using System.Collections;
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
    public partial class FrmLogin : Form
    {
        #region Variable Declaration 

        public long _lngPKID = 0;
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb"); // Connect to the database
        FrmParent _frm = new FrmParent(); // create a new instance of parent 
        ErrorCollection _errorCollection; // create an instance of the error collection
        #endregion 

        #region Constructors
        /// <summary>
        /// Constructor for frmLogin
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor for frmLogin to open it from the parent form
        /// </summary>
        /// <param name="frm"></param>
        public FrmLogin(FrmParent frm)
        {
            InitializeComponent();
            _frm = frm;
            FrmLogin loginFrm = new FrmLogin();
        }

        #endregion 

        #region Accessors
        /// <summary>
        /// method for the hash table 
        /// read from the employee forms table to determine the access rights by grabbing the
        /// employee ID and to see what form they can use by selecting the form ID
        /// and return the value for other methods to use it
        /// </summary>
        /// <returns> HashTable </returns>
        private Hashtable getAccessRightsHashTable()
        {
            Hashtable hshAccessRights = new Hashtable();
            long lngFormID = 0;
            DataTable dtbForms = _dbConn.GetDataTable("tblForms");
            DataTable dtbStaffForms = _dbConn.GetDataTable("SELECT * FROM tblEmployeeForms " +
                                "WHERE EmployeeID = " + _lngPKID, "tblEmployeeForms");

            foreach (DataRow drwForms in dtbForms.Rows)
            {
                foreach (DataRow drwStaffForms in dtbStaffForms.Rows)
                {
                    lngFormID = long.Parse(drwForms["FormID"].ToString());

                    if (lngFormID == long.Parse(drwStaffForms["FormID"].ToString()) &&
                        _lngPKID == long.Parse(drwStaffForms["EmployeeID"].ToString()))
                        hshAccessRights.Add(drwForms["FormName"].ToString(),drwStaffForms["AccessType"].ToString());
                }
            }
            return hshAccessRights;
        }
        /// <summary>
        /// allow login to see if the user can login with the right 
        /// login details by reading from employee table 
        /// also if the user is active aswell as having the login in details they can succesfully
        /// login
        /// and return the value of the boolean
        /// </summary>
        /// <returns> blnReturnValue </returns>
        private bool allowLogin()
        {
            bool blnReturnValue = false;
            Boolean blnActive = false;

            DataTable dtbStaff = _dbConn.GetDataTable("tblEmployees");

            foreach (DataRow drw in dtbStaff.Rows)
            {
                if (txtUsername.Text.Equals(drw["UserName"].ToString()) &&
                    txtPassword.Text.Equals(drw["UserPassword"].ToString()))
                {
                    _lngPKID = long.Parse(drw["EmployeeID"].ToString());
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
        #endregion 

        #region Mutators
        /// <summary>
        /// clear all the fields assigned in the text box array
        /// </summary>
        /// <param name="pTxtArray"></param>
        public void ClearFields(TextBox[] pTxtArray)
        {
            for (int i = 0; i < pTxtArray.Length; i++)
            {
                pTxtArray[i].Text = string.Empty;
            }
        }
       

        #endregion 

        #region Control Events

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // if allow login is true
            if (allowLogin())
            {
                FrmParent.AccessRights = getAccessRightsHashTable(); // get the access rights for frmParent
                FrmView.AccessRights = getAccessRightsHashTable(); // get the access rights for frmView
                _frm.CheckAccessRights("Parent"); // check the access rights for parent form
                _frm.DisplayUser(txtUsername.Text); // call a method from the parent frm to display the current user by passing the string
                _frm.OrganizeMenuStrip(true); // call method to enable the menu strip by passing the boolean value
                this.Close();
            }
            else
            {
                ErrorProvider.SetError(this, "Invalid login. Please try again."); // show the error message
                string strTemp = "Invalid Login" + " " + "Username:" + txtUsername.Text; // create temp string 
                _errorCollection = new ErrorCollection(strTemp); // make a new instance of the error collection class and pass temp string
                _errorCollection.writeToFile(); // write to the file in the error collection class
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // create a text box array and pass the text boxes 
            TextBox[] TxtArray = new TextBox[2] { txtUsername, txtPassword };
            ClearFields(TxtArray); // call the method and pass the array to the paremter
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // dont display the password if the check box is ticked
            // display the password if the check box isnt ticked
            if (cbShowPassword.Checked == true){
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        #endregion
    }
}
