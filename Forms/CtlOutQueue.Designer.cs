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


        private async void LoadData(string yard, string wbId)
        {
            _apiService = new WeightApiService();
            List<WeightBridgeQueue> inQueueList = new List<WeightBridgeQueue>();
            this.sfOutQueueGrid.DataSource = null;
            inQueueList = await _apiService.GetWeighingOutQueueList(yard, wbId);
            if (inQueueList.Count > 0)
            {
                this.sfOutQueueGrid.DataSource = inQueueList;
            }
            this.sfBtnOutView.Enabled = true;
        }


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlOutQueue));
            this.panel1 = new System.Windows.Forms.Panel();
            this.sfOutQueueGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.sfCbxWBId = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxYard = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfBtnOutView = new Syncfusion.WinForms.Controls.SfButton();
            this.lblWBId = new System.Windows.Forms.Label();
            this.lblYard = new System.Windows.Forms.Label();
            this.lblOutQueue = new System.Windows.Forms.Label();
            this.sfBtnOutWeight = new Syncfusion.WinForms.Controls.SfButton();
            this.sfbtnExport = new Syncfusion.WinForms.Controls.SfButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfOutQueueGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWBId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxYard)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.sfOutQueueGrid);
            this.panel1.Location = new System.Drawing.Point(1, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1318, 600);
            this.panel1.TabIndex = 26;
            // 
            // sfOutQueueGrid
            // 
            this.sfOutQueueGrid.AccessibleName = "Table";
            this.sfOutQueueGrid.AllowResizingColumns = true;
            this.sfOutQueueGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfOutQueueGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfOutQueueGrid.Location = new System.Drawing.Point(5, 3);
            this.sfOutQueueGrid.Name = "sfOutQueueGrid";
            this.sfOutQueueGrid.PreviewRowHeight = 35;
            this.sfOutQueueGrid.Size = new System.Drawing.Size(1295, 581);
            this.sfOutQueueGrid.TabIndex = 2;
            this.sfOutQueueGrid.Text = "sfDataGrid1";
            // 
            // sfCbxWBId
            // 
            this.sfCbxWBId.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxWBId.Location = new System.Drawing.Point(514, 63);
            this.sfCbxWBId.Name = "sfCbxWBId";
            this.sfCbxWBId.Size = new System.Drawing.Size(209, 31);
            this.sfCbxWBId.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfCbxWBId.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxWBId.TabIndex = 27;
            this.sfCbxWBId.TabStop = false;
            // 
            // sfCbxYard
            // 
            this.sfCbxYard.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxYard.Location = new System.Drawing.Point(109, 66);
            this.sfCbxYard.Name = "sfCbxYard";
            this.sfCbxYard.Size = new System.Drawing.Size(209, 31);
            this.sfCbxYard.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfCbxYard.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxYard.TabIndex = 28;
            this.sfCbxYard.TabStop = false;
            this.sfCbxYard.ValueMember = "YardCode";
            // 
            // sfBtnOutView
            // 
            this.sfBtnOutView.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnOutView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnOutView.ForeColor = System.Drawing.Color.White;
            this.sfBtnOutView.Location = new System.Drawing.Point(781, 59);
            this.sfBtnOutView.Name = "sfBtnOutView";
            this.sfBtnOutView.Size = new System.Drawing.Size(107, 34);
            this.sfBtnOutView.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnOutView.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnOutView.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.sfBtnOutView.TabIndex = 25;
            this.sfBtnOutView.Text = "&View";
            this.sfBtnOutView.UseVisualStyleBackColor = false;
            this.sfBtnOutView.Click += new System.EventHandler(this.sfBtnOutView_Click);
            // 
            // lblWBId
            // 
            this.lblWBId.AutoSize = true;
            this.lblWBId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWBId.Location = new System.Drawing.Point(353, 69);
            this.lblWBId.Name = "lblWBId";
            this.lblWBId.Size = new System.Drawing.Size(146, 25);
            this.lblWBId.TabIndex = 23;
            this.lblWBId.Text = "Weight Bridge :";
            // 
            // lblYard
            // 
            this.lblYard.AutoSize = true;
            this.lblYard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYard.Location = new System.Drawing.Point(28, 72);
            this.lblYard.Name = "lblYard";
            this.lblYard.Size = new System.Drawing.Size(64, 25);
            this.lblYard.TabIndex = 22;
            this.lblYard.Text = "Yard :";
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
            this.sfBtnOutWeight.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnOutWeight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnOutWeight.ForeColor = System.Drawing.Color.White;
            this.sfBtnOutWeight.Location = new System.Drawing.Point(909, 59);
            this.sfBtnOutWeight.Margin = new System.Windows.Forms.Padding(4);
            this.sfBtnOutWeight.Name = "sfBtnOutWeight";
            this.sfBtnOutWeight.Size = new System.Drawing.Size(107, 34);
            this.sfBtnOutWeight.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnOutWeight.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnOutWeight.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.sfBtnOutWeight.TabIndex = 29;
            this.sfBtnOutWeight.Text = "W&eight";
            this.sfBtnOutWeight.UseVisualStyleBackColor = false;
            this.sfBtnOutWeight.Click += new System.EventHandler(this.sfBtnWeight_Click);
            // 
            // sfbtnExport
            // 
            this.sfbtnExport.BackColor = System.Drawing.Color.ForestGreen;
            this.sfbtnExport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfbtnExport.ForeColor = System.Drawing.Color.White;
            this.sfbtnExport.Location = new System.Drawing.Point(1037, 60);
            this.sfbtnExport.Margin = new System.Windows.Forms.Padding(4);
            this.sfbtnExport.Name = "sfbtnExport";
            this.sfbtnExport.Size = new System.Drawing.Size(107, 34);
            this.sfbtnExport.Style.BackColor = System.Drawing.Color.ForestGreen;
            this.sfbtnExport.Style.ForeColor = System.Drawing.Color.White;
            this.sfbtnExport.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.sfbtnExport.TabIndex = 30;
            this.sfbtnExport.Text = "Export";
            this.sfbtnExport.UseVisualStyleBackColor = false;
            // 
            // CtlOutQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sfbtnExport);
            this.Controls.Add(this.sfBtnOutWeight);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sfCbxWBId);
            this.Controls.Add(this.sfCbxYard);
            this.Controls.Add(this.sfBtnOutView);
            this.Controls.Add(this.lblWBId);
            this.Controls.Add(this.lblYard);
            this.Controls.Add(this.lblOutQueue);
            this.Name = "CtlOutQueue";
            this.Size = new System.Drawing.Size(1318, 773);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfOutQueueGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWBId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxYard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfOutQueueGrid;
        private Syncfusion.WinForms.ListView.SfComboBox sfCbxWBId;
        private Syncfusion.WinForms.ListView.SfComboBox sfCbxYard;
        private Syncfusion.WinForms.Controls.SfButton sfBtnOutView;
        private System.Windows.Forms.Label lblWBId;
        private System.Windows.Forms.Label lblYard;
        private System.Windows.Forms.Label lblOutQueue;
        private Syncfusion.WinForms.Controls.SfButton sfBtnOutWeight;
        private Syncfusion.WinForms.Controls.SfButton sfbtnExport;
    }
}
