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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlServiceBill));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnService = new System.Windows.Forms.Panel();
            this.sfServiceGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.sfFromDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.lblfrom = new System.Windows.Forms.Label();
            this.sfBtnView = new Syncfusion.WinForms.Controls.SfButton();
            this.sfBtnPrint = new Syncfusion.WinForms.Controls.SfButton();
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
            this.sfServiceGrid.Location = new System.Drawing.Point(-1, 0);
            this.sfServiceGrid.Name = "sfServiceGrid";
            this.sfServiceGrid.PreviewRowHeight = 35;
            this.sfServiceGrid.Size = new System.Drawing.Size(984, 122);
            this.sfServiceGrid.TabIndex = 0;
            this.sfServiceGrid.Text = "sfServiceGrid";
            // 
            // sfFromDate
            // 
            this.sfFromDate.DateTimeIcon = null;
            this.sfFromDate.Location = new System.Drawing.Point(82, 64);
            this.sfFromDate.Name = "sfFromDate";
            this.sfFromDate.Size = new System.Drawing.Size(220, 26);
            this.sfFromDate.TabIndex = 8;
            this.sfFromDate.ToolTipText = "";
            // 
            // lblfrom
            // 
            this.lblfrom.AutoSize = true;
            this.lblfrom.Location = new System.Drawing.Point(17, 68);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(44, 16);
            this.lblfrom.TabIndex = 9;
            this.lblfrom.Text = "From :";
            // 
            // sfBtnView
            // 
            this.sfBtnView.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnView.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnView.ForeColor = System.Drawing.Color.White;
            this.sfBtnView.Location = new System.Drawing.Point(370, 56);
            this.sfBtnView.Name = "sfBtnView";
            this.sfBtnView.Size = new System.Drawing.Size(107, 34);
            this.sfBtnView.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnView.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnView.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.sfBtnView.TabIndex = 26;
            this.sfBtnView.Text = "&View";
            this.sfBtnView.UseVisualStyleBackColor = false;
            this.sfBtnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // sfBtnPrint
            // 
            this.sfBtnPrint.BackColor = System.Drawing.Color.SeaGreen;
            this.sfBtnPrint.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnPrint.ForeColor = System.Drawing.Color.White;
            this.sfBtnPrint.Location = new System.Drawing.Point(500, 56);
            this.sfBtnPrint.Name = "sfBtnPrint";
            this.sfBtnPrint.Size = new System.Drawing.Size(107, 34);
            this.sfBtnPrint.Style.BackColor = System.Drawing.Color.SeaGreen;
            this.sfBtnPrint.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnPrint.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.sfBtnPrint.TabIndex = 26;
            this.sfBtnPrint.Text = "P&rint";
            this.sfBtnPrint.UseVisualStyleBackColor = false;
            this.sfBtnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // CtlServiceBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sfBtnPrint);
            this.Controls.Add(this.sfBtnView);
            this.Controls.Add(this.lblfrom);
            this.Controls.Add(this.sfFromDate);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnService);
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
        public Syncfusion.WinForms.Input.SfDateTimeEdit sfFromDate;
        private System.Windows.Forms.Label lblfrom;
        private Syncfusion.WinForms.Controls.SfButton sfBtnView;
        private Syncfusion.WinForms.Controls.SfButton sfBtnPrint;
    }
}
