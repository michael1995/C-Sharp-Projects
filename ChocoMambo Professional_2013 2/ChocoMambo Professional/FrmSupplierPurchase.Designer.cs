namespace ChocoMambo_Professional
{
    partial class FrmSupplierPurchase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSupplierPurchase));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPurchaseCode = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLineTotal = new System.Windows.Forms.TextBox();
            this.cboRawIngredients = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.dtpDatePurchased = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpSupplierPurchaseLine = new System.Windows.Forms.GroupBox();
            this.dgvPurchaseLines = new System.Windows.Forms.DataGridView();
            this.mnuSupplierPurchase = new System.Windows.Forms.MenuStrip();
            this.mnuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mnuDeletePurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpSupplierPurchaseLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseLines)).BeginInit();
            this.mnuSupplierPurchase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPurchaseCode);
            this.groupBox3.Controls.Add(this.txtTotalAmount);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(506, 288);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 88);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Purchase For / Purchase Total ";
            // 
            // txtPurchaseCode
            // 
            this.txtPurchaseCode.Location = new System.Drawing.Point(90, 29);
            this.txtPurchaseCode.Name = "txtPurchaseCode";
            this.txtPurchaseCode.ReadOnly = true;
            this.txtPurchaseCode.Size = new System.Drawing.Size(121, 20);
            this.txtPurchaseCode.TabIndex = 0;
            this.txtPurchaseCode.TabStop = false;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(90, 56);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(80, 20);
            this.txtTotalAmount.TabIndex = 0;
            this.txtTotalAmount.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Order Total";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Purchase Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtLineTotal);
            this.groupBox2.Controls.Add(this.cboRawIngredients);
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(506, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 136);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Raw Ingredients Details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Line Total";
            // 
            // txtLineTotal
            // 
            this.txtLineTotal.Location = new System.Drawing.Point(90, 104);
            this.txtLineTotal.Name = "txtLineTotal";
            this.txtLineTotal.ReadOnly = true;
            this.txtLineTotal.Size = new System.Drawing.Size(121, 20);
            this.txtLineTotal.TabIndex = 9;
            // 
            // cboRawIngredients
            // 
            this.cboRawIngredients.FormattingEnabled = true;
            this.cboRawIngredients.Location = new System.Drawing.Point(90, 28);
            this.cboRawIngredients.Name = "cboRawIngredients";
            this.cboRawIngredients.Size = new System.Drawing.Size(121, 21);
            this.cboRawIngredients.TabIndex = 6;
            this.cboRawIngredients.TextChanged += new System.EventHandler(this.cboRawIngredients_TextChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(90, 80);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(80, 20);
            this.txtQuantity.TabIndex = 8;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            this.txtQuantity.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(90, 56);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(80, 20);
            this.txtPrice.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Quantity          #";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Price               $";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Raw Ingredients";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboBranch);
            this.groupBox1.Controls.Add(this.dtpDatePurchased);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboSupplier);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(506, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 128);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier Purchase Details";
            // 
            // cboBranch
            // 
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(90, 59);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(121, 21);
            this.cboBranch.TabIndex = 3;
            // 
            // dtpDatePurchased
            // 
            this.dtpDatePurchased.Location = new System.Drawing.Point(90, 92);
            this.dtpDatePurchased.Name = "dtpDatePurchased";
            this.dtpDatePurchased.Size = new System.Drawing.Size(200, 20);
            this.dtpDatePurchased.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Date Purchased";
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(90, 29);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(121, 21);
            this.cboSupplier.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Branch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // grpSupplierPurchaseLine
            // 
            this.grpSupplierPurchaseLine.Controls.Add(this.dgvPurchaseLines);
            this.grpSupplierPurchaseLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpSupplierPurchaseLine.Location = new System.Drawing.Point(10, 7);
            this.grpSupplierPurchaseLine.Name = "grpSupplierPurchaseLine";
            this.grpSupplierPurchaseLine.Size = new System.Drawing.Size(480, 369);
            this.grpSupplierPurchaseLine.TabIndex = 0;
            this.grpSupplierPurchaseLine.TabStop = false;
            this.grpSupplierPurchaseLine.Text = "Purchase Line";
            // 
            // dgvPurchaseLines
            // 
            this.dgvPurchaseLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseLines.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPurchaseLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseLines.Location = new System.Drawing.Point(8, 16);
            this.dgvPurchaseLines.Name = "dgvPurchaseLines";
            this.dgvPurchaseLines.ReadOnly = true;
            this.dgvPurchaseLines.RowHeadersWidth = 30;
            this.dgvPurchaseLines.Size = new System.Drawing.Size(464, 344);
            this.dgvPurchaseLines.TabIndex = 0;
            // 
            // mnuSupplierPurchase
            // 
            this.mnuSupplierPurchase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCancel,
            this.mnuDeletePurchase,
            this.mnuDeleteLine,
            this.mnuInsert,
            this.mnuSave});
            this.mnuSupplierPurchase.Location = new System.Drawing.Point(0, 0);
            this.mnuSupplierPurchase.Name = "mnuSupplierPurchase";
            this.mnuSupplierPurchase.Size = new System.Drawing.Size(836, 24);
            this.mnuSupplierPurchase.TabIndex = 13;
            this.mnuSupplierPurchase.Text = "mnuSupplierPurchase";
            this.mnuSupplierPurchase.Visible = false;
            // 
            // mnuCancel
            // 
            this.mnuCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuCancel.Image = ((System.Drawing.Image)(resources.GetObject("mnuCancel.Image")));
            this.mnuCancel.Name = "mnuCancel";
            this.mnuCancel.Size = new System.Drawing.Size(71, 20);
            this.mnuCancel.Text = "&Cancel";
            this.mnuCancel.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // mnuDeleteLine
            // 
            this.mnuDeleteLine.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuDeleteLine.Enabled = false;
            this.mnuDeleteLine.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteLine.Image")));
            this.mnuDeleteLine.Name = "mnuDeleteLine";
            this.mnuDeleteLine.Size = new System.Drawing.Size(93, 20);
            this.mnuDeleteLine.Text = "Delete &Line";
            this.mnuDeleteLine.Click += new System.EventHandler(this.mnuDeleteLine_Click);
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
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // mnuDeletePurchase
            // 
            this.mnuDeletePurchase.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuDeletePurchase.Enabled = false;
            this.mnuDeletePurchase.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeletePurchase.Image")));
            this.mnuDeletePurchase.Name = "mnuDeletePurchase";
            this.mnuDeletePurchase.Size = new System.Drawing.Size(119, 20);
            this.mnuDeletePurchase.Text = "&Delete Purchase";
            this.mnuDeletePurchase.Click += new System.EventHandler(this.mnuDeletePurchase_Click);
            // 
            // FrmSupplierPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 381);
            this.Controls.Add(this.mnuSupplierPurchase);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSupplierPurchaseLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSupplierPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add SupplierPurchase";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSupplierPurchaseLine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseLines)).EndInit();
            this.mnuSupplierPurchase.ResumeLayout(false);
            this.mnuSupplierPurchase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPurchaseCode;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLineTotal;
        private System.Windows.Forms.ComboBox cboRawIngredients;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.DateTimePicker dtpDatePurchased;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpSupplierPurchaseLine;
        private System.Windows.Forms.DataGridView dgvPurchaseLines;
        private System.Windows.Forms.MenuStrip mnuSupplierPurchase;
        private System.Windows.Forms.ToolStripMenuItem mnuCancel;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteLine;
        private System.Windows.Forms.ToolStripMenuItem mnuInsert;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.ToolStripMenuItem mnuDeletePurchase;
    }
}