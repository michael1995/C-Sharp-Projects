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

namespace ChocoMambo
{
    public partial class frmSearch : Form
    {

        #region Global Variables
        SearchDataTables _searchDataTable = new SearchDataTables();
        #endregion 

        #region Constructor

        public frmSearch()
        {
            InitializeComponent();
        }

        #endregion 

        #region Accessors

        private void populateEmployee()
        {
            DataTable dtb = _searchDataTable.loadEmployeeData();
            //assign the data table as the grid's data source
            dgvData.DataSource = dtb;
            dgvData.Columns["EmployeeID"].Visible = false; dgvData.Columns["Active"].Visible = false; dgvData.Columns["UserName"].Visible = false; dgvData.Columns["UserPassword"].Visible = false;
        }

        private void populateCustomer()
        {
            DataTable dtb = _searchDataTable.loadCustomerData();
            //assign the data table as the grid's data source
            dgvData.DataSource = dtb;
            dgvData.Columns["CustomerID"].Visible = false; dgvData.Columns["EmployeeID"].Visible = false; dgvData.Columns["Active"].Visible = false;
        }

        private void populateBranch()
        {
            DataTable dtb = _searchDataTable.loadBranchData();
            //assign the data table as the grid's data source
            dgvData.DataSource = dtb;
            dgvData.Columns["BranchID"].Visible = false; dgvData.Columns["Active"].Visible = false;
            dgvData.Columns["BranchOffice"].Width = dgvData.Width - 42;
        }
        private void populateProduct()
        {
            DataTable dtb = _searchDataTable.loadProductData();
            //assign the data table as the grid's data source
            dgvData.DataSource = dtb;
            dgvData.Columns["ProductID"].Visible = false; dgvData.Columns["Active"].Visible = false;
            dgvData.Columns["ProductName"].Width = dgvData.Width - 240;
        }
        private void populateRawIngredient()
        {
            DataTable dtb = _searchDataTable.loadRawIngredientData();
            //assign the data table as the grid's data source
            dgvData.DataSource = dtb;
            dgvData.Columns["RawIngredientsID"].Visible = false; dgvData.Columns["Active"].Visible = false;
            dgvData.Columns["IngredientName"].Width = dgvData.Width - 240; dgvData.Columns["Price"].Width = dgvData.Width - 240;
        }
        private void populateOrder()
        {
            DataTable dtb = _searchDataTable.loadOrderData();
            // assign the DataTable as the grid's data source
            dgvData.DataSource = dtb;
            dgvData.Columns["OrderNumber"].Visible = false; dgvData.Columns["CustomerID"].Visible = false; dgvData.Columns["Active"].Visible = false;
            dgvData.Columns["OrderDate"].Width = dgvData.Width - 240; dgvData.Columns["OrderShippingDate"].Width = dgvData.Width - 240; dgvData.Columns["OrderShippingAddress"].Width = dgvData.Width - 240;
        }
        private void populateSupplier()
        {
            DataTable dtb = _searchDataTable.loadSupplierData();
            // assign the DataTable as the grid's data source
            dgvData.DataSource = dtb;
            dgvData.Columns["SupplierID"].Visible = false; dgvData.Columns["Active"].Visible = false;
        }
        private void populateSupplierPurchase()
        {
            DataTable dtb = _searchDataTable.loadSupplierPurchaseData();
            // assign the DataTable as the grid's data source
            dgvData.DataSource = dtb;
            dgvData.Columns["PurchaseID"].Visible = false; dgvData.Columns["BranchID"].Visible = false; dgvData.Columns["SupplierID"].Visible = false; dgvData.Columns["Active"].Visible = false;
            dgvData.Columns["DatePurchased"].Width = dgvData.Width - 240; dgvData.Columns["PurchaseTotal"].Width = dgvData.Width - 400;
        }

        private void CheckAccessRights(string pStrFormName)
        {
            if (AccessRights[pStrFormName].ToString() == "Deny")
            {
                this.Close();
            }
            else if (AccessRights[pStrFormName].ToString() == "Read")
            {
                isDataGridEnabled = false;
            }
            else if (AccessRights[pStrFormName].ToString() == "Write") {  }
            else {  }
        }
      
        #endregion

        #region Properties 

        public static Hashtable AccessRights { get; set; }

        public bool isDataGridEnabled
        {
            get
            {
                return dgvData.Enabled;
            }

            set
            {
                if (isDataGridEnabled.Equals(false))
                {
                    EventHandler eventHandler = new EventHandler(dgvData_DoubleClick);
                    dgvData.DoubleClick -= eventHandler;
                }

            }
        }

        #endregion 

        #region Mutator

        public void PopulateDataGrid()
        {
            switch (txtSearch.Text)
            {
                case "Branch":
                    populateBranch();
                    break;
                case "Employee":
                    populateEmployee();
                    break;
                case "Customer":
                    populateCustomer();
                    break;
                case "Product":
                    populateProduct();
                    break;
                case "Orders":
                    populateOrder();
                    break;
                case "Raw Ingredients":
                    populateRawIngredient();
                    break;
                case "Supplier":
                    populateSupplier();
                    break;
                case "Supplier Purchase":
                    populateSupplierPurchase();
                    break;
            }
        }
        #endregion 

        #region Control Events

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.ParentForm.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTitleHorizontal_Click(object sender, EventArgs e)
        {
            this.ParentForm.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTitleVertical_Click(object sender, EventArgs e)
        {
            this.ParentForm.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuSearch_Click(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Equals(string.Empty))
            {
                PopulateDataGrid();
            }
        }

        private void dgvData_DoubleClick(object sender, EventArgs e)
        {

            long lngPKID = 0;
            if (txtSearch.Text.Equals("Employee"))
            {
                if (dgvData["EmployeeID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["EmployeeID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmEmployee frm = new frmEmployee(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }

            if (txtSearch.Text.Equals("Customer"))
            {
                if (dgvData["CustomerID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["CustomerID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmCustomer frm = new frmCustomer(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }

            if (txtSearch.Text.Equals("Branch"))
            {
                if (dgvData["BranchID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["BranchID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmBranch frm = new frmBranch(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }

            if (txtSearch.Text.Equals("Product"))
            {
                if (dgvData["ProductID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["ProductID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmProduct frm = new frmProduct(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }

            if (txtSearch.Text.Equals("Raw Ingredients"))
            {
                if (dgvData["RawIngredientsID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["RawIngredientsID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmRawIngredients frm = new frmRawIngredients(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }

            if (txtSearch.Text.Equals("Orders"))
            {
                if (dgvData["OrderNumber", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["OrderNumber", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmOrders frm = new frmOrders(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }

            if (txtSearch.Text.Equals("Supplier"))
            {
                if (dgvData["SupplierID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["SupplierID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmSupplier frm = new frmSupplier(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            if (txtSearch.Text.Equals("Supplier Purchase"))
            {
                if (dgvData["PurchaseID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["PurchaseID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmSupplierPurchase frm = new frmSupplierPurchase(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            PopulateDataGrid();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            CheckAccessRights("Search");
        }
        #endregion

    }
}
