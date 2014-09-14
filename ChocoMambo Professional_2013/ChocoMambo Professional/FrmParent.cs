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
    public partial class FrmParent : Form
    {

        #region Variable Declarations

        DataTable _dtb = new DataTable(); // create a new datatable isntance

        #endregion 

        #region Contructor
        /// <summary>
        /// Construtor for frmParent
        /// </summary>
        public FrmParent()
        {
            InitializeComponent();
        }

        #endregion 

        #region Proptery 
        /// <summary>
        /// Create a propterty for the hashtable and call it access rights
        /// </summary>
        public static Hashtable AccessRights { get; set; }

        #endregion 

        #region Accessors
        /// <summary>
        /// check the access rights 
        /// that was called in the frmLogin 
        /// it was passed "Parent" string to match the paremeter value
        /// that is to determine the permission rights in this form
        /// </summary>
        /// <param name="pStrFormName"></param>
        public void CheckAccessRights(string pStrFormName)
        {
            if (AccessRights[pStrFormName].ToString() == "Deny")
            {
                this.Close(); mnuAdminHub.Visible = false;
            }
            else if (AccessRights[pStrFormName].ToString() == "Read")
            {
                mnuFile.Enabled = false; mnuView.Enabled = true; mnuAdminHub.Visible = false;
            }
            else if (AccessRights[pStrFormName].ToString() == "Write")
            {
                mnuFile.Enabled = true; mnuView.Enabled = true; mnuAdminHub.Visible = false;
            }
            else
            {
                mnuFile.Enabled = true; mnuView.Enabled = true; mnuAdminHub.Visible = true;
            }
        }
        /// <summary>
        /// display the username 
        /// the paremter value was assigned to in the frmLogin
        /// </summary>
        /// <param name="pStrUsername"></param>
        public void DisplayUser(string pStrUsername)
        {
            mnuUser.Text = pStrUsername;
            mnuUser.Visible = true;
        }
        /// <summary>
        /// ennable the menu strip 
        /// the value was passed from the frmLogin through a boolean 
        /// </summary>
        /// <param name="pBlnEnableMenuStrip"></param>
        public void OrganizeMenuStrip(Boolean pBlnEnableMenuStrip)
        {
            if (pBlnEnableMenuStrip.Equals(true))
                MainMenuStrip.Enabled = true;
            else
                MainMenuStrip.Enabled = false;
        }

        #endregion

        #region Mutator
        /// <summary>
        ///  close all the forms that are in this mdi 
        /// </summary>
        private void closeAllActiveForms()
        {
            foreach (Form child in this.MdiChildren)
            {
                if (!child.Focused)
                {
                    child.Close();
                }
            }
        }

        #endregion

        #region Control Events
        /// <summary>
        /// Create new Employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuEmployee_Click(object sender, EventArgs e)
        {
            FrmEmployee employeForm = new FrmEmployee();
            employeForm.MdiParent = this;
            employeForm.Show();
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomer customerForm = new FrmCustomer();
            customerForm.MdiParent = this;
            customerForm.Show();
        }

        private void mnuOrder_Click(object sender, EventArgs e)
        {
            FrmOrder orderForm = new FrmOrder();
            orderForm.MdiParent = this;
            orderForm.Show();
        }

        private void mnuProduct_Click(object sender, EventArgs e)
        {
            FrmProduct productFrm = new FrmProduct();
            productFrm.MdiParent = this;
            productFrm.Show();
        }

        private void mnuSupplier_Click(object sender, EventArgs e)
        {
            FrmSupplier supplierFrm = new FrmSupplier();
            supplierFrm.MdiParent = this;
            supplierFrm.Show();
        }

        private void mnuSupplierPurchase_Click(object sender, EventArgs e)
        {
            FrmSupplierPurchase supplierPurchaseFrm = new FrmSupplierPurchase();
            supplierPurchaseFrm.MdiParent = this;
            supplierPurchaseFrm.Show();
        }

        private void mnuRawIngredients_Click(object sender, EventArgs e)
        {
            FrmRawIngredients rawIngredientsFrm = new FrmRawIngredients();
            rawIngredientsFrm.MdiParent = this;
            rawIngredientsFrm.Show();
        }

        private void mnuBranch_Click(object sender, EventArgs e)
        {
            FrmBranch branchForm = new FrmBranch();
            branchForm.MdiParent = this;
            branchForm.Show();
        }
        /// <summary>
        /// Load the Employee's to view by passing the query from the table, a datatable to place the 
        /// query in 
        /// and a form index 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuViewEmployee_Click(object sender, EventArgs e)
        {
            FrmView viewEmployeeFrm = new FrmView("qryEmployeeActive", _dtb, 1);
            viewEmployeeFrm.MdiParent = this;
            viewEmployeeFrm.Show();
        }
        /// <summary>
        /// Load the Customer's to view by passing the query from the table, a datatable to place the 
        /// query in 
        /// and a form index 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuViewCustomer_Click(object sender, EventArgs e)
        {
            FrmView viewCustomerFrm = new FrmView("qryCustomerActive", _dtb, 2);
            viewCustomerFrm.MdiParent = this;
            viewCustomerFrm.Show();
        }
        /// <summary>
        /// Load the Order's to view by passing the query from the table, a datatable to place the 
        /// query in 
        /// and a form index 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuViewOrder_Click(object sender, EventArgs e)
        {
            FrmView viewOrderFrm = new FrmView("qryOrders", _dtb, 3);
            viewOrderFrm.MdiParent = this;
            viewOrderFrm.Show();
        }
        /// <summary>
        /// Load the Products's to view by passing the query from the table, a datatable to place the 
        /// query in 
        /// and a form index 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuViewProduct_Click(object sender, EventArgs e)
        {
            FrmView viewProductFrm = new FrmView("qryProductActive", _dtb, 4);
            viewProductFrm.MdiParent = this;
            viewProductFrm.Show();
        }
        /// <summary>
        /// Load the Supplier's to view by passing the query from the table, a datatable to place the 
        /// query in 
        /// and a form index 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuViewSupplier_Click(object sender, EventArgs e)
        {
            FrmView viewSupplierFrm = new FrmView("qrySupplierActive", _dtb, 5);
            viewSupplierFrm.MdiParent = this;
            viewSupplierFrm.Show();
        }
        /// <summary>
        /// Load the Supplier Purchases's to view by passing the query from the table, a datatable to place the 
        /// query in 
        /// and a form index 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuViewSupplierPurchase_Click(object sender, EventArgs e)
        {
            FrmView viewSupplierPurchaseFrm = new FrmView("qryPurchases", _dtb, 6);
            viewSupplierPurchaseFrm.MdiParent = this;
            viewSupplierPurchaseFrm.Show();
        }
        /// <summary>
        /// Load the RawIngredient's to view by passing the query from the table, a datatable to place the 
        /// query in 
        /// and a form index 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuViewRawIngredient_Click(object sender, EventArgs e)
        {
            FrmView viewRawIngredientsFm = new FrmView("qryRawIngredientsActive", _dtb, 7);
            viewRawIngredientsFm.MdiParent = this;
            viewRawIngredientsFm.Show();
        }
        /// <summary>
        /// Load the Branch's to view by passing the query from the table, a datatable to place the 
        /// query in 
        /// and a form index 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuViewBranch_Click(object sender, EventArgs e)
        {
            FrmView viewBranchFrm = new FrmView("qryBranchActive", _dtb, 8);
            viewBranchFrm.MdiParent = this;
            viewBranchFrm.Show();
        }
        /// <summary>
        /// load the login form 
        /// and display it in the mdi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmParent_Load(object sender, EventArgs e)
        {
            FrmLogin loginFrm = new FrmLogin(this);
            loginFrm.MdiParent = this;
            OrganizeMenuStrip(false); // disable the menu strip
            loginFrm.Show();
        }
        /// <summary>
        /// load the login form again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuLogout_Click(object sender, EventArgs e)
        {
            closeAllActiveForms();

            FrmLogin loginFrm = new FrmLogin(this);
            loginFrm.MdiParent = this;
            mnuUser.Visible = false; // dont show the user anymore
            OrganizeMenuStrip(false); // and disable the menu strip
            loginFrm.Show();
        }
        /// <summary>
        /// load the permissions Query and place it into a datatable 
        /// then open the form in the mdi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPermissions_Click(object sender, EventArgs e)
        {
            FrmPermissions permissionsFrm = new FrmPermissions("qryPermissions", _dtb);
            permissionsFrm.MdiParent = this;
            permissionsFrm.Show();
        }
        #endregion
    }
}
