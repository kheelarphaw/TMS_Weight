using System;
using System.Collections.Generic;
using TMS_Weight.Models;
using TMS_Weight.Services;

namespace TMS_Weight.Forms
{
    partial class CtlInQueue
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private WeightApiService _apiService;

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

        private void LoadData()
        {
           
            // Retrieve the YardCode setting from Properties
            string yardCode = Properties.Settings.Default.YardCode;
            string wbCode = Properties.Settings.Default.WBCode;

            // Split the string by commas
            string[] yardCodeArray = yardCode.Split(',');
            string[] wbCodeArray = wbCode.Split(',');

            this.sfCbxYard.DataSource = yardCodeArray;
            this.sfCbxWBId.DataSource = wbCodeArray;
            
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlInQueue));
            this.panel1 = new System.Windows.Forms.Panel();
            this.sfInQueueGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.lblWBId = new System.Windows.Forms.Label();
            this.lblYard = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sfCbxYard = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxWBId = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfBtnInView = new Syncfusion.WinForms.Controls.SfButton();
            this.sfBtnInWeight = new Syncfusion.WinForms.Controls.SfButton();
            this.sfbtnExport = new Syncfusion.WinForms.Controls.SfButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfInQueueGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxYard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWBId)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.sfInQueueGrid);
            this.panel1.Location = new System.Drawing.Point(2, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1318, 633);
            this.panel1.TabIndex = 19;
            // 
            // sfInQueueGrid
            // 
            this.sfInQueueGrid.AccessibleName = "Table";
            this.sfInQueueGrid.AllowResizingColumns = true;
            this.sfInQueueGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfInQueueGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfInQueueGrid.Location = new System.Drawing.Point(10, 12);
            this.sfInQueueGrid.Name = "sfInQueueGrid";
            this.sfInQueueGrid.PreviewRowHeight = 35;
            this.sfInQueueGrid.Size = new System.Drawing.Size(1295, 596);
            this.sfInQueueGrid.TabIndex = 2;
            this.sfInQueueGrid.Text = "sfDataGrid1";
            // 
            // lblWBId
            // 
            this.lblWBId.AutoSize = true;
            this.lblWBId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWBId.Location = new System.Drawing.Point(354, 71);
            this.lblWBId.Name = "lblWBId";
            this.lblWBId.Size = new System.Drawing.Size(146, 25);
            this.lblWBId.TabIndex = 16;
            this.lblWBId.Text = "Weight Bridge :";
            // 
            // lblYard
            // 
            this.lblYard.AutoSize = true;
            this.lblYard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYard.Location = new System.Drawing.Point(29, 69);
            this.lblYard.Name = "lblYard";
            this.lblYard.Size = new System.Drawing.Size(64, 25);
            this.lblYard.TabIndex = 15;
            this.lblYard.Text = "Yard :";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1318, 53);
            this.label1.TabIndex = 12;
            this.label1.Text = "In Queue List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sfCbxYard
            // 
            this.sfCbxYard.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxYard.Location = new System.Drawing.Point(110, 64);
            this.sfCbxYard.Name = "sfCbxYard";
            this.sfCbxYard.Size = new System.Drawing.Size(209, 31);
            this.sfCbxYard.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfCbxYard.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxYard.TabIndex = 20;
            this.sfCbxYard.TabStop = false;
            this.sfCbxYard.ValueMember = "YardCode";
            // 
            // sfCbxWBId
            // 
            this.sfCbxWBId.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxWBId.Location = new System.Drawing.Point(515, 65);
            this.sfCbxWBId.Name = "sfCbxWBId";
            this.sfCbxWBId.Size = new System.Drawing.Size(209, 31);
            this.sfCbxWBId.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfCbxWBId.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxWBId.TabIndex = 20;
            this.sfCbxWBId.TabStop = false;
            // 
            // sfBtnInView
            // 
            this.sfBtnInView.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnInView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnInView.ForeColor = System.Drawing.Color.White;
            this.sfBtnInView.Location = new System.Drawing.Point(782, 62);
            this.sfBtnInView.Name = "sfBtnInView";
            this.sfBtnInView.Size = new System.Drawing.Size(107, 34);
            this.sfBtnInView.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnInView.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnInView.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.sfBtnInView.TabIndex = 17;
            this.sfBtnInView.Text = "&View";
            this.sfBtnInView.UseVisualStyleBackColor = false;
            this.sfBtnInView.Click += new System.EventHandler(this.sfBtnInView_Click);
            // 
            // sfBtnInWeight
            // 
            this.sfBtnInWeight.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnInWeight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnInWeight.ForeColor = System.Drawing.Color.White;
            this.sfBtnInWeight.Location = new System.Drawing.Point(913, 62);
            this.sfBtnInWeight.Name = "sfBtnInWeight";
            this.sfBtnInWeight.Size = new System.Drawing.Size(107, 34);
            this.sfBtnInWeight.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnInWeight.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnInWeight.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.sfBtnInWeight.TabIndex = 21;
            this.sfBtnInWeight.Text = "W&eight";
            this.sfBtnInWeight.UseVisualStyleBackColor = false;
            this.sfBtnInWeight.Click += new System.EventHandler(this.sfBtnWeight_Click);
            // 
            // sfbtnExport
            // 
            this.sfbtnExport.BackColor = System.Drawing.Color.ForestGreen;
            this.sfbtnExport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfbtnExport.ForeColor = System.Drawing.Color.White;
            this.sfbtnExport.Location = new System.Drawing.Point(1042, 62);
            this.sfbtnExport.Margin = new System.Windows.Forms.Padding(4);
            this.sfbtnExport.Name = "sfbtnExport";
            this.sfbtnExport.Size = new System.Drawing.Size(107, 34);
            this.sfbtnExport.Style.BackColor = System.Drawing.Color.ForestGreen;
            this.sfbtnExport.Style.ForeColor = System.Drawing.Color.White;
            this.sfbtnExport.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.sfbtnExport.TabIndex = 22;
            this.sfbtnExport.Text = "Export";
            this.sfbtnExport.UseVisualStyleBackColor = false;
            // 
            // CtlInQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.sfbtnExport);
            this.Controls.Add(this.sfBtnInWeight);
            this.Controls.Add(this.sfCbxWBId);
            this.Controls.Add(this.sfCbxYard);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sfBtnInView);
            this.Controls.Add(this.lblWBId);
            this.Controls.Add(this.lblYard);
            this.Controls.Add(this.label1);
            this.Name = "CtlInQueue";
            this.Size = new System.Drawing.Size(1318, 773);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfInQueueGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxYard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWBId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private async void LoadData(string yard, string wbId)
        {
            _apiService = new WeightApiService();
            List<WeightBridgeQueue> inQueueList = new List<WeightBridgeQueue>();
            this.sfInQueueGrid.DataSource = null;
            inQueueList = await _apiService.GetWeighingInQueueList(yard, wbId);
            if (inQueueList.Count > 0)
            {
                this.sfInQueueGrid.DataSource = inQueueList;
            }
            this.sfBtnInView.Enabled = true;
        }

        private System.Windows.Forms.Panel panel1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfInQueueGrid;
        private Syncfusion.WinForms.Controls.SfButton sfBtnInView;
        private System.Windows.Forms.Label lblWBId;
        private System.Windows.Forms.Label lblYard;
        private System.Windows.Forms.Label label1;
        private Syncfusion.WinForms.ListView.SfComboBox sfCbxYard;
        private Syncfusion.WinForms.ListView.SfComboBox sfCbxWBId;
        private Syncfusion.WinForms.Controls.SfButton sfBtnInWeight;
        private Syncfusion.WinForms.Controls.SfButton sfbtnExport;
    }
}
