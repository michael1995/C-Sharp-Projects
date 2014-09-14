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
    public partial class FrmView : Form
    {
        #region Variable Declaration

        dbConnection _dbConn = new dbConnection("ChocoMambo.accdb"); // connect to the database
        DataTable _dtb; // create a datatable
        int _initFrmIndex = 0; // create a form index count for later use to determine what the current form is
        Boolean _blnIsUserPermissionsReadOnly; // A boolean to determine if the permissions is read only
        String _strQuery;

        #endregion 

        #region Constructor
        /// <summary>
        /// Constructor for FrmView
        /// </summary>
        public FrmView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor for FrmView 
        /// The paremeter value is the current query passed through from the parent
        /// then is placed into a table 
        /// and then the form index is value is passed
        /// </summary>
        /// <param name="pStrQuery"></param>
        /// <param name="pDtb"></param>
        /// <param name="pInitFrmIndex"></param>
        public FrmView(String pStrQuery, DataTable pDtb, int pInitFrmIndex)
        {
            InitializeComponent();
            pDtb = _dbConn.GetDataTable(pStrQuery); // put the current query into the data table
            dgvData.DataSource = pDtb; // display the current datatable in the datagrid view
            dgvData.Columns[0].Visible = false; // set the first row to invisible 
            PopulateComboBox(pStrQuery, pDtb); // populate the combo box by passing the query and the data table

            _dtb = pDtb; // set the global value to the paremeter value
            _initFrmIndex = pInitFrmIndex; // set the global value to the paremeter value
            _strQuery = pStrQuery; // give the global query the value of the current query
        }

        #endregion 

        #region Properties
        /// <summary>
        /// Create a propterty for the hashtable and call it access rights
        /// </summary>
        public static Hashtable AccessRights { get; set; }

        #endregion 

        #region Accessors
        /// <summary>
        /// populate the combo box from the current query and then place it into a datatable
        /// </summary>
        /// <param name="pStrQuery"></param>
        /// <param name="pDtb"></param>
        private void PopulateComboBox(String pStrQuery, DataTable pDtb)
        {
            pDtb = _dbConn.GetDataTable(pStrQuery); // give the table the current query
            cboSearch.DataSource = pDtb; // bind the current data source of the datatable
            cboSearch.DisplayMember = pDtb.Columns[1].ToString(); 
            cboSearch.ValueMember = pDtb.Columns[0].ToString();
            cboSearch.SelectedIndex = -1; // make the combo box select nothing 
        }
        /// <summary>
        /// check the access rights 
        /// that was called in the frmLogin 
        /// it was passed "Search" string to match the paremeter value
        /// that is to determine the permission rights in this form
        /// </summary>
        /// <param name="pStrFormName"></param>
        private void CheckAccessRights(string pStrFormName)
        {
            if (AccessRights[pStrFormName].ToString() == "Deny")
            {
                this.Close();
            }
            else if (AccessRights[pStrFormName].ToString() == "Read")
            {
                _blnIsUserPermissionsReadOnly = true;
            }
            else if (AccessRights[pStrFormName].ToString() == "Write")
            {
                _blnIsUserPermissionsReadOnly = false;
            }
            else
            {
                _blnIsUserPermissionsReadOnly = false;
            }
        }
      
        #endregion

        #region Mutator
        /// <summary>
        /// search for the data row that eqauls the combo box value
        /// and set the current row of the datagrid to the Primary key row
        /// </summary>
        private void Search()
        {
            foreach (DataRow drw in _dtb.Rows)
            {
                if (cboSearch.Text.Equals(drw[1].ToString()))
                {
                    int temp = cboSearch.SelectedIndex;
                    dgvData.CurrentCell = dgvData.Rows[temp].Cells[1];
                }
            }
        }
        
        #endregion 

        #region Control Events

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // if the combo box is not empty 
            if (!cboSearch.Text.Equals(string.Empty))
                Search();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            // give the datatable the current query 
            _dtb = _dbConn.GetDataTable(_strQuery);
            dgvData.DataSource = _dtb; // bind the datagrid value to the datatable
            dgvData.Refresh(); // refresh the datagrid
        }

        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            // set the primary key to 0
            long lngPKID = 0;
            // if the frm index is eqauled to the correct index
            if (_initFrmIndex.Equals(1))
            {
                // if the ID of current row is not empty 
                if (dgvData["EmployeeID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    // give the primary key variable the currently selected rows ID value
                    lngPKID = long.Parse(dgvData["EmployeeID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    FrmEmployee frm = new FrmEmployee(lngPKID, _blnIsUserPermissionsReadOnly); // pass the id to the form contructor paremter values and the boolean to see if the user permission is read only 
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                else
                {
                    // if the user permission is not read only 
                    if (_blnIsUserPermissionsReadOnly.Equals(false))
                    {
                        // create a new employee and show the form 
                        FrmEmployee employeeFrm = new FrmEmployee();
                        employeeFrm.MdiParent = this.MdiParent;
                        employeeFrm.Show();
                    }
                }
            }
            // if the frm index is eqauled to the correct index
            if (_initFrmIndex.Equals(2))
            {
                // if the ID of current row is not empty
                if (dgvData["CustomerID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    // give the primary key variable the currently selected rows ID value
                    lngPKID = long.Parse(dgvData["CustomerID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    FrmCustomer customerFrm = new FrmCustomer(lngPKID, _blnIsUserPermissionsReadOnly); // pass the id to the form contructor paremter values and the boolean to see if the user permission is read only 
                    customerFrm.MdiParent = this.MdiParent;
                    customerFrm.Show();
                }
                else
                {
                    // if the user permission is not read only 
                    if (_blnIsUserPermissionsReadOnly.Equals(false))
                    {
                        // create a new customer and show the form 
                        FrmCustomer customerFrm = new FrmCustomer();
                        customerFrm.MdiParent = this.MdiParent;
                        customerFrm.Show();
                    }
                }
            }
            // if the frm index is eqauled to the correct index
            if (_initFrmIndex.Equals(3))
            {
                // if the ID of current row is not empty
                if (dgvData["OrderNumber", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    // give the primary key variable the currently selected rows ID value
                    lngPKID = long.Parse(dgvData["OrderNumber", dgvData.CurrentCell.RowIndex].Value.ToString());
                    FrmOrder orderFrm = new FrmOrder(lngPKID, _blnIsUserPermissionsReadOnly); // pass the id to the form contructor paremter values and the boolean to see if the user permission is read only 
                    orderFrm.MdiParent = this.MdiParent;
                    orderFrm.Show();
                }
                else
                {
                    // if the user permission is not read only 
                    if (_blnIsUserPermissionsReadOnly.Equals(false))
                    {
                        // create a new order and show the form 
                        FrmOrder orderFrm = new FrmOrder();
                        orderFrm.MdiParent = this.MdiParent;
                        orderFrm.Show();
                    }
                }
            }
            // if the frm index is eqauled to the correct index
            if (_initFrmIndex.Equals(4))
            {
                // if the ID of current row is not empty
                if (dgvData["ProductID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    // give the primary key variable the currently selected rows ID value
                    lngPKID = long.Parse(dgvData["ProductID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    FrmProduct productFrm = new FrmProduct(lngPKID, _blnIsUserPermissionsReadOnly); // pass the id to the form contructor paremter values and the boolean to see if the user permission is read only 
                    productFrm.MdiParent = this.MdiParent;
                    productFrm.Show();
                }
                else
                {
                    // if the user permission is not read only 
                    if (_blnIsUserPermissionsReadOnly.Equals(false))
                    {
                        // create a new product and show the form 
                        FrmProduct productFrm = new FrmProduct();
                        productFrm.MdiParent = this.MdiParent;
                        productFrm.Show();   
                    }
                }
            }
            // if the frm index is eqauled to the correct index
            if (_initFrmIndex.Equals(5))
            {
                // if the ID of current row is not empty
                if (dgvData["SupplierID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    // give the primary key variable the currently selected rows ID value
                    lngPKID = long.Parse(dgvData["SupplierID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    FrmSupplier supplierFrm = new FrmSupplier(lngPKID, _blnIsUserPermissionsReadOnly); // pass the id to the form contructor paremter values and the boolean to see if the user permission is read only 
                    supplierFrm.MdiParent = this.MdiParent;
                    supplierFrm.Show();
                }
                else
                {
                    // if the user permission is not read only 
                    if (_blnIsUserPermissionsReadOnly.Equals(false))
                    {
                        // create a new supplier and show the form 
                        FrmSupplier supplierFrm = new FrmSupplier();
                        supplierFrm.MdiParent = this.MdiParent;
                        supplierFrm.Show();
                    }
                }
            }
            // if the frm index is eqauled to the correct index
            if (_initFrmIndex.Equals(6))
            {
                // if the ID of current row is not empty
                if (dgvData["PurchaseID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    // give the primary key variable the currently selected rows ID value
                    lngPKID = long.Parse(dgvData["PurchaseID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    FrmSupplierPurchase supplierPurchaseFrm = new FrmSupplierPurchase(lngPKID, _blnIsUserPermissionsReadOnly); // pass the id to the form contructor paremter values and the boolean to see if the user permission is read only 
                    supplierPurchaseFrm.MdiParent = this.MdiParent;
                    supplierPurchaseFrm.Show();
                }
                else
                {
                    // if the user permission is not read only 
                    if (_blnIsUserPermissionsReadOnly.Equals(false))
                    {
                        // create a new supplier purchase and show the form 
                        FrmSupplierPurchase supplierPurchaseFrm = new FrmSupplierPurchase();
                        supplierPurchaseFrm.MdiParent = this.MdiParent;
                        supplierPurchaseFrm.Show();   
                    }
                }
            }
            // if the frm index is eqauled to the correct index
            if (_initFrmIndex.Equals(7))
            {
                // if the ID of current row is not empty
                if (dgvData["RawIngredientsID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    // give the primary key variable the currently selected rows ID value
                    lngPKID = long.Parse(dgvData["RawIngredientsID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    FrmRawIngredients rawIngredientsFrm = new FrmRawIngredients(lngPKID, _blnIsUserPermissionsReadOnly); // pass the id to the form contructor paremter values and the boolean to see if the user permission is read only 
                    rawIngredientsFrm.MdiParent = this.MdiParent;
                    rawIngredientsFrm.Show();
                }
                else
                {
                    // if the user permission is not read only 
                    if (_blnIsUserPermissionsReadOnly.Equals(false))
                    {
                        // create a new raw ingredient and show the form 
                        FrmRawIngredients rawIngredientsFrm = new FrmRawIngredients();
                        rawIngredientsFrm.MdiParent = this.MdiParent;
                        rawIngredientsFrm.Show();   
                    }
                }
            }
            // if the frm index is eqauled to the correct index
            if (_initFrmIndex.Equals(8))
            {
                // if the ID of current row is not empty
                if (dgvData["BranchID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    // give the primary key variable the currently selected rows ID value
                    lngPKID = long.Parse(dgvData["BranchID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    FrmBranch branchFrm = new FrmBranch(lngPKID, _blnIsUserPermissionsReadOnly); // pass the id to the form contructor paremter values and the boolean to see if the user permission is read only 
                    branchFrm.MdiParent = this.MdiParent;
                    branchFrm.Show();
                }
                else
                {
                    // if the user permission is not read only 
                    if (_blnIsUserPermissionsReadOnly.Equals(false))
                    {
                        // create a new branch and show the form 
                        FrmBranch branchFrm = new FrmBranch();
                        branchFrm.MdiParent = this.MdiParent;
                        branchFrm.Show();
                    }
                }
            }
        }

        private void FrmView_Load(object sender, EventArgs e)
        {
            // check the access rights for search 
            CheckAccessRights("Search");
        }
        #endregion
    }
}
