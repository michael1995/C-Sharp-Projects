﻿namespace ChocoMambo
{
    partial class frmSupplierPurchase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierPurchase));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.dtpDatePurchased = new System.Windows.Forms.DateTimePicker();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.MaskedTextBox();
            this.txtLineTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboRawIngredients = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvOrderLines = new System.Windows.Forms.DataGridView();
            this.PurchaseLineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierLineQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierLineSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RawIngredientsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPurchaseCode = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderLines)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(660, 144);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox3.Controls.Add(this.cbActive);
            this.groupBox3.Controls.Add(this.dtpDatePurchased);
            this.groupBox3.Controls.Add(this.cboBranch);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cboSupplier);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(2, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 127);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Supplier Purchase Details";
            // 
            // cbActive
            // 
            this.cbActive.Checked = true;
            this.cbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActive.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbActive.Location = new System.Drawing.Point(248, 104);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(25, 24);
            this.cbActive.TabIndex = 0;
            this.cbActive.UseVisualStyleBackColor = true;
            this.cbActive.Visible = false;
            // 
            // dtpDatePurchased
            // 
            this.dtpDatePurchased.CustomFormat = "dd-MMM-yyyy";
            this.dtpDatePurchased.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatePurchased.Location = new System.Drawing.Point(138, 76);
            this.dtpDatePurchased.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDatePurchased.Name = "dtpDatePurchased";
            this.dtpDatePurchased.Size = new System.Drawing.Size(140, 20);
            this.dtpDatePurchased.TabIndex = 4;
            // 
            // cboBranch
            // 
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(138, 54);
            this.cboBranch.Margin = new System.Windows.Forms.Padding(2);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(140, 21);
            this.cboBranch.TabIndex = 3;
            this.cboBranch.SelectedValueChanged += new System.EventHandler(this.cboBranch_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date Purchased";
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(138, 31);
            this.cboSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(140, 21);
            this.cboSupplier.TabIndex = 2;
            this.cboSupplier.SelectedValueChanged += new System.EventHandler(this.cboSupplier_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Branch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.txtLineTotal);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cboRawIngredients);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(384, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 127);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Details";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(90, 40);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(68, 20);
            this.txtPrice.TabIndex = 7;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(90, 64);
            this.txtQuantity.Mask = "00000";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PromptChar = '.';
            this.txtQuantity.Size = new System.Drawing.Size(68, 20);
            this.txtQuantity.TabIndex = 8;
            this.txtQuantity.ValidatingType = typeof(int);
            this.txtQuantity.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // txtLineTotal
            // 
            this.txtLineTotal.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtLineTotal.Enabled = false;
            this.txtLineTotal.Location = new System.Drawing.Point(90, 88);
            this.txtLineTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtLineTotal.Name = "txtLineTotal";
            this.txtLineTotal.ShortcutsEnabled = false;
            this.txtLineTotal.Size = new System.Drawing.Size(140, 20);
            this.txtLineTotal.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 90);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Line Total";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 67);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Raw Ingredients";
            // 
            // cboRawIngredients
            // 
            this.cboRawIngredients.FormattingEnabled = true;
            this.cboRawIngredients.Location = new System.Drawing.Point(90, 16);
            this.cboRawIngredients.Margin = new System.Windows.Forms.Padding(2);
            this.cboRawIngredients.Name = "cboRawIngredients";
            this.cboRawIngredients.Size = new System.Drawing.Size(140, 21);
            this.cboRawIngredients.TabIndex = 6;
            this.cboRawIngredients.Leave += new System.EventHandler(this.cboRawIngredients_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 45);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Price";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.dgvOrderLines);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 144);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 242);
            this.panel1.TabIndex = 3;
            // 
            // dgvOrderLines
            // 
            this.dgvOrderLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderLines.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvOrderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PurchaseLineID,
            this.IngredientName,
            this.Price,
            this.SupplierLineQty,
            this.SupplierLineSubTotal,
            this.RawIngredientsID,
            this.PurchaseID});
            this.dgvOrderLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderLines.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderLines.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOrderLines.Name = "dgvOrderLines";
            this.dgvOrderLines.ReadOnly = true;
            this.dgvOrderLines.RowTemplate.Height = 28;
            this.dgvOrderLines.Size = new System.Drawing.Size(660, 242);
            this.dgvOrderLines.TabIndex = 10;
            this.dgvOrderLines.TabStop = false;
            // 
            // PurchaseLineID
            // 
            this.PurchaseLineID.DataPropertyName = "PurchaseLineID";
            this.PurchaseLineID.HeaderText = "PurchaseLineID";
            this.PurchaseLineID.Name = "PurchaseLineID";
            this.PurchaseLineID.ReadOnly = true;
            this.PurchaseLineID.Visible = false;
            // 
            // IngredientName
            // 
            this.IngredientName.DataPropertyName = "IngredientName";
            this.IngredientName.FillWeight = 64.82982F;
            this.IngredientName.HeaderText = "IngredientName";
            this.IngredientName.Name = "IngredientName";
            this.IngredientName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle1.Format = "c2";
            this.Price.DefaultCellStyle = dataGridViewCellStyle1;
            this.Price.FillWeight = 90.98853F;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // SupplierLineQty
            // 
            this.SupplierLineQty.DataPropertyName = "SupplierLineQty";
            this.SupplierLineQty.FillWeight = 112.9076F;
            this.SupplierLineQty.HeaderText = "LineQty";
            this.SupplierLineQty.Name = "SupplierLineQty";
            this.SupplierLineQty.ReadOnly = true;
            // 
            // SupplierLineSubTotal
            // 
            this.SupplierLineSubTotal.DataPropertyName = "SupplierLineSubTotal";
            dataGridViewCellStyle2.Format = "c2";
            this.SupplierLineSubTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.SupplierLineSubTotal.FillWeight = 131.2741F;
            this.SupplierLineSubTotal.HeaderText = "LineTotal";
            this.SupplierLineSubTotal.Name = "SupplierLineSubTotal";
            this.SupplierLineSubTotal.ReadOnly = true;
            // 
            // RawIngredientsID
            // 
            this.RawIngredientsID.DataPropertyName = "RawIngredientsID";
            this.RawIngredientsID.HeaderText = "RawIngredientsID";
            this.RawIngredientsID.Name = "RawIngredientsID";
            this.RawIngredientsID.ReadOnly = true;
            this.RawIngredientsID.Visible = false;
            // 
            // PurchaseID
            // 
            this.PurchaseID.DataPropertyName = "PurchaseID";
            this.PurchaseID.HeaderText = "PurchaseID";
            this.PurchaseID.Name = "PurchaseID";
            this.PurchaseID.ReadOnly = true;
            this.PurchaseID.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCancel,
            this.mnuDeleteOrder,
            this.mnuDelete,
            this.mnuInsert,
            this.mnuSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 386);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(660, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCancel
            // 
            this.mnuCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuCancel.Enabled = false;
            this.mnuCancel.Image = ((System.Drawing.Image)(resources.GetObject("mnuCancel.Image")));
            this.mnuCancel.Name = "mnuCancel";
            this.mnuCancel.Size = new System.Drawing.Size(71, 20);
            this.mnuCancel.Text = "&Cancel";
            this.mnuCancel.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // mnuDeleteOrder
            // 
            this.mnuDeleteOrder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuDeleteOrder.Enabled = false;
            this.mnuDeleteOrder.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteOrder.Image")));
            this.mnuDeleteOrder.Name = "mnuDeleteOrder";
            this.mnuDeleteOrder.Size = new System.Drawing.Size(101, 20);
            this.mnuDeleteOrder.Text = "&Delete Order";
            this.mnuDeleteOrder.Click += new System.EventHandler(this.mnuDeleteOrder_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuDelete.Enabled = false;
            this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(93, 20);
            this.mnuDelete.Text = "&Delete Line";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuInsert
            // 
            this.mnuInsert.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuInsert.Enabled = false;
            this.mnuInsert.Image = ((System.Drawing.Image)(resources.GetObject("mnuInsert.Image")));
            this.mnuInsert.Name = "mnuInsert";
            this.mnuInsert.Size = new System.Drawing.Size(64, 20);
            this.mnuInsert.Text = "&Insert";
            this.mnuInsert.Click += new System.EventHandler(this.mnuInsert_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuSave.Enabled = false;
            this.mnuSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuSave.Image")));
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(59, 20);
            this.mnuSave.Text = "&Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtPurchaseCode);
            this.panel2.Controls.Add(this.txtTotalAmount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 34);
            this.panel2.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 10);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Purchase Code";
            // 
            // txtPurchaseCode
            // 
            this.txtPurchaseCode.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtPurchaseCode.Location = new System.Drawing.Point(144, 7);
            this.txtPurchaseCode.Name = "txtPurchaseCode";
            this.txtPurchaseCode.ReadOnly = true;
            this.txtPurchaseCode.Size = new System.Drawing.Size(140, 20);
            this.txtPurchaseCode.TabIndex = 17;
            this.txtPurchaseCode.TabStop = false;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Location = new System.Drawing.Point(503, 6);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(140, 20);
            this.txtTotalAmount.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total";
            // 
            // frmSupplierPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 410);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSupplierPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Purchase";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderLines)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboRawIngredients;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuInsert;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuCancel;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteOrder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvOrderLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseLineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierLineQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierLineSubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn RawIngredientsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseID;
        private System.Windows.Forms.MaskedTextBox txtQuantity;
        private System.Windows.Forms.TextBox txtLineTotal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.DateTimePicker dtpDatePurchased;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPurchaseCode;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label4;

    }
}