namespace TMS_Weight.Forms
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelTool = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adHocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnInQueue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnOutQueue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnAdHoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnBill = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnPsw = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnLogout = new System.Windows.Forms.ToolStripButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.pictureHome = new System.Windows.Forms.PictureBox();
            this.panelTool.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHome)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTool
            // 
            this.panelTool.Controls.Add(this.menuStrip1);
            this.panelTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTool.Location = new System.Drawing.Point(0, 0);
            this.panelTool.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.panelTool.Name = "panelTool";
            this.panelTool.Size = new System.Drawing.Size(1318, 34);
            this.panelTool.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1318, 39);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem,
            this.inToolStripMenuItem,
            this.outToolStripMenuItem,
            this.adHocToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(63, 35);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(282, 36);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // inToolStripMenuItem
            // 
            this.inToolStripMenuItem.Name = "inToolStripMenuItem";
            this.inToolStripMenuItem.Size = new System.Drawing.Size(282, 36);
            this.inToolStripMenuItem.Text = "In";
            // 
            // outToolStripMenuItem
            // 
            this.outToolStripMenuItem.Name = "outToolStripMenuItem";
            this.outToolStripMenuItem.Size = new System.Drawing.Size(282, 36);
            this.outToolStripMenuItem.Text = "Out";
            // 
            // adHocToolStripMenuItem
            // 
            this.adHocToolStripMenuItem.Name = "adHocToolStripMenuItem";
            this.adHocToolStripMenuItem.Size = new System.Drawing.Size(282, 36);
            this.adHocToolStripMenuItem.Text = "AdHoc";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(282, 36);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(282, 36);
            this.logOutToolStripMenuItem.Text = "LogOut";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnQuit,
            this.toolStripSeparator2,
            this.toolStripBtnInQueue,
            this.toolStripSeparator3,
            this.toolStripBtnOutQueue,
            this.toolStripSeparator4,
            this.toolStripBtnAdHoc,
            this.toolStripSeparator5,
            this.toolStripBtnBill,
            this.toolStripSeparator6,
            this.toolStripBtnPsw,
            this.toolStripSeparator8,
            this.toolStripBtnLogout});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 34);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1318, 55);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "&Quit";
            // 
            // toolStripBtnQuit
            // 
            this.toolStripBtnQuit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBtnQuit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnQuit.Image")));
            this.toolStripBtnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnQuit.Name = "toolStripBtnQuit";
            this.toolStripBtnQuit.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripBtnQuit.Size = new System.Drawing.Size(74, 52);
            this.toolStripBtnQuit.Text = "&Quit";
            this.toolStripBtnQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnQuit.Click += new System.EventHandler(this.toolStripBtnQuit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnInQueue
            // 
            this.toolStripBtnInQueue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBtnInQueue.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnInQueue.Image")));
            this.toolStripBtnInQueue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnInQueue.Name = "toolStripBtnInQueue";
            this.toolStripBtnInQueue.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripBtnInQueue.Size = new System.Drawing.Size(52, 52);
            this.toolStripBtnInQueue.Text = "I&n";
            this.toolStripBtnInQueue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnInQueue.Click += new System.EventHandler(this.toolStripBtnInQueue_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnOutQueue
            // 
            this.toolStripBtnOutQueue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBtnOutQueue.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnOutQueue.Image")));
            this.toolStripBtnOutQueue.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripBtnOutQueue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnOutQueue.Name = "toolStripBtnOutQueue";
            this.toolStripBtnOutQueue.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripBtnOutQueue.Size = new System.Drawing.Size(69, 52);
            this.toolStripBtnOutQueue.Text = "Ou&t";
            this.toolStripBtnOutQueue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnOutQueue.Click += new System.EventHandler(this.toolStripBtnOutQueue_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnAdHoc
            // 
            this.toolStripBtnAdHoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBtnAdHoc.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAdHoc.Image")));
            this.toolStripBtnAdHoc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripBtnAdHoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAdHoc.Name = "toolStripBtnAdHoc";
            this.toolStripBtnAdHoc.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripBtnAdHoc.Size = new System.Drawing.Size(86, 52);
            this.toolStripBtnAdHoc.Text = "AdHoc";
            this.toolStripBtnAdHoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnAdHoc.Click += new System.EventHandler(this.toolStripBtnAdHoc_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnBill
            // 
            this.toolStripBtnBill.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBtnBill.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnBill.Image")));
            this.toolStripBtnBill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnBill.Name = "toolStripBtnBill";
            this.toolStripBtnBill.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripBtnBill.Size = new System.Drawing.Size(62, 52);
            this.toolStripBtnBill.Text = "Bill";
            this.toolStripBtnBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnBill.Click += new System.EventHandler(this.toolStripBtnBill_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnPsw
            // 
            this.toolStripBtnPsw.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBtnPsw.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnPsw.Image")));
            this.toolStripBtnPsw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPsw.Name = "toolStripBtnPsw";
            this.toolStripBtnPsw.Size = new System.Drawing.Size(168, 52);
            this.toolStripBtnPsw.Text = "Change Password";
            this.toolStripBtnPsw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnPsw.Click += new System.EventHandler(this.toolStripBtnPsw_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripBtnLogout
            // 
            this.toolStripBtnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBtnLogout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnLogout.Image")));
            this.toolStripBtnLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnLogout.Name = "toolStripBtnLogout";
            this.toolStripBtnLogout.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripBtnLogout.Size = new System.Drawing.Size(92, 52);
            this.toolStripBtnLogout.Text = "LogOut";
            this.toolStripBtnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnLogout.Click += new System.EventHandler(this.toolStripBtnLogout_Click);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Controls.Add(this.pictureHome);
            this.panelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMain.Location = new System.Drawing.Point(0, 81);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1318, 942);
            this.panelMain.TabIndex = 2;
            // 
            // pictureHome
            // 
            this.pictureHome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureHome.Image = global::TMS_Weight.Properties.Resources.weight_logo;
            this.pictureHome.Location = new System.Drawing.Point(26, 19);
            this.pictureHome.Name = "pictureHome";
            this.pictureHome.Size = new System.Drawing.Size(1259, 796);
            this.pictureHome.TabIndex = 1;
            this.pictureHome.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 1055);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelTool);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FrmMain";
            this.Text = "RGL Weight Bridge";
            this.panelTool.ResumeLayout(false);
            this.panelTool.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTool;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripBtnInQueue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripBtnOutQueue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripBtnAdHoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripBtnBill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripBtnPsw;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripBtnLogout;
        private System.Windows.Forms.Panel panelMain;
        public System.Windows.Forms.PictureBox pictureHome;
    }
}