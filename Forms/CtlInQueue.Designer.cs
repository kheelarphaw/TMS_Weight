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

        private async void LoadData()
        {
           
            // Retrieve the YardCode setting from Properties
            string yardCode = Properties.Settings.Default.YardCode;
            string wbCode = Properties.Settings.Default.WBCode;

            _apiService = new WeightApiService();
            List<WeightBridgeQueue> inQueueList = new List<WeightBridgeQueue>();
            this.sfInQueueGrid.DataSource = null;
            inQueueList = await _apiService.GetWeighingInQueueList(yardCode, wbCode);
            if (inQueueList.Count > 0)
            {
                this.sfInQueueGrid.DataSource = inQueueList;
            }
            else
            {
                this.sfInQueueGrid.DataSource = null;
                btnEnabled();
            }

        }





        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlInQueue));
            this.pnlInQueue = new System.Windows.Forms.Panel();
            this.sfInQueueGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.sfBtnInWeight = new Syncfusion.WinForms.Controls.SfButton();
            this.sfbtnExport = new Syncfusion.WinForms.Controls.SfButton();
            this.pnlInQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfInQueueGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInQueue
            // 
            this.pnlInQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInQueue.BackColor = System.Drawing.SystemColors.Control;
            this.pnlInQueue.Controls.Add(this.sfInQueueGrid);
            this.pnlInQueue.Location = new System.Drawing.Point(2, 119);
            this.pnlInQueue.Name = "pnlInQueue";
            this.pnlInQueue.Size = new System.Drawing.Size(1318, 637);
            this.pnlInQueue.TabIndex = 19;
            // 
            // sfInQueueGrid
            // 
            this.sfInQueueGrid.AccessibleName = "Table";
            this.sfInQueueGrid.AllowResizingColumns = true;
            this.sfInQueueGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfInQueueGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfInQueueGrid.Location = new System.Drawing.Point(10, 3);
            this.sfInQueueGrid.Name = "sfInQueueGrid";
            this.sfInQueueGrid.PreviewRowHeight = 35;
            this.sfInQueueGrid.Size = new System.Drawing.Size(1295, 605);
            this.sfInQueueGrid.TabIndex = 2;
            this.sfInQueueGrid.Text = "sfDataGrid1";
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
            // sfBtnInWeight
            // 
            this.sfBtnInWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sfBtnInWeight.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnInWeight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnInWeight.ForeColor = System.Drawing.Color.White;
            this.sfBtnInWeight.Location = new System.Drawing.Point(1064, 57);
            this.sfBtnInWeight.Name = "sfBtnInWeight";
            this.sfBtnInWeight.Size = new System.Drawing.Size(107, 34);
            this.sfBtnInWeight.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnInWeight.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnInWeight.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.sfBtnInWeight.TabIndex = 21;
            this.sfBtnInWeight.Text = "W&eight";
            this.sfBtnInWeight.UseVisualStyleBackColor = false;
            this.sfBtnInWeight.Click += new System.EventHandler(this.sfBtnWeight_Click);
            // 
            // sfbtnExport
            // 
            this.sfbtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sfbtnExport.BackColor = System.Drawing.Color.ForestGreen;
            this.sfbtnExport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfbtnExport.ForeColor = System.Drawing.Color.White;
            this.sfbtnExport.Location = new System.Drawing.Point(1195, 57);
            this.sfbtnExport.Margin = new System.Windows.Forms.Padding(4);
            this.sfbtnExport.Name = "sfbtnExport";
            this.sfbtnExport.Size = new System.Drawing.Size(107, 34);
            this.sfbtnExport.Style.BackColor = System.Drawing.Color.ForestGreen;
            this.sfbtnExport.Style.ForeColor = System.Drawing.Color.White;
            this.sfbtnExport.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
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
            this.Controls.Add(this.pnlInQueue);
            this.Controls.Add(this.label1);
            this.Name = "CtlInQueue";
            this.Size = new System.Drawing.Size(1318, 773);
            this.pnlInQueue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfInQueueGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel pnlInQueue;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfInQueueGrid;
        private System.Windows.Forms.Label label1;
        private Syncfusion.WinForms.Controls.SfButton sfBtnInWeight;
        private Syncfusion.WinForms.Controls.SfButton sfbtnExport;
    }
}
