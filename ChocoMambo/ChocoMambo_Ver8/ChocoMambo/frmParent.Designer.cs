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
            this.mnuAddCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAddProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddSupplierPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRawIngredient = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddAccessLevels = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuViewEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuViewSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewSupplierPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewRawIngredients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuViewBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAccessLevels = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuUser,
            this.mnuViewProducts});
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
            this.mnuAddCustomer,
            this.mnuAddOrder,
            this.MnuAddProduct,
            this.toolStripSeparator1,
            this.mnuAddSupplier,
            this.mnuAddSupplierPurchase,
            this.mnuAddRawIngredient,
            this.toolStripSeparator2,
            this.mnuAddBranch,
            this.toolStripSeparator3,
            this.mnuAddAccessLevels});
            this.mnuFile.Image = ((System.Drawing.Image)(resources.GetObject("mnuFile.Image")));
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(53, 20);
            this.mnuFile.Text = "&File";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuAddEmployee
            // 
            this.mnuAddEmployee.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddEmployee.Image")));
            this.mnuAddEmployee.Name = "mnuAddEmployee";
            this.mnuAddEmployee.Size = new System.Drawing.Size(193, 22);
            this.mnuAddEmployee.Text = "Add &Employee";
            this.mnuAddEmployee.Click += new System.EventHandler(this.mnuAddEmployee_Click);
            // 
            // mnuAddCustomer
            // 
            this.mnuAddCustomer.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddCustomer.Image")));
            this.mnuAddCustomer.Name = "mnuAddCustomer";
            this.mnuAddCustomer.Size = new System.Drawing.Size(193, 22);
            this.mnuAddCustomer.Text = "Add &Customer";
            this.mnuAddCustomer.Click += new System.EventHandler(this.mnuAddCustomer_Click);
            // 
            // mnuAddOrder
            // 
            this.mnuAddOrder.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddOrder.Image")));
            this.mnuAddOrder.Name = "mnuAddOrder";
            this.mnuAddOrder.Size = new System.Drawing.Size(193, 22);
            this.mnuAddOrder.Text = "Add &Order";
            this.mnuAddOrder.Click += new System.EventHandler(this.mnuAddOrder_Click);
            // 
            // MnuAddProduct
            // 
            this.MnuAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("MnuAddProduct.Image")));
            this.MnuAddProduct.Name = "MnuAddProduct";
            this.MnuAddProduct.Size = new System.Drawing.Size(193, 22);
            this.MnuAddProduct.Text = "Add &Product";
            this.MnuAddProduct.Click += new System.EventHandler(this.MnuAddProduct_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuAddSupplier
            // 
            this.mnuAddSupplier.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddSupplier.Image")));
            this.mnuAddSupplier.Name = "mnuAddSupplier";
            this.mnuAddSupplier.Size = new System.Drawing.Size(193, 22);
            this.mnuAddSupplier.Text = "Add &Supplier";
            this.mnuAddSupplier.Click += new System.EventHandler(this.mnuAddSupplier_Click);
            // 
            // mnuAddSupplierPurchase
            // 
            this.mnuAddSupplierPurchase.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddSupplierPurchase.Image")));
            this.mnuAddSupplierPurchase.Name = "mnuAddSupplierPurchase";
            this.mnuAddSupplierPurchase.Size = new System.Drawing.Size(193, 22);
            this.mnuAddSupplierPurchase.Text = "Add S&upplier Purchase";
            this.mnuAddSupplierPurchase.Click += new System.EventHandler(this.mnuAddSupplierPurchase_Click);
            // 
            // mnuAddRawIngredient
            // 
            this.mnuAddRawIngredient.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddRawIngredient.Image")));
            this.mnuAddRawIngredient.Name = "mnuAddRawIngredient";
            this.mnuAddRawIngredient.Size = new System.Drawing.Size(193, 22);
            this.mnuAddRawIngredient.Text = "Add &Raw Ingredient";
            this.mnuAddRawIngredient.Click += new System.EventHandler(this.mnuAddRawIngredient_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuAddBranch
            // 
            this.mnuAddBranch.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddBranch.Image")));
            this.mnuAddBranch.Name = "mnuAddBranch";
            this.mnuAddBranch.Size = new System.Drawing.Size(193, 22);
            this.mnuAddBranch.Text = "Add &Branch";
            this.mnuAddBranch.Click += new System.EventHandler(this.mnuAddBranch_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuAddAccessLevels
            // 
            this.mnuAddAccessLevels.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddAccessLevels.Image")));
            this.mnuAddAccessLevels.Name = "mnuAddAccessLevels";
            this.mnuAddAccessLevels.Size = new System.Drawing.Size(193, 22);
            this.mnuAddAccessLevels.Text = "Add &Access Levels";
            this.mnuAddAccessLevels.Click += new System.EventHandler(this.mnuAddAccessLevels_Click);
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
            // mnuViewProducts
            // 
            this.mnuViewProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.mnuViewEmployee,
            this.mnuViewCustomer,
            this.mnuViewOrders,
            this.mnuViewProduct,
            this.toolStripSeparator6,
            this.mnuViewSupplier,
            this.mnuViewSupplierPurchase,
            this.mnuViewRawIngredients,
            this.toolStripSeparator7,
            this.mnuViewBranch,
            this.toolStripSeparator8,
            this.mnuAccessLevels});
            this.mnuViewProducts.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewProducts.Image")));
            this.mnuViewProducts.Name = "mnuViewProducts";
            this.mnuViewProducts.Size = new System.Drawing.Size(63, 20);
            this.mnuViewProducts.Text = "&View ";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuViewEmployee
            // 
            this.mnuViewEmployee.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewEmployee.Image")));
            this.mnuViewEmployee.Name = "mnuViewEmployee";
            this.mnuViewEmployee.Size = new System.Drawing.Size(201, 22);
            this.mnuViewEmployee.Text = "View &Employee\'s";
            this.mnuViewEmployee.Click += new System.EventHandler(this.mnuViewEmployee_Click);
            // 
            // mnuViewCustomer
            // 
            this.mnuViewCustomer.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewCustomer.Image")));
            this.mnuViewCustomer.Name = "mnuViewCustomer";
            this.mnuViewCustomer.Size = new System.Drawing.Size(201, 22);
            this.mnuViewCustomer.Text = "View &Customers";
            this.mnuViewCustomer.Click += new System.EventHandler(this.mnuViewCustomer_Click);
            // 
            // mnuViewOrders
            // 
            this.mnuViewOrders.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewOrders.Image")));
            this.mnuViewOrders.Name = "mnuViewOrders";
            this.mnuViewOrders.Size = new System.Drawing.Size(201, 22);
            this.mnuViewOrders.Text = "View &Orders";
            this.mnuViewOrders.Click += new System.EventHandler(this.mnuViewOrders_Click);
            // 
            // mnuViewProduct
            // 
            this.mnuViewProduct.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewProduct.Image")));
            this.mnuViewProduct.Name = "mnuViewProduct";
            this.mnuViewProduct.Size = new System.Drawing.Size(201, 22);
            this.mnuViewProduct.Text = "View &Products";
            this.mnuViewProduct.Click += new System.EventHandler(this.mnuViewProduct_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuViewSupplier
            // 
            this.mnuViewSupplier.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewSupplier.Image")));
            this.mnuViewSupplier.Name = "mnuViewSupplier";
            this.mnuViewSupplier.Size = new System.Drawing.Size(201, 22);
            this.mnuViewSupplier.Text = "View &Suppliers";
            this.mnuViewSupplier.Click += new System.EventHandler(this.mnuViewSupplier_Click);
            // 
            // mnuViewSupplierPurchase
            // 
            this.mnuViewSupplierPurchase.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewSupplierPurchase.Image")));
            this.mnuViewSupplierPurchase.Name = "mnuViewSupplierPurchase";
            this.mnuViewSupplierPurchase.Size = new System.Drawing.Size(201, 22);
            this.mnuViewSupplierPurchase.Text = "View S&upplier Purchases";
            this.mnuViewSupplierPurchase.Click += new System.EventHandler(this.mnuViewSupplierPurchase_Click);
            // 
            // mnuViewRawIngredients
            // 
            this.mnuViewRawIngredients.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewRawIngredients.Image")));
            this.mnuViewRawIngredients.Name = "mnuViewRawIngredients";
            this.mnuViewRawIngredients.Size = new System.Drawing.Size(201, 22);
            this.mnuViewRawIngredients.Text = "View &Raw Ingredients ";
            this.mnuViewRawIngredients.Click += new System.EventHandler(this.mnuViewRawIngredients_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuViewBranch
            // 
            this.mnuViewBranch.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewBranch.Image")));
            this.mnuViewBranch.Name = "mnuViewBranch";
            this.mnuViewBranch.Size = new System.Drawing.Size(201, 22);
            this.mnuViewBranch.Text = "View &Branch";
            this.mnuViewBranch.Click += new System.EventHandler(this.mnuViewBranch_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuAccessLevels
            // 
            this.mnuAccessLevels.Image = ((System.Drawing.Image)(resources.GetObject("mnuAccessLevels.Image")));
            this.mnuAccessLevels.Name = "mnuAccessLevels";
            this.mnuAccessLevels.Size = new System.Drawing.Size(201, 22);
            this.mnuAccessLevels.Text = "View &Access Levels";
            this.mnuAccessLevels.Click += new System.EventHandler(this.mnuAccessLevels_Click);
            // 
            // frmParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuUser;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuAddAccessLevels;
        private System.Windows.Forms.ToolStripMenuItem mnuViewProducts;
        private System.Windows.Forms.ToolStripMenuItem mnuViewEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuViewCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuAddOrder;
        private System.Windows.Forms.ToolStripMenuItem mnuViewOrders;
        private System.Windows.Forms.ToolStripMenuItem MnuAddProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuViewProduct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSupplier;
        private System.Windows.Forms.ToolStripMenuItem mnuViewSupplier;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSupplierPurchase;
        private System.Windows.Forms.ToolStripMenuItem mnuViewSupplierPurchase;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRawIngredient;
        private System.Windows.Forms.ToolStripMenuItem mnuViewRawIngredients;
        private System.Windows.Forms.ToolStripMenuItem mnuAddBranch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem mnuViewBranch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem mnuAccessLevels;
    }
}

