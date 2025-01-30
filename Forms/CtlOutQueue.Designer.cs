using System.Collections.Generic;
using TMS_Weight.Models;
using TMS_Weight.Services;

namespace TMS_Weight.Forms
{
    partial class CtlOutQueue
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

        //private void LoadData()
        //{

        //    // Retrieve the YardCode setting from Properties
        //    string yardCode = Properties.Settings.Default.YardCode;
        //    string wbCode = Properties.Settings.Default.WBCode;

        //    // Split the string by commas
        //    string[] yardCodeArray = yardCode.Split(',');
        //    string[] wbCodeArray = wbCode.Split(',');

        //    //this.sfCbxYard.DataSource = yardCodeArray;
        //    //this.sfCbxWBId.DataSource = wbCodeArray;

        //}


        private async void LoadData()
        {
            // Retrieve the YardCode setting from Properties
            string yardCode = Properties.Settings.Default.YardCode;
            string wbCode = Properties.Settings.Default.WBCode;

            _apiService = new WeightApiService();
            List<WeightBridgeQueue> outQueueList = new List<WeightBridgeQueue>();
            this.sfOutQueueGrid.DataSource = null;
            outQueueList = await _apiService.GetWeighingOutQueueList(yardCode, wbCode);
            if (outQueueList.Count > 0)
            {
                this.sfOutQueueGrid.DataSource = outQueueList;
            }
            else
            {
                this.sfOutQueueGrid.DataSource = null;
                btnEnabled();
            }

            //_apiService = new WeightApiService();
            //List<WeightBridgeQueue> inQueueList = new List<WeightBridgeQueue>();
            //this.sfOutQueueGrid.DataSource = null;
            //inQueueList = await _apiService.GetWeighingOutQueueList(yard, wbId);
            //if (inQueueList.Count > 0)
            //{
            //    this.sfOutQueueGrid.DataSource = inQueueList;
            //}
           // this.sfBtnOutView.Enabled = true;
        }


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlOutQueue));
            this.pnlOutQueue = new System.Windows.Forms.Panel();
            this.sfOutQueueGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.lblOutQueue = new System.Windows.Forms.Label();
            this.sfBtnOutWeight = new Syncfusion.WinForms.Controls.SfButton();
            this.sfbtnExport = new Syncfusion.WinForms.Controls.SfButton();
            this.pnlOutQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfOutQueueGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOutQueue
            // 
            this.pnlOutQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOutQueue.BackColor = System.Drawing.SystemColors.Control;
            this.pnlOutQueue.Controls.Add(this.sfOutQueueGrid);
            this.pnlOutQueue.Location = new System.Drawing.Point(6, 99);
            this.pnlOutQueue.Name = "pnlOutQueue";
            this.pnlOutQueue.Size = new System.Drawing.Size(1312, 613);
            this.pnlOutQueue.TabIndex = 26;
            // 
            // sfOutQueueGrid
            // 
            this.sfOutQueueGrid.AccessibleName = "Table";
            this.sfOutQueueGrid.AllowResizingColumns = true;
            this.sfOutQueueGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfOutQueueGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfOutQueueGrid.Location = new System.Drawing.Point(12, 9);
            this.sfOutQueueGrid.Name = "sfOutQueueGrid";
            this.sfOutQueueGrid.PreviewRowHeight = 35;
            this.sfOutQueueGrid.Size = new System.Drawing.Size(1289, 530);
            this.sfOutQueueGrid.TabIndex = 2;
            this.sfOutQueueGrid.Text = "sfDataGrid1";
            // 
            // lblOutQueue
            // 
            this.lblOutQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutQueue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOutQueue.Location = new System.Drawing.Point(0, 0);
            this.lblOutQueue.Name = "lblOutQueue";
            this.lblOutQueue.Size = new System.Drawing.Size(1318, 53);
            this.lblOutQueue.TabIndex = 21;
            this.lblOutQueue.Text = "Out Queue List";
            this.lblOutQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sfBtnOutWeight
            // 
            this.sfBtnOutWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sfBtnOutWeight.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnOutWeight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnOutWeight.ForeColor = System.Drawing.Color.White;
            this.sfBtnOutWeight.Location = new System.Drawing.Point(1074, 55);
            this.sfBtnOutWeight.Margin = new System.Windows.Forms.Padding(4);
            this.sfBtnOutWeight.Name = "sfBtnOutWeight";
            this.sfBtnOutWeight.Size = new System.Drawing.Size(107, 34);
            this.sfBtnOutWeight.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnOutWeight.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnOutWeight.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.sfBtnOutWeight.TabIndex = 29;
            this.sfBtnOutWeight.Text = "W&eight";
            this.sfBtnOutWeight.UseVisualStyleBackColor = false;
            this.sfBtnOutWeight.Click += new System.EventHandler(this.sfBtnWeight_Click);
            // 
            // sfbtnExport
            // 
            this.sfbtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sfbtnExport.BackColor = System.Drawing.Color.ForestGreen;
            this.sfbtnExport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfbtnExport.ForeColor = System.Drawing.Color.White;
            this.sfbtnExport.Location = new System.Drawing.Point(1198, 55);
            this.sfbtnExport.Margin = new System.Windows.Forms.Padding(0);
            this.sfbtnExport.Name = "sfbtnExport";
            this.sfbtnExport.Size = new System.Drawing.Size(107, 34);
            this.sfbtnExport.Style.BackColor = System.Drawing.Color.ForestGreen;
            this.sfbtnExport.Style.ForeColor = System.Drawing.Color.White;
            this.sfbtnExport.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.sfbtnExport.TabIndex = 30;
            this.sfbtnExport.Text = "Export";
            this.sfbtnExport.UseVisualStyleBackColor = false;
            this.sfbtnExport.Click += new System.EventHandler(this.sfbtnExport_Click);
            // 
            // CtlOutQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sfbtnExport);
            this.Controls.Add(this.sfBtnOutWeight);
            this.Controls.Add(this.pnlOutQueue);
            this.Controls.Add(this.lblOutQueue);
            this.Name = "CtlOutQueue";
            this.Size = new System.Drawing.Size(1318, 773);
            this.pnlOutQueue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfOutQueueGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOutQueue;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfOutQueueGrid;
        private System.Windows.Forms.Label lblOutQueue;
        private Syncfusion.WinForms.Controls.SfButton sfBtnOutWeight;
        private Syncfusion.WinForms.Controls.SfButton sfbtnExport;
    }
}
