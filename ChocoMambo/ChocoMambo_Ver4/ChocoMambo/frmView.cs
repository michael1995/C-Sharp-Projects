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
    public partial class frmView : Form
    {

        #region Global Variables

        dbConnection dbConn = new dbConnection("ChocoMambo.accdb");
        DataTable dtb;
        int initFrmIndex = 0;

        #endregion 

        #region Constructor

        public frmView()
        {
            InitializeComponent();
        }

        public frmView(String pStrQuery, DataTable pDtb, int pInitFrmIndex)
        {
            InitializeComponent();
            pDtb = dbConn.GetDataTable(pStrQuery);
            dgvData.DataSource = pDtb;
            dgvData.Columns[0].Visible = false;
            PopulateComboBox(pStrQuery, pDtb);

            dtb = pDtb;
            initFrmIndex = pInitFrmIndex;
        }

        #endregion 

        #region Accessors

        private void PopulateComboBox(String pStrQuery, DataTable pDtb)
        {
            pDtb = dbConn.GetDataTable(pStrQuery);
            cboSearch.DataSource = pDtb;
            cboSearch.DisplayMember = pDtb.Columns[1].ToString();
            cboSearch.ValueMember = pDtb.Columns[0].ToString();
            cboSearch.SelectedIndex = -1;
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

        private void Search()
        {
            foreach (DataRow drw in dtb.Rows)
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
            if (!cboSearch.Text.Equals(string.Empty))
            Search();
        }

        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            long lngPKID = 0;
            if (initFrmIndex.Equals(1))
            {
                if (dgvData["EmployeeID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["EmployeeID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmEmployee frm = new frmEmployee(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            if (initFrmIndex.Equals(2))
            {
                if (dgvData["CustomerID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["CustomerID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmCustomer frm = new frmCustomer(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }

            if (initFrmIndex.Equals(3))
            {
                if (dgvData["OrderNumber", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["OrderNumber", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmOrders frm = new frmOrders(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }

            if (initFrmIndex.Equals(4))
            {
                if (dgvData["ProductID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["ProductID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmProduct frm = new frmProduct(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            if (initFrmIndex.Equals(5))
            {
                if (dgvData["SupplierID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["SupplierID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmSupplier frm = new frmSupplier(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            if (initFrmIndex.Equals(6))
            {
                if (dgvData["PurchaseID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["PurchaseID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmSupplierPurchase frm = new frmSupplierPurchase(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            if (initFrmIndex.Equals(7))
            {
                if (dgvData["RawIngredientsID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["RawIngredientsID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmRawIngredients frm = new frmRawIngredients(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            if (initFrmIndex.Equals(8))
            {
                if (dgvData["BranchID", dgvData.CurrentCell.RowIndex].Value.ToString() != string.Empty)
                {
                    lngPKID = long.Parse(dgvData["BranchID", dgvData.CurrentCell.RowIndex].Value.ToString());
                    frmBranch frm = new frmBranch(lngPKID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
            
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            CheckAccessRights("Search");
        }
        #endregion

    }
}
