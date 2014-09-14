namespace DragDropApplication
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lvMusicFiles = new System.Windows.Forms.ListView();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPause = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvMusicFiles
            // 
            this.lvMusicFiles.AllowDrop = true;
            this.lvMusicFiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvMusicFiles.Location = new System.Drawing.Point(392, 24);
            this.lvMusicFiles.MultiSelect = false;
            this.lvMusicFiles.Name = "lvMusicFiles";
            this.lvMusicFiles.Size = new System.Drawing.Size(328, 442);
            this.lvMusicFiles.TabIndex = 1;
            this.lvMusicFiles.UseCompatibleStateImageBehavior = false;
            this.lvMusicFiles.View = System.Windows.Forms.View.List;
            this.lvMusicFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvMusicFiles_DragDrop);
            this.lvMusicFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvMusicFiles_DragEnter);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 24);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(392, 442);
            this.axWindowsMediaPlayer1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPlay,
            this.mnuStop,
            this.mnuPause});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(720, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuPlay
            // 
            this.mnuPlay.Image = ((System.Drawing.Image)(resources.GetObject("mnuPlay.Image")));
            this.mnuPlay.Name = "mnuPlay";
            this.mnuPlay.Size = new System.Drawing.Size(57, 20);
            this.mnuPlay.Text = "&Play";
            this.mnuPlay.Click += new System.EventHandler(this.mnuPlay_Click);
            // 
            // mnuStop
            // 
            this.mnuStop.Image = ((System.Drawing.Image)(resources.GetObject("mnuStop.Image")));
            this.mnuStop.Name = "mnuStop";
            this.mnuStop.Size = new System.Drawing.Size(59, 20);
            this.mnuStop.Text = "&Stop";
            this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
            // 
            // mnuPause
            // 
            this.mnuPause.Image = ((System.Drawing.Image)(resources.GetObject("mnuPause.Image")));
            this.mnuPause.Name = "mnuPause";
            this.mnuPause.Size = new System.Drawing.Size(66, 20);
            this.mnuPause.Text = "P&ause";
            this.mnuPause.Click += new System.EventHandler(this.mnuPause_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 466);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.lvMusicFiles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mp3 Player";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMusicFiles;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuPlay;
        private System.Windows.Forms.ToolStripMenuItem mnuStop;
        private System.Windows.Forms.ToolStripMenuItem mnuPause;

    }
}

