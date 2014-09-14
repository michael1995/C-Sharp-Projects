namespace ChocoMambo
{
    partial class frmPermissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermissions));
            this.dgvPermission = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccessRights = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colForm = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRights = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermission)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPermission
            // 
            this.dgvPermission.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPermission.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.EmployeeID,
            this.FormID,
            this.AccessRights,
            this.colEmployee,
            this.colForm,
            this.colRights});
            resources.ApplyResources(this.dgvPermission, "dgvPermission");
            this.dgvPermission.Name = "dgvPermission";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "EmployeeFormID";
            resources.ApplyResources(this.ID, "ID");
            this.ID.Name = "ID";
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "EmployeeID";
            resources.ApplyResources(this.EmployeeID, "EmployeeID");
            this.EmployeeID.Name = "EmployeeID";
            // 
            // FormID
            // 
            this.FormID.DataPropertyName = "FormID";
            resources.ApplyResources(this.FormID, "FormID");
            this.FormID.Name = "FormID";
            // 
            // AccessRights
            // 
            this.AccessRights.DataPropertyName = "AccessType";
            resources.ApplyResources(this.AccessRights, "AccessRights");
            this.AccessRights.Name = "AccessRights";
            // 
            // colEmployee
            // 
            resources.ApplyResources(this.colEmployee, "colEmployee");
            this.colEmployee.Name = "colEmployee";
            // 
            // colForm
            // 
            resources.ApplyResources(this.colForm, "colForm");
            this.colForm.Name = "colForm";
            // 
            // colRights
            // 
            resources.ApplyResources(this.colRights, "colRights");
            this.colRights.Items.AddRange(new object[] {
            "Deny",
            "Read",
            "Write",
            "Admin"});
            this.colRights.Name = "colRights";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSave});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // mnuSave
            // 
            this.mnuSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.mnuSave, "mnuSave");
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // frmPermissions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPermission);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPermissions";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FrmPermissions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermission)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPermission;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccessRights;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEmployee;
        private System.Windows.Forms.DataGridViewComboBoxColumn colForm;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRights;
    }
}