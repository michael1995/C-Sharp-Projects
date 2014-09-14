namespace ChocoMambo
{
    partial class frmParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParent));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierPurchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.rawIngredientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.branchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPermissions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuUser,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(743, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.mnuAddEmployee,
            this.customerToolStripMenuItem1,
            this.ordersToolStripMenuItem,
            this.productToolStripMenuItem,
            this.toolStripSeparator1,
            this.supplierToolStripMenuItem,
            this.supplierPurchaseToolStripMenuItem,
            this.rawIngredientsToolStripMenuItem,
            this.toolStripSeparator2,
            this.branchToolStripMenuItem,
            this.toolStripSeparator3,
            this.mnuPermissions});
            this.mnuFile.Image = ((System.Drawing.Image)(resources.GetObject("mnuFile.Image")));
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(53, 20);
            this.mnuFile.Text = "&File";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuAddEmployee
            // 
            this.mnuAddEmployee.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddEmployee.Image")));
            this.mnuAddEmployee.Name = "mnuAddEmployee";
            this.mnuAddEmployee.Size = new System.Drawing.Size(168, 22);
            this.mnuAddEmployee.Text = "Add &Employee";
            this.mnuAddEmployee.Click += new System.EventHandler(this.mnuAddEmployee_Click);
            // 
            // customerToolStripMenuItem1
            // 
            this.customerToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddCustomer});
            this.customerToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("customerToolStripMenuItem1.Image")));
            this.customerToolStripMenuItem1.Name = "customerToolStripMenuItem1";
            this.customerToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.customerToolStripMenuItem1.Text = "&Customer";
            // 
            // mnuAddCustomer
            // 
            this.mnuAddCustomer.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddCustomer.Image")));
            this.mnuAddCustomer.Name = "mnuAddCustomer";
            this.mnuAddCustomer.Size = new System.Drawing.Size(151, 22);
            this.mnuAddCustomer.Text = "&Add Customer";
            this.mnuAddCustomer.Click += new System.EventHandler(this.mnuAddCustomer_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddOrder});
            this.ordersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ordersToolStripMenuItem.Image")));
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.ordersToolStripMenuItem.Text = "&Orders";
            // 
            // mnuAddOrder
            // 
            this.mnuAddOrder.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddOrder.Image")));
            this.mnuAddOrder.Name = "mnuAddOrder";
            this.mnuAddOrder.Size = new System.Drawing.Size(129, 22);
            this.mnuAddOrder.Text = "&Add Order";
            this.mnuAddOrder.Click += new System.EventHandler(this.mnuAddOrder_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddProduct});
            this.productToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("productToolStripMenuItem.Image")));
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.productToolStripMenuItem.Text = "&Product";
            // 
            // mnuAddProduct
            // 
            this.mnuAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddProduct.Image")));
            this.mnuAddProduct.Name = "mnuAddProduct";
            this.mnuAddProduct.Size = new System.Drawing.Size(141, 22);
            this.mnuAddProduct.Text = "&Add Product";
            this.mnuAddProduct.Click += new System.EventHandler(this.mnuAddProduct_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddSupplier});
            this.supplierToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("supplierToolStripMenuItem.Image")));
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.supplierToolStripMenuItem.Text = "&Supplier";
            // 
            // mnuAddSupplier
            // 
            this.mnuAddSupplier.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddSupplier.Image")));
            this.mnuAddSupplier.Name = "mnuAddSupplier";
            this.mnuAddSupplier.Size = new System.Drawing.Size(142, 22);
            this.mnuAddSupplier.Text = "&Add Supplier";
            this.mnuAddSupplier.Click += new System.EventHandler(this.mnuAddSupplier_Click);
            // 
            // supplierPurchaseToolStripMenuItem
            // 
            this.supplierPurchaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPurchase});
            this.supplierPurchaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("supplierPurchaseToolStripMenuItem.Image")));
            this.supplierPurchaseToolStripMenuItem.Name = "supplierPurchaseToolStripMenuItem";
            this.supplierPurchaseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.supplierPurchaseToolStripMenuItem.Text = "S&upplier Purchase";
            // 
            // mnuPurchase
            // 
            this.mnuPurchase.Image = ((System.Drawing.Image)(resources.GetObject("mnuPurchase.Image")));
            this.mnuPurchase.Name = "mnuPurchase";
            this.mnuPurchase.Size = new System.Drawing.Size(147, 22);
            this.mnuPurchase.Text = "&Add Purchase";
            this.mnuPurchase.Click += new System.EventHandler(this.mnuPurchase_Click);
            // 
            // rawIngredientsToolStripMenuItem
            // 
            this.rawIngredientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd});
            this.rawIngredientsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rawIngredientsToolStripMenuItem.Image")));
            this.rawIngredientsToolStripMenuItem.Name = "rawIngredientsToolStripMenuItem";
            this.rawIngredientsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.rawIngredientsToolStripMenuItem.Text = "&Raw Ingredients";
            // 
            // mnuAdd
            // 
            this.mnuAdd.Image = ((System.Drawing.Image)(resources.GetObject("mnuAdd.Image")));
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(158, 22);
            this.mnuAdd.Text = "&Add Ingredients";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // branchToolStripMenuItem
            // 
            this.branchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAd});
            this.branchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("branchToolStripMenuItem.Image")));
            this.branchToolStripMenuItem.Name = "branchToolStripMenuItem";
            this.branchToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.branchToolStripMenuItem.Text = "&Branch";
            // 
            // mnuAd
            // 
            this.mnuAd.Image = ((System.Drawing.Image)(resources.GetObject("mnuAd.Image")));
            this.mnuAd.Name = "mnuAd";
            this.mnuAd.Size = new System.Drawing.Size(136, 22);
            this.mnuAd.Text = "&Add Branch";
            this.mnuAd.Click += new System.EventHandler(this.mnuAd_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuPermissions
            // 
            this.mnuPermissions.Image = ((System.Drawing.Image)(resources.GetObject("mnuPermissions.Image")));
            this.mnuPermissions.Name = "mnuPermissions";
            this.mnuPermissions.Size = new System.Drawing.Size(168, 22);
            this.mnuPermissions.Text = "&Permissions";
            this.mnuPermissions.Click += new System.EventHandler(this.mnuPermissions_Click);
            // 
            // mnuUser
            // 
            this.mnuUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogout});
            this.mnuUser.Image = ((System.Drawing.Image)(resources.GetObject("mnuUser.Image")));
            this.mnuUser.MergeIndex = 0;
            this.mnuUser.Name = "mnuUser";
            this.mnuUser.Size = new System.Drawing.Size(58, 20);
            this.mnuUser.Text = "&User";
            this.mnuUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.mnuUser.Visible = false;
            // 
            // mnuLogout
            // 
            this.mnuLogout.Image = ((System.Drawing.Image)(resources.GetObject("mnuLogout.Image")));
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(112, 22);
            this.mnuLogout.Text = "&Logout";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewEmployee});
            this.viewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewToolStripMenuItem.Image")));
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.viewToolStripMenuItem.Text = "&View ";
            // 
            // mnuViewEmployee
            // 
            this.mnuViewEmployee.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewEmployee.Image")));
            this.mnuViewEmployee.Name = "mnuViewEmployee";
            this.mnuViewEmployee.Size = new System.Drawing.Size(154, 22);
            this.mnuViewEmployee.Text = "View &Employee";
            this.mnuViewEmployee.Click += new System.EventHandler(this.mnuViewEmployee_Click);
            // 
            // frmParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(743, 377);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "frmParent";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChocoMambo";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmParent_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuAddEmployee;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCustomer;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAddOrder;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAddProduct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSupplier;
        private System.Windows.Forms.ToolStripMenuItem supplierPurchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPurchase;
        private System.Windows.Forms.ToolStripMenuItem rawIngredientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem branchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuUser;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuPermissions;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuViewEmployee;
    }
}

