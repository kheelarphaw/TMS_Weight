using static System.Windows.Forms.AxHost;
using Syncfusion.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using TMS_Weight.Models;
using System.Collections.Generic;
using TMS_Weight.Services;

namespace TMS_Weight.Forms
{
    partial class CtlWeightServiceBill
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

        private async Task<ResponseMessage> GetServiceBill()
        {
            ResponseMessage msg = new ResponseMessage();

            BtnDisable();
            if (sfDate.Value != null)
            {
                DateTime fromDate = (DateTime)sfDate.Value;
                sfSBGrid.DataSource = await _apiService.GetServiceBillList(fromDate.ToString("yyyy-MM-dd"));
                if (sfSBGrid.RowCount > 1)
                {
                    msg.Status = true;
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


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWeightServiceBill));
            this.panel1 = new System.Windows.Forms.Panel();
            this.sfSBGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.lblSB = new System.Windows.Forms.Label();
            this.sfBtnPrint = new Syncfusion.WinForms.Controls.SfButton();
            this.sfBtnSBView = new Syncfusion.WinForms.Controls.SfButton();
            this.lblsbill = new System.Windows.Forms.Label();
            this.sfDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfSBGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.sfSBGrid);
            this.panel1.Location = new System.Drawing.Point(1, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1318, 578);
            this.panel1.TabIndex = 26;
            // 
            // sfSBGrid
            // 
            this.sfSBGrid.AccessibleName = "Table";
            this.sfSBGrid.AllowResizingColumns = true;
            this.sfSBGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfSBGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfSBGrid.Location = new System.Drawing.Point(10, 12);
            this.sfSBGrid.Name = "sfSBGrid";
            this.sfSBGrid.PreviewRowHeight = 35;
            this.sfSBGrid.Size = new System.Drawing.Size(1295, 548);
            this.sfSBGrid.TabIndex = 2;
            this.sfSBGrid.Text = "sfDataGrid1";
            // 
            // lblSB
            // 
            this.lblSB.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSB.Location = new System.Drawing.Point(0, 0);
            this.lblSB.Name = "lblSB";
            this.lblSB.Size = new System.Drawing.Size(1318, 53);
            this.lblSB.TabIndex = 21;
            this.lblSB.Text = "Service Bill List";
            this.lblSB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sfBtnPrint
            // 
            this.sfBtnPrint.BackColor = System.Drawing.Color.SeaGreen;
            this.sfBtnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnPrint.ForeColor = System.Drawing.Color.White;
            this.sfBtnPrint.Location = new System.Drawing.Point(550, 73);
            this.sfBtnPrint.Name = "sfBtnPrint";
            this.sfBtnPrint.Size = new System.Drawing.Size(107, 34);
            this.sfBtnPrint.Style.BackColor = System.Drawing.Color.SeaGreen;
            this.sfBtnPrint.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnPrint.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.sfBtnPrint.TabIndex = 24;
            this.sfBtnPrint.Text = "P&rint";
            this.sfBtnPrint.UseVisualStyleBackColor = false;
            this.sfBtnPrint.Click += new System.EventHandler(this.sfBtnPrint_Click);
            // 
            // sfBtnSBView
            // 
            this.sfBtnSBView.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnSBView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnSBView.ForeColor = System.Drawing.Color.White;
            this.sfBtnSBView.Location = new System.Drawing.Point(411, 73);
            this.sfBtnSBView.Name = "sfBtnSBView";
            this.sfBtnSBView.Size = new System.Drawing.Size(107, 34);
            this.sfBtnSBView.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnSBView.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnSBView.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.sfBtnSBView.TabIndex = 25;
            this.sfBtnSBView.Text = "&View";
            this.sfBtnSBView.UseVisualStyleBackColor = false;
            this.sfBtnSBView.Click += new System.EventHandler(this.sfBtnSBView_Click);
            // 
            // lblsbill
            // 
            this.lblsbill.AutoSize = true;
            this.lblsbill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsbill.Location = new System.Drawing.Point(47, 76);
            this.lblsbill.Name = "lblsbill";
            this.lblsbill.Size = new System.Drawing.Size(64, 25);
            this.lblsbill.TabIndex = 22;
            this.lblsbill.Text = "Date :";
            // 
            // sfDate
            // 
            this.sfDate.DateTimeIcon = null;
            this.sfDate.Location = new System.Drawing.Point(130, 76);
            this.sfDate.Name = "sfDate";
            this.sfDate.Size = new System.Drawing.Size(232, 24);
            this.sfDate.TabIndex = 27;
            this.sfDate.ToolTipText = "";
            // 
            // CtlWeightServiceBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sfDate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSB);
            this.Controls.Add(this.sfBtnPrint);
            this.Controls.Add(this.sfBtnSBView);
            this.Controls.Add(this.lblsbill);
            this.Name = "CtlWeightServiceBill";
            this.Size = new System.Drawing.Size(1318, 736);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfSBGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfSBGrid;
        private System.Windows.Forms.Label lblSB;
        private Syncfusion.WinForms.Controls.SfButton sfBtnPrint;
        private Syncfusion.WinForms.Controls.SfButton sfBtnSBView;
        private System.Windows.Forms.Label lblsbill;
        private Syncfusion.WinForms.Input.SfDateTimeEdit sfDate;
    }
}
