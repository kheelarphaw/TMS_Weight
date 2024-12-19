using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Weight.Models;
using TMS_Weight.Services;

namespace TMS_Weight.Forms
{
    partial class CtlServiceBill
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private WeightApiService _apiService = new WeightApiService();
        public List<Gate> gateList;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnService = new System.Windows.Forms.Panel();
            this.sfServiceGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.sfFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.lblfrom = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfServiceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Location = new System.Drawing.Point(1, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(995, 43);
            this.pnlHeader.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(995, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Weight Service Bill";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnService
            // 
            this.pnService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnService.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnService.Controls.Add(this.sfServiceGrid);
            this.pnService.Location = new System.Drawing.Point(4, 109);
            this.pnService.Name = "pnService";
            this.pnService.Size = new System.Drawing.Size(990, 443);
            this.pnService.TabIndex = 7;
            // 
            // sfServiceGrid
            // 
            this.sfServiceGrid.AccessibleName = "Table";
            this.sfServiceGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfServiceGrid.Location = new System.Drawing.Point(3, 3);
            this.sfServiceGrid.Name = "sfServiceGrid";
            this.sfServiceGrid.PreviewRowHeight = 35;
            this.sfServiceGrid.Size = new System.Drawing.Size(984, 122);
            this.sfServiceGrid.TabIndex = 0;
            this.sfServiceGrid.Text = "sfServiceGrid";
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.Location = new System.Drawing.Point(455, 58);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 28);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnView
            // 
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.Location = new System.Drawing.Point(361, 58);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(72, 28);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // sfFromDate
            // 
            this.sfFromDate.DateTimeIcon = null;
            this.sfFromDate.Location = new System.Drawing.Point(82, 60);
            this.sfFromDate.Name = "sfFromDate";
            this.sfFromDate.Size = new System.Drawing.Size(220, 24);
            this.sfFromDate.TabIndex = 8;
            this.sfFromDate.ToolTipText = "";
            // 
            // lblfrom
            // 
            this.lblfrom.AutoSize = true;
            this.lblfrom.Location = new System.Drawing.Point(17, 60);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(44, 16);
            this.lblfrom.TabIndex = 9;
            this.lblfrom.Text = "From :";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.Location = new System.Drawing.Point(550, 58);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CtlServiceBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblfrom);
            this.Controls.Add(this.sfFromDate);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnService);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnView);
            this.Name = "CtlServiceBill";
            this.Size = new System.Drawing.Size(996, 552);
            this.pnlHeader.ResumeLayout(false);
            this.pnService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfServiceGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        //private async void LoadData()
        //{

        //    this.sfCbxGate.DataSource = null;
        //    gateList = await _apiService.GetAllGateList();
        //    if (gateList.Count > 0)
        //        this.sfCbxGate.DataSource = gateList;


        //}


        private async Task<ResponseMessage> GetServiceBill()
        {
            ResponseMessage msg = new ResponseMessage();

            BtnDisable();
            if (sfFromDate.Value != null)
            {
                DateTime fromDate = (DateTime)sfFromDate.Value;
                sfServiceGrid.DataSource = await _apiService.GetServiceBillList(fromDate.ToString("yyyy-MM-dd"));
                if (sfServiceGrid.RowCount > 1)
                {
                    msg.Status = true;
                    //LoadData();
                    //ClearData();

                }
                else
                {
                    msg.Status = false;
                }



            }
            else
            {
                // Handle null values appropriately
                MessageBoxAdv.Show(this, "Date values is null!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }



            

            return msg;



        }




        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnService;
        public Syncfusion.WinForms.DataGrid.SfDataGrid sfServiceGrid;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnView;
        public Syncfusion.WinForms.Input.SfDateTimeEdit sfFromDate;
        private System.Windows.Forms.Label lblfrom;
        private Button btnClose;
    }
}
