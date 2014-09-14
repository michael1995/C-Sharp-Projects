﻿using DBConnection;
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
    public partial class frmParent : Form
    {

        #region Global Variables
        int _intCounter = 0;
        DataTable dtb = new DataTable();
        #endregion

        #region Constructors
        public frmParent()
        {
            InitializeComponent();
        }
        #endregion 

        #region Properties

        public static Hashtable AccessRights { get; set; }

        public bool isMenuStripEnabled
        {
            get
            {
                return MainMenuStrip.Enabled;
            }

            set
            {
                MainMenuStrip.Enabled = value;
            }
        }

        public string UserName
        {
            get
            {
                return mnuUser.Text;
            }
            set
            {
                mnuUser.Text = value;
                mnuUser.Visible = true;
            }
        }

        #endregion 

        #region Accessors
        public void CheckAccessRights(string pStrFormName)
        {
            ToolStripItem[] MnuArray = new ToolStripItem[2] { mnuFile , mnuLogout };
            if (AccessRights[pStrFormName].ToString() == "Deny")
            {
                this.Close();
            }
            else if (AccessRights[pStrFormName].ToString() == "Read")
            {
                disableMenuButtons(MnuArray);
            }
            else if (AccessRights[pStrFormName].ToString() == "Write")
            {
                enableMenuButtons(MnuArray); 
            }
            else
            {
                enableMenuButtons(MnuArray);
            }
        }
        
        #endregion 

        #region Mutators 

        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }

        public void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControls(con.Parent);
            }
        }

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
        public void disableMenuButtons(ToolStripItem[] pMnuArray)
        {
            for (int i = 0; i < pMnuArray.Length; i++)
            {
                MainMenuStrip.Items[i].Enabled = false;
            }
        }

        public void enableMenuButtons(ToolStripItem[] pMnuArray)
        {
            for (int i = 0; i < pMnuArray.Length; i++)
            {
                MainMenuStrip.Items[i].Enabled = true;
            }
        }

        
        #endregion 

        #region Control Events

        private void mnuAddEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee employeeFrm = new frmEmployee();
            employeeFrm.Text = "Employee Form" + ++_intCounter;
            employeeFrm.MdiParent = this;
            employeeFrm.Show();
        }
        private void mnuViewEmployee_Click(object sender, EventArgs e)
        {
            frmView employeeViewFrm = new frmView("qryEmployeeActive", dtb, 1);
            employeeViewFrm.Text = "View Employee's" + ++_intCounter;
            employeeViewFrm.MdiParent = this;
            employeeViewFrm.Show();
        }
        private void mnuAddCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer customerFrm = new frmCustomer();
            customerFrm.MdiParent = this;
            customerFrm.Text = "Customer Form" + ++_intCounter;
            customerFrm.Show();
        }
        private void mnuViewCustomer_Click(object sender, EventArgs e)
        {
            frmView customerViewFrm = new frmView("qryCustomerActive", dtb, 2);
            customerViewFrm.Text = "View Customers" + ++_intCounter;
            customerViewFrm.MdiParent = this;
            customerViewFrm.Show();
        }
        private void mnuAddOrder_Click(object sender, EventArgs e)
        {
            frmOrders ordersFrm = new frmOrders();
            ordersFrm.MdiParent = this;
            ordersFrm.Text = "Order Form" + ++_intCounter;
            ordersFrm.Show();
        }
        private void mnuViewOrders_Click(object sender, EventArgs e)
        {
            frmView orderViewFrm = new frmView("qryOrdersActive", dtb, 3);
            orderViewFrm.Text = "View Employee's" + ++_intCounter;
            orderViewFrm.MdiParent = this;
            orderViewFrm.Show();
        }
        private void MnuAddProduct_Click(object sender, EventArgs e)
        {
            frmProduct productFrm = new frmProduct();
            productFrm.MdiParent = this;
            productFrm.Text = "Product Form" + ++_intCounter;
            productFrm.Show();
        }
        private void mnuViewProduct_Click(object sender, EventArgs e)
        {
            frmView productViewFrm = new frmView("qryProductActive", dtb, 4);
            productViewFrm.Text = "View Products" + ++_intCounter;
            productViewFrm.MdiParent = this;
            productViewFrm.Show();
        }
        private void mnuAddSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier supplierFrm = new frmSupplier();
            supplierFrm.MdiParent = this;
            supplierFrm.Text = "Supplier Form" + ++_intCounter;
            supplierFrm.Show();
        }
        private void mnuViewSupplier_Click(object sender, EventArgs e)
        {
            frmView supplierViewFrm = new frmView("qrySupplierActive", dtb, 5);
            supplierViewFrm.Text = "View Supplier" + ++_intCounter;
            supplierViewFrm.MdiParent = this;
            supplierViewFrm.Show();
        }
        private void mnuAddSupplierPurchase_Click(object sender, EventArgs e)
        {
            frmSupplierPurchase supplierpurchaseFrm = new frmSupplierPurchase();
            supplierpurchaseFrm.MdiParent = this;
            supplierpurchaseFrm.Text = "Supplier Purchase" + ++_intCounter;
            supplierpurchaseFrm.Show();
        }

        private void mnuViewSupplierPurchase_Click(object sender, EventArgs e)
        {
            frmView supplierpurchaseViewFrm = new frmView("qrySupplierPurchaseActive", dtb, 6);
            supplierpurchaseViewFrm.Text = "View Supplier Purchases" + ++_intCounter;
            supplierpurchaseViewFrm.MdiParent = this;
            supplierpurchaseViewFrm.Show();
        }
        private void mnuAddRawIngredient_Click(object sender, EventArgs e)
        {
            frmRawIngredients rawingredientsFrm = new frmRawIngredients();
            rawingredientsFrm.MdiParent = this;
            rawingredientsFrm.Text = "Raw Ingredient" + ++_intCounter;
            rawingredientsFrm.Show();
        }
        private void mnuViewRawIngredients_Click(object sender, EventArgs e)
        {
            frmView rawingredientsViewFrm = new frmView("qryRawIngredientsActive", dtb, 7);
            rawingredientsViewFrm.Text = "View Raw Ingredients" + ++_intCounter;
            rawingredientsViewFrm.MdiParent = this;
            rawingredientsViewFrm.Show();
        }
        private void mnuAddBranch_Click(object sender, EventArgs e)
        {
            frmBranch branchFrm = new frmBranch();
            branchFrm.MdiParent = this;
            branchFrm.Text = "Branch Form" + ++_intCounter;
            branchFrm.Show();
        }
        private void mnuViewBranch_Click(object sender, EventArgs e)
        {
            frmView branchViewFrm = new frmView("qryBranchActive", dtb, 8);
            branchViewFrm.Text = "View Branch" + ++_intCounter;
            branchViewFrm.MdiParent = this;
            branchViewFrm.Show();
        }


        private void frmParent_Load(object sender, EventArgs e)
        {
            frmLogin loginFrm = new frmLogin(this);
            loginFrm.MdiParent = this;
            isMenuStripEnabled = false;
            loginFrm.Show();

        }

        private void mnuPermissions_Click(object sender, EventArgs e)
        {
            frmPermissions permissionFrm = new frmPermissions();
            permissionFrm.MdiParent = this;
            permissionFrm.Text = "Permission Form" + ++_intCounter;
            permissionFrm.Show();
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            closeAllActiveForms();

            frmLogin loginFrm = new frmLogin(this);
            loginFrm.MdiParent = this;
            isMenuStripEnabled = false;
            mnuUser.Visible = false;
            loginFrm.Show();
             
        }

        #endregion
    }
}
