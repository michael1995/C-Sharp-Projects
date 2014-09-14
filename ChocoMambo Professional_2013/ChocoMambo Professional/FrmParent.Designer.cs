namespace ChocoMambo_Professional
{
    partial class FrmParent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParent));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSupplierPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRawIngredients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuViewEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuViewSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewSupplierPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewRawIngredient = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuViewBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdminHub = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPermissions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuView,
            this.mnuUser,
            this.mnuAdminHub});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(747, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "Main";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.mnuEmployee,
            this.mnuCustomer,
            this.mnuOrder,
            this.mnuProduct,
            this.toolStripSeparator2,
            this.mnuSupplier,
            this.mnuSupplierPurchase,
            this.mnuRawIngredients,
            this.toolStripSeparator3,
            this.mnuBranch});
            this.mnuFile.Image = ((System.Drawing.Image)(resources.GetObject("mnuFile.Image")));
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(53, 20);
            this.mnuFile.Text = "&File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // mnuEmployee
            // 
            this.mnuEmployee.Image = ((System.Drawing.Image)(resources.GetObject("mnuEmployee.Image")));
            this.mnuEmployee.Name = "mnuEmployee";
            this.mnuEmployee.Size = new System.Drawing.Size(171, 22);
            this.mnuEmployee.Text = "&Employee";
            this.mnuEmployee.Click += new System.EventHandler(this.mnuEmployee_Click);
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Image = ((System.Drawing.Image)(resources.GetObject("mnuCustomer.Image")));
            this.mnuCustomer.Name = "mnuCustomer";
            this.mnuCustomer.Size = new System.Drawing.Size(171, 22);
            this.mnuCustomer.Text = "&Customer";
            this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);
            // 
            // mnuOrder
            // 
            this.mnuOrder.Image = ((System.Drawing.Image)(resources.GetObject("mnuOrder.Image")));
            this.mnuOrder.Name = "mnuOrder";
            this.mnuOrder.Size = new System.Drawing.Size(171, 22);
            this.mnuOrder.Text = "&Order";
            this.mnuOrder.Click += new System.EventHandler(this.mnuOrder_Click);
            // 
            // mnuProduct
            // 
            this.mnuProduct.Image = ((System.Drawing.Image)(resources.GetObject("mnuProduct.Image")));
            this.mnuProduct.Name = "mnuProduct";
            this.mnuProduct.Size = new System.Drawing.Size(171, 22);
            this.mnuProduct.Text = "&Product";
            this.mnuProduct.Click += new System.EventHandler(this.mnuProduct_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(168, 6);
            // 
            // mnuSupplier
            // 
            this.mnuSupplier.Image = ((System.Drawing.Image)(resources.GetObject("mnuSupplier.Image")));
            this.mnuSupplier.Name = "mnuSupplier";
            this.mnuSupplier.Size = new System.Drawing.Size(171, 22);
            this.mnuSupplier.Text = "&Supplier";
            this.mnuSupplier.Click += new System.EventHandler(this.mnuSupplier_Click);
            // 
            // mnuSupplierPurchase
            // 
            this.mnuSupplierPurchase.Image = ((System.Drawing.Image)(resources.GetObject("mnuSupplierPurchase.Image")));
            this.mnuSupplierPurchase.Name = "mnuSupplierPurchase";
            this.mnuSupplierPurchase.Size = new System.Drawing.Size(171, 22);
            this.mnuSupplierPurchase.Text = "S&upplier Purchase ";
            this.mnuSupplierPurchase.Click += new System.EventHandler(this.mnuSupplierPurchase_Click);
            // 
            // mnuRawIngredients
            // 
            this.mnuRawIngredients.Image = ((System.Drawing.Image)(resources.GetObject("mnuRawIngredients.Image")));
            this.mnuRawIngredients.Name = "mnuRawIngredients";
            this.mnuRawIngredients.Size = new System.Drawing.Size(171, 22);
            this.mnuRawIngredients.Text = "&Raw Ingredients";
            this.mnuRawIngredients.Click += new System.EventHandler(this.mnuRawIngredients_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(168, 6);
            // 
            // mnuBranch
            // 
            this.mnuBranch.Image = ((System.Drawing.Image)(resources.GetObject("mnuBranch.Image")));
            this.mnuBranch.Name = "mnuBranch";
            this.mnuBranch.Size = new System.Drawing.Size(171, 22);
            this.mnuBranch.Text = "&Branch";
            this.mnuBranch.Click += new System.EventHandler(this.mnuBranch_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.mnuViewEmployee,
            this.mnuViewCustomer,
            this.mnuViewOrder,
            this.mnuViewProduct,
            this.toolStripSeparator5,
            this.mnuViewSupplier,
            this.mnuViewSupplierPurchase,
            this.mnuViewRawIngredient,
            this.toolStripSeparator6,
            this.mnuViewBranch});
            this.mnuView.Image = ((System.Drawing.Image)(resources.GetObject("mnuView.Image")));
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(63, 20);
            this.mnuView.Text = "&View ";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuViewEmployee
            // 
            this.mnuViewEmployee.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewEmployee.Image")));
            this.mnuViewEmployee.Name = "mnuViewEmployee";
            this.mnuViewEmployee.Size = new System.Drawing.Size(168, 22);
            this.mnuViewEmployee.Text = "&Employee";
            this.mnuViewEmployee.Click += new System.EventHandler(this.mnuViewEmployee_Click);
            // 
            // mnuViewCustomer
            // 
            this.mnuViewCustomer.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewCustomer.Image")));
            this.mnuViewCustomer.Name = "mnuViewCustomer";
            this.mnuViewCustomer.Size = new System.Drawing.Size(168, 22);
            this.mnuViewCustomer.Text = "&Customer";
            this.mnuViewCustomer.Click += new System.EventHandler(this.mnuViewCustomer_Click);
            // 
            // mnuViewOrder
            // 
            this.mnuViewOrder.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewOrder.Image")));
            this.mnuViewOrder.Name = "mnuViewOrder";
            this.mnuViewOrder.Size = new System.Drawing.Size(168, 22);
            this.mnuViewOrder.Text = "&Order";
            this.mnuViewOrder.Click += new System.EventHandler(this.mnuViewOrder_Click);
            // 
            // mnuViewProduct
            // 
            this.mnuViewProduct.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewProduct.Image")));
            this.mnuViewProduct.Name = "mnuViewProduct";
            this.mnuViewProduct.Size = new System.Drawing.Size(168, 22);
            this.mnuViewProduct.Text = "&Product";
            this.mnuViewProduct.Click += new System.EventHandler(this.mnuViewProduct_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuViewSupplier
            // 
            this.mnuViewSupplier.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewSupplier.Image")));
            this.mnuViewSupplier.Name = "mnuViewSupplier";
            this.mnuViewSupplier.Size = new System.Drawing.Size(168, 22);
            this.mnuViewSupplier.Text = "&Supplier";
            this.mnuViewSupplier.Click += new System.EventHandler(this.mnuViewSupplier_Click);
            // 
            // mnuViewSupplierPurchase
            // 
            this.mnuViewSupplierPurchase.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewSupplierPurchase.Image")));
            this.mnuViewSupplierPurchase.Name = "mnuViewSupplierPurchase";
            this.mnuViewSupplierPurchase.Size = new System.Drawing.Size(168, 22);
            this.mnuViewSupplierPurchase.Text = "&Supplier Purchase";
            this.mnuViewSupplierPurchase.Click += new System.EventHandler(this.mnuViewSupplierPurchase_Click);
            // 
            // mnuViewRawIngredient
            // 
            this.mnuViewRawIngredient.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewRawIngredient.Image")));
            this.mnuViewRawIngredient.Name = "mnuViewRawIngredient";
            this.mnuViewRawIngredient.Size = new System.Drawing.Size(168, 22);
            this.mnuViewRawIngredient.Text = "&Raw Ingredient";
            this.mnuViewRawIngredient.Click += new System.EventHandler(this.mnuViewRawIngredient_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuViewBranch
            // 
            this.mnuViewBranch.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewBranch.Image")));
            this.mnuViewBranch.Name = "mnuViewBranch";
            this.mnuViewBranch.Size = new System.Drawing.Size(168, 22);
            this.mnuViewBranch.Text = "&Branch";
            this.mnuViewBranch.Click += new System.EventHandler(this.mnuViewBranch_Click);
            // 
            // mnuUser
            // 
            this.mnuUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogout});
            this.mnuUser.Image = ((System.Drawing.Image)(resources.GetObject("mnuUser.Image")));
            this.mnuUser.Name = "mnuUser";
            this.mnuUser.Size = new System.Drawing.Size(58, 20);
            this.mnuUser.Text = "&User";
            this.mnuUser.Visible = false;
            // 
            // mnuLogout
            // 
            this.mnuLogout.Image = ((System.Drawing.Image)(resources.GetObject("mnuLogout.Image")));
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(115, 22);
            this.mnuLogout.Text = "&Log out";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // mnuAdminHub
            // 
            this.mnuAdminHub.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuAdminHub.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPermissions});
            this.mnuAdminHub.Image = ((System.Drawing.Image)(resources.GetObject("mnuAdminHub.Image")));
            this.mnuAdminHub.Name = "mnuAdminHub";
            this.mnuAdminHub.Size = new System.Drawing.Size(97, 20);
            this.mnuAdminHub.Text = "&Admin Hub";
            this.mnuAdminHub.Visible = false;
            // 
            // mnuPermissions
            // 
            this.mnuPermissions.Image = ((System.Drawing.Image)(resources.GetObject("mnuPermissions.Image")));
            this.mnuPermissions.Name = "mnuPermissions";
            this.mnuPermissions.Size = new System.Drawing.Size(137, 22);
            this.mnuPermissions.Text = "&Permissions";
            this.mnuPermissions.Click += new System.EventHandler(this.mnuPermissions_Click);
            // 
            // FrmParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 336);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FrmParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChocoMambo Professional Edition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmParent_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuOrder;
        private System.Windows.Forms.ToolStripMenuItem mnuProduct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuSupplier;
        private System.Windows.Forms.ToolStripMenuItem mnuSupplierPurchase;
        private System.Windows.Forms.ToolStripMenuItem mnuRawIngredients;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuBranch;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuViewEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuViewCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuViewOrder;
        private System.Windows.Forms.ToolStripMenuItem mnuViewProduct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuViewSupplier;
        private System.Windows.Forms.ToolStripMenuItem mnuViewSupplierPurchase;
        private System.Windows.Forms.ToolStripMenuItem mnuViewRawIngredient;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuViewBranch;
        private System.Windows.Forms.ToolStripMenuItem mnuUser;
        private System.Windows.Forms.ToolStripMenuItem mnuAdminHub;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuPermissions;
    }
}