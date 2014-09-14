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
using System.Collections;

namespace ChocoMambo
{
    public partial class frmLogin : Form
    {
        #region Global Declaration 

        public long _lngEmployeeID = 0;
        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb");
        frmParent _frm = new frmParent();

        #endregion 

        #region Constructors

        public frmLogin()
        {
            InitializeComponent();
        }

        public frmLogin(frmParent frm)
        {
            InitializeComponent();
            _frm = frm;
            frmLogin log = new frmLogin();
        }

        #endregion 

        #region Properties

        public string username
        {
            get
            {
                return txtUsername.Text;
            }
            set
            {
                string user = txtUsername.Text;
            }
        }

        #endregion 

        #region Accessors

        private Hashtable getAccessRightsHashTable()
        {
            Hashtable hshAccessRights = new Hashtable();
            long lngFormID = 0;
            DataTable dtbForms = _dbConn.GetDataTable("tblForms");
            DataTable dtbStaffForms = _dbConn.GetDataTable("SELECT * FROM tblEmployeeForms " +
                                "WHERE EmployeeID = " + _lngEmployeeID, "tblEmployeeForms");

            foreach (DataRow drwForms in dtbForms.Rows)
            {
                foreach (DataRow drwStaffForms in dtbStaffForms.Rows)
                {
                    lngFormID = long.Parse(drwForms["FormID"].ToString());

                    if (lngFormID == long.Parse(drwStaffForms["FormID"].ToString()) &&
                        _lngEmployeeID == long.Parse(drwStaffForms["EmployeeID"].ToString()))
                        hshAccessRights.Add(drwForms["FormName"].ToString(),drwStaffForms["AccessType"].ToString());
                }
            }
            return hshAccessRights;
        }
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
                    _lngEmployeeID = long.Parse(drw["EmployeeID"].ToString());
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
            if (allowLogin())
            {
                frmParent.AccessRights = getAccessRightsHashTable();
                frmView.AccessRights = getAccessRightsHashTable();
                _frm.isMenuStripEnabled = true;
                _frm.UserName = username;
                _frm.CheckAccessRights("Parent");
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid login. Please try again.", "ChocoMambo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TextBox[] TxtArray = new TextBox[2] { txtUsername, txtPassword };
            ClearFields(TxtArray);
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked == true){
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }
        #endregion
    }
}
