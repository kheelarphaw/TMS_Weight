using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using TMS_Weight.Models;
using TMS_Weight.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace TMS_Weight.Forms
{
    partial class FrmQueue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private WeightApiService _apiService = new WeightApiService();

        public int QRegNo;
        public string gateId;
        public string cardNo;

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

        private async void LoadData(WeightBridgeQueue queue)
        {
            this.QRegNo = (int)queue.RegNo;
            this.gateId = queue.GateID;
            this.txtInRegNo.Text = queue.InRegNo.ToString();
            this.txtYard.Text = queue.YardID;
            this.txtDriver.Text = queue.DriverName;
            this.txtDLicense.Text = queue.DriverLicenseNo;
            this.txtContainer.Text = queue.ContainerNo;
            this.txtBlNo.Text = queue.BLNo;
            this.txtCargoInfo.Text = queue.CargoInfo;
            this.txtCustomer.Text = queue.Customer;
            this.txtTruck.Text = queue.TruckVehicleRegNo;
            this.txtTrailer.Text = queue.TrailerVehicleRegNo;
            this.txtWbId.Text = queue.WeightBridgeID;
            this.txtCategory.Text = queue.PCCode;
            this.txtbilloption.Text = queue.BillOption;
            this.txtWType.Text = queue.Type;
            this.txtwbOption.Text = queue.WBOption;
            this.cardNo = queue.CardNo;
         
        }
        private async Task<ResponseMessage> SaveServiceBillForQueue()
        {
            ResponseMessage msg = new ResponseMessage();

            WeightServiceBill serviceBill = new WeightServiceBill();

            serviceBill.ServiceBillNo = "";
            serviceBill.QRegNo = this.QRegNo;
            serviceBill.GateID = this.gateId;
            serviceBill.CheckInRegNo = Convert.ToInt32(this.txtInRegNo.Text);
            serviceBill.CustomerId = this.txtCustomer.Text;
            serviceBill.DONo = this.txtDoNo.Text;
            serviceBill.TrailerNo = this.txtTrailer.Text;
            serviceBill.TruckNo = this.txtTruck.Text;
            serviceBill.DriverName = this.txtDriver.Text;
            serviceBill.DriverLicense = this.txtDLicense.Text;
            serviceBill.InWeightCash = Convert.ToDecimal(this.txtInCash.Text);
            serviceBill.ContainerNo = this.txtContainer.Text;
            serviceBill.BLNo = this.txtBlNo.Text;
            serviceBill.Remark = this.txtRemark.Text;
            serviceBill.CargoInfo = this.txtCargoInfo.Text;
            serviceBill.WeightType = this.txtWType.Text;
            serviceBill.WeightBridgeID = this.txtWbId.Text;
            serviceBill.WeightOption = this.txtwbOption.Text;
            serviceBill.BillOption = this.txtbilloption.Text;
            serviceBill.CardNo = this.cardNo;


            serviceBill.YardID = this.txtYard.Text;


            // Extract the numeric value using regex
            string wvalue = System.Text.RegularExpressions.Regex.Match(this.txtWeight.Text, @"\d+").Value;

            // Convert the extracted number string to an integer
            int value = int.Parse(wvalue) / 1000;

            if (serviceBill.WeightType == "In")
            {
                DateTime date = (DateTime)this.sfDate.Value; // Date part
                string timeString = this.txtTime.Text.ToString();
                TimeSpan time = TimeSpan.Parse(timeString);// Time part 
                serviceBill.InWeightTime = (date + time);
                serviceBill.ServiceBillDate = serviceBill.InWeightTime;


                serviceBill.InWeight = Convert.ToDecimal(value);
            }
            else
            {
                DateTime date = (DateTime)this.sfDate.Value; // Date part
                string timeString = this.txtTime.Text.ToString();
                TimeSpan time = TimeSpan.Parse(timeString);// Time part 
                serviceBill.OutWeightTime = (date + time);
                serviceBill.ServiceBillDate = serviceBill.OutWeightTime;
                serviceBill.OutWeight = Convert.ToDecimal(value);
            }

            if(serviceBill.WeightType == "In")
            {
                this.Close();

                msg = await _apiService.SaveServiceBillForQueue(serviceBill);
            }
            else
            {
                this.Close();
                msg = await _apiService.UpdateServiceBillForQueue(serviceBill);
                FrmServiceBillPrint f = new FrmServiceBillPrint(msg.ServiceBillNo.ToString());
                f.Show();
            }

            return msg;

        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQueue));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetWeight = new Syncfusion.WinForms.Controls.SfButton();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblwbId = new System.Windows.Forms.Label();
            this.lblBlno = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblVesselInfo = new System.Windows.Forms.Label();
            this.lblContainer = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblTrailer = new System.Windows.Forms.Label();
            this.lblTruck = new System.Windows.Forms.Label();
            this.lblheader = new System.Windows.Forms.Label();
            this.sfDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDoNo = new System.Windows.Forms.Label();
            this.lblBillOption = new System.Windows.Forms.Label();
            this.lblWType = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtDoNo = new System.Windows.Forms.TextBox();
            this.txtBlNo = new System.Windows.Forms.TextBox();
            this.txtDLicense = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtCargoInfo = new System.Windows.Forms.TextBox();
            this.txtContainer = new System.Windows.Forms.TextBox();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblDriver = new System.Windows.Forms.Label();
            this.lblWOption = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblQRegNo = new System.Windows.Forms.Label();
            this.txtInRegNo = new System.Windows.Forms.TextBox();
            this.txtYard = new System.Windows.Forms.TextBox();
            this.txtTruck = new System.Windows.Forms.TextBox();
            this.txtTrailer = new System.Windows.Forms.TextBox();
            this.txtWbId = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtwbOption = new System.Windows.Forms.TextBox();
            this.txtWType = new System.Windows.Forms.TextBox();
            this.txtbilloption = new System.Windows.Forms.TextBox();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSave = new Syncfusion.WinForms.Controls.SfButton();
            this.txtInCash = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnGetWeight);
            this.panel1.Controls.Add(this.lblWeight);
            this.panel1.Controls.Add(this.txtWeight);
            this.panel1.Location = new System.Drawing.Point(16, 562);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 72);
            this.panel1.TabIndex = 91;
            // 
            // btnGetWeight
            // 
            this.btnGetWeight.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnGetWeight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetWeight.ForeColor = System.Drawing.Color.White;
            this.btnGetWeight.ImageSize = new System.Drawing.Size(24, 24);
            this.btnGetWeight.Location = new System.Drawing.Point(729, 19);
            this.btnGetWeight.Name = "btnGetWeight";
            this.btnGetWeight.Size = new System.Drawing.Size(98, 30);
            this.btnGetWeight.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnGetWeight.Style.ForeColor = System.Drawing.Color.White;
            this.btnGetWeight.Style.Image = global::TMS_Weight.Properties.Resources.window_edit;
            this.btnGetWeight.TabIndex = 22;
            this.btnGetWeight.Text = "&Get";
            this.btnGetWeight.UseVisualStyleBackColor = false;
            this.btnGetWeight.Click += new System.EventHandler(this.btnGetWeight_Click);
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(312, 24);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(127, 25);
            this.lblWeight.TabIndex = 32;
            this.lblWeight.Text = "Weighing In :";
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtWeight.Location = new System.Drawing.Point(447, 24);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtWeight.Multiline = true;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(253, 25);
            this.txtWeight.TabIndex = 21;
            // 
            // lblwbId
            // 
            this.lblwbId.AutoSize = true;
            this.lblwbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwbId.Location = new System.Drawing.Point(405, 237);
            this.lblwbId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblwbId.Name = "lblwbId";
            this.lblwbId.Size = new System.Drawing.Size(77, 25);
            this.lblwbId.TabIndex = 87;
            this.lblwbId.Text = "WB Id :";
            // 
            // lblBlno
            // 
            this.lblBlno.AutoSize = true;
            this.lblBlno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlno.Location = new System.Drawing.Point(809, 434);
            this.lblBlno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlno.Name = "lblBlno";
            this.lblBlno.Size = new System.Drawing.Size(83, 25);
            this.lblBlno.TabIndex = 84;
            this.lblBlno.Text = "B/L No :";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(405, 504);
            this.lblRemark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(90, 25);
            this.lblRemark.TabIndex = 83;
            this.lblRemark.Text = "Remark :";
            // 
            // lblVesselInfo
            // 
            this.lblVesselInfo.AutoSize = true;
            this.lblVesselInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVesselInfo.Location = new System.Drawing.Point(11, 503);
            this.lblVesselInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVesselInfo.Name = "lblVesselInfo";
            this.lblVesselInfo.Size = new System.Drawing.Size(109, 25);
            this.lblVesselInfo.TabIndex = 82;
            this.lblVesselInfo.Text = "Cargo Info:";
            // 
            // lblContainer
            // 
            this.lblContainer.AutoSize = true;
            this.lblContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContainer.Location = new System.Drawing.Point(405, 431);
            this.lblContainer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContainer.Name = "lblContainer";
            this.lblContainer.Size = new System.Drawing.Size(108, 25);
            this.lblContainer.TabIndex = 81;
            this.lblContainer.Text = "Container :";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicense.Location = new System.Drawing.Point(809, 369);
            this.lblLicense.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(105, 25);
            this.lblLicense.TabIndex = 78;
            this.lblLicense.Text = "DLicense :";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(805, 238);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(103, 25);
            this.lblCategory.TabIndex = 51;
            this.lblCategory.Text = "Category :";
            // 
            // lblTrailer
            // 
            this.lblTrailer.AutoSize = true;
            this.lblTrailer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrailer.Location = new System.Drawing.Point(805, 173);
            this.lblTrailer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrailer.Name = "lblTrailer";
            this.lblTrailer.Size = new System.Drawing.Size(108, 25);
            this.lblTrailer.TabIndex = 88;
            this.lblTrailer.Text = "Trailer No :";
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTruck.Location = new System.Drawing.Point(405, 173);
            this.lblTruck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(103, 25);
            this.lblTruck.TabIndex = 89;
            this.lblTruck.Text = "Truck No :";
            // 
            // lblheader
            // 
            this.lblheader.AutoSize = true;
            this.lblheader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheader.Location = new System.Drawing.Point(495, 16);
            this.lblheader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblheader.Name = "lblheader";
            this.lblheader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblheader.Size = new System.Drawing.Size(170, 32);
            this.lblheader.TabIndex = 1;
            this.lblheader.Text = "Weight Data";
            this.lblheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sfDate
            // 
            this.sfDate.DateTimeIcon = null;
            this.sfDate.Location = new System.Drawing.Point(528, 104);
            this.sfDate.Margin = new System.Windows.Forms.Padding(4);
            this.sfDate.Name = "sfDate";
            this.sfDate.Size = new System.Drawing.Size(238, 26);
            this.sfDate.TabIndex = 2;
            this.sfDate.ToolTipText = "";
            this.sfDate.Value = new System.DateTime(2024, 12, 17, 0, 0, 0, 0);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnHeader.Controls.Add(this.lblheader);
            this.pnHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnHeader.Location = new System.Drawing.Point(-1, -1);
            this.pnHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1192, 59);
            this.pnHeader.TabIndex = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 173);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 85;
            this.label1.Text = "Yard:";
            // 
            // lblDoNo
            // 
            this.lblDoNo.AutoSize = true;
            this.lblDoNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoNo.Location = new System.Drawing.Point(11, 432);
            this.lblDoNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoNo.Name = "lblDoNo";
            this.lblDoNo.Size = new System.Drawing.Size(78, 25);
            this.lblDoNo.TabIndex = 79;
            this.lblDoNo.Text = "DO No:";
            // 
            // lblBillOption
            // 
            this.lblBillOption.AutoSize = true;
            this.lblBillOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillOption.Location = new System.Drawing.Point(809, 307);
            this.lblBillOption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillOption.Name = "lblBillOption";
            this.lblBillOption.Size = new System.Drawing.Size(111, 25);
            this.lblBillOption.TabIndex = 80;
            this.lblBillOption.Text = "Bill Option :";
            // 
            // lblWType
            // 
            this.lblWType.AutoSize = true;
            this.lblWType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWType.Location = new System.Drawing.Point(405, 305);
            this.lblWType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWType.Name = "lblWType";
            this.lblWType.Size = new System.Drawing.Size(88, 25);
            this.lblWType.TabIndex = 76;
            this.lblWType.Text = "WType :";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(926, 104);
            this.txtTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(238, 24);
            this.txtTime.TabIndex = 3;
            // 
            // txtDoNo
            // 
            this.txtDoNo.Location = new System.Drawing.Point(126, 435);
            this.txtDoNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoNo.Name = "txtDoNo";
            this.txtDoNo.Size = new System.Drawing.Size(238, 24);
            this.txtDoNo.TabIndex = 16;
            // 
            // txtBlNo
            // 
            this.txtBlNo.Location = new System.Drawing.Point(926, 433);
            this.txtBlNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBlNo.Name = "txtBlNo";
            this.txtBlNo.Size = new System.Drawing.Size(238, 24);
            this.txtBlNo.TabIndex = 18;
            // 
            // txtDLicense
            // 
            this.txtDLicense.Location = new System.Drawing.Point(926, 364);
            this.txtDLicense.Margin = new System.Windows.Forms.Padding(4);
            this.txtDLicense.Name = "txtDLicense";
            this.txtDLicense.ReadOnly = true;
            this.txtDLicense.Size = new System.Drawing.Size(238, 24);
            this.txtDLicense.TabIndex = 15;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(531, 503);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(238, 24);
            this.txtRemark.TabIndex = 20;
            // 
            // txtCargoInfo
            // 
            this.txtCargoInfo.Location = new System.Drawing.Point(126, 504);
            this.txtCargoInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCargoInfo.Multiline = true;
            this.txtCargoInfo.Name = "txtCargoInfo";
            this.txtCargoInfo.Size = new System.Drawing.Size(238, 24);
            this.txtCargoInfo.TabIndex = 19;
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(531, 432);
            this.txtContainer.Margin = new System.Windows.Forms.Padding(4);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(238, 24);
            this.txtContainer.TabIndex = 17;
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(531, 369);
            this.txtDriver.Margin = new System.Windows.Forms.Padding(4);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.ReadOnly = true;
            this.txtDriver.Size = new System.Drawing.Size(238, 24);
            this.txtDriver.TabIndex = 14;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(126, 237);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(238, 24);
            this.txtCustomer.TabIndex = 7;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(809, 106);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(67, 25);
            this.lblTime.TabIndex = 62;
            this.lblTime.Text = "Time :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(404, 106);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 25);
            this.lblDate.TabIndex = 61;
            this.lblDate.Text = "Date :";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.Location = new System.Drawing.Point(11, 364);
            this.lblCash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(105, 25);
            this.lblCash.TabIndex = 64;
            this.lblCash.Text = "Cash Amt:";
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriver.Location = new System.Drawing.Point(404, 368);
            this.lblDriver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(126, 25);
            this.lblDriver.TabIndex = 65;
            this.lblDriver.Text = "Driver Name:";
            // 
            // lblWOption
            // 
            this.lblWOption.AutoSize = true;
            this.lblWOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWOption.Location = new System.Drawing.Point(11, 299);
            this.lblWOption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWOption.Name = "lblWOption";
            this.lblWOption.Size = new System.Drawing.Size(96, 25);
            this.lblWOption.TabIndex = 66;
            this.lblWOption.Text = "WOption:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(11, 236);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(108, 25);
            this.lblCustomer.TabIndex = 67;
            this.lblCustomer.Text = "Customer :";
            // 
            // lblQRegNo
            // 
            this.lblQRegNo.AutoSize = true;
            this.lblQRegNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQRegNo.Location = new System.Drawing.Point(11, 109);
            this.lblQRegNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQRegNo.Name = "lblQRegNo";
            this.lblQRegNo.Size = new System.Drawing.Size(104, 25);
            this.lblQRegNo.TabIndex = 89;
            this.lblQRegNo.Text = "InReg No :";
            // 
            // txtInRegNo
            // 
            this.txtInRegNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtInRegNo.Enabled = false;
            this.txtInRegNo.Location = new System.Drawing.Point(126, 106);
            this.txtInRegNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInRegNo.Name = "txtInRegNo";
            this.txtInRegNo.Size = new System.Drawing.Size(238, 24);
            this.txtInRegNo.TabIndex = 1;
            // 
            // txtYard
            // 
            this.txtYard.BackColor = System.Drawing.SystemColors.Control;
            this.txtYard.Enabled = false;
            this.txtYard.Location = new System.Drawing.Point(126, 169);
            this.txtYard.Margin = new System.Windows.Forms.Padding(4);
            this.txtYard.Name = "txtYard";
            this.txtYard.Size = new System.Drawing.Size(238, 24);
            this.txtYard.TabIndex = 4;
            // 
            // txtTruck
            // 
            this.txtTruck.BackColor = System.Drawing.SystemColors.Control;
            this.txtTruck.Enabled = false;
            this.txtTruck.Location = new System.Drawing.Point(530, 169);
            this.txtTruck.Margin = new System.Windows.Forms.Padding(4);
            this.txtTruck.Name = "txtTruck";
            this.txtTruck.Size = new System.Drawing.Size(238, 24);
            this.txtTruck.TabIndex = 5;
            // 
            // txtTrailer
            // 
            this.txtTrailer.BackColor = System.Drawing.SystemColors.Control;
            this.txtTrailer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.txtTrailer.Enabled = false;
            this.txtTrailer.Location = new System.Drawing.Point(926, 169);
            this.txtTrailer.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrailer.Name = "txtTrailer";
            this.txtTrailer.Size = new System.Drawing.Size(238, 24);
            this.txtTrailer.TabIndex = 6;
            // 
            // txtWbId
            // 
            this.txtWbId.BackColor = System.Drawing.SystemColors.Control;
            this.txtWbId.Enabled = false;
            this.txtWbId.Location = new System.Drawing.Point(531, 234);
            this.txtWbId.Margin = new System.Windows.Forms.Padding(4);
            this.txtWbId.Name = "txtWbId";
            this.txtWbId.Size = new System.Drawing.Size(238, 24);
            this.txtWbId.TabIndex = 8;
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.SystemColors.Control;
            this.txtCategory.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.txtCategory.Enabled = false;
            this.txtCategory.Location = new System.Drawing.Point(926, 234);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(238, 24);
            this.txtCategory.TabIndex = 9;
            // 
            // txtwbOption
            // 
            this.txtwbOption.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtwbOption.Enabled = false;
            this.txtwbOption.Location = new System.Drawing.Point(126, 301);
            this.txtwbOption.Margin = new System.Windows.Forms.Padding(4);
            this.txtwbOption.Name = "txtwbOption";
            this.txtwbOption.ReadOnly = true;
            this.txtwbOption.Size = new System.Drawing.Size(238, 24);
            this.txtwbOption.TabIndex = 10;
            // 
            // txtWType
            // 
            this.txtWType.BackColor = System.Drawing.SystemColors.Control;
            this.txtWType.Enabled = false;
            this.txtWType.Location = new System.Drawing.Point(531, 307);
            this.txtWType.Margin = new System.Windows.Forms.Padding(4);
            this.txtWType.Name = "txtWType";
            this.txtWType.Size = new System.Drawing.Size(238, 24);
            this.txtWType.TabIndex = 11;
            // 
            // txtbilloption
            // 
            this.txtbilloption.BackColor = System.Drawing.SystemColors.Control;
            this.txtbilloption.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.txtbilloption.Enabled = false;
            this.txtbilloption.Location = new System.Drawing.Point(926, 299);
            this.txtbilloption.Margin = new System.Windows.Forms.Padding(4);
            this.txtbilloption.Name = "txtbilloption";
            this.txtbilloption.Size = new System.Drawing.Size(238, 24);
            this.txtbilloption.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageSize = new System.Drawing.Size(24, 24);
            this.btnCancel.Location = new System.Drawing.Point(607, 661);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 40);
            this.btnCancel.Style.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSave.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSave.Location = new System.Drawing.Point(462, 661);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 40);
            this.btnSave.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSave.Style.ForeColor = System.Drawing.Color.White;
            this.btnSave.Style.Image = global::TMS_Weight.Properties.Resources.disk_blue1;
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.sfBtnSave_Click);
            // 
            // txtInCash
            // 
            this.txtInCash.Location = new System.Drawing.Point(124, 370);
            this.txtInCash.Margin = new System.Windows.Forms.Padding(4);
            this.txtInCash.Name = "txtInCash";
            this.txtInCash.Size = new System.Drawing.Size(238, 24);
            this.txtInCash.TabIndex = 13;
            // 
            // FrmQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 724);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblwbId);
            this.Controls.Add(this.lblBlno);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblVesselInfo);
            this.Controls.Add(this.lblContainer);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblTrailer);
            this.Controls.Add(this.lblQRegNo);
            this.Controls.Add(this.lblTruck);
            this.Controls.Add(this.sfDate);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDoNo);
            this.Controls.Add(this.lblBillOption);
            this.Controls.Add(this.lblWType);
            this.Controls.Add(this.txtbilloption);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtTrailer);
            this.Controls.Add(this.txtWType);
            this.Controls.Add(this.txtWbId);
            this.Controls.Add(this.txtTruck);
            this.Controls.Add(this.txtYard);
            this.Controls.Add(this.txtInRegNo);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtInCash);
            this.Controls.Add(this.txtDoNo);
            this.Controls.Add(this.txtBlNo);
            this.Controls.Add(this.txtDLicense);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtCargoInfo);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.txtwbOption);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.lblDriver);
            this.Controls.Add(this.lblWOption);
            this.Controls.Add(this.lblCustomer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmQueue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm Queue";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblwbId;
        private System.Windows.Forms.Label lblBlno;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblVesselInfo;
        private System.Windows.Forms.Label lblContainer;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblTrailer;
        private System.Windows.Forms.Label lblTruck;
        private System.Windows.Forms.Label lblheader;
        public Syncfusion.WinForms.Input.SfDateTimeEdit sfDate;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDoNo;
        private System.Windows.Forms.Label lblBillOption;
        private System.Windows.Forms.Label lblWType;
        public System.Windows.Forms.TextBox txtTime;
        public System.Windows.Forms.TextBox txtDoNo;
        public System.Windows.Forms.TextBox txtBlNo;
        public System.Windows.Forms.TextBox txtDLicense;
        public System.Windows.Forms.TextBox txtRemark;
        public System.Windows.Forms.TextBox txtCargoInfo;
        public System.Windows.Forms.TextBox txtContainer;
        public System.Windows.Forms.TextBox txtDriver;
        public System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.Label lblWOption;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblQRegNo;
        public System.Windows.Forms.TextBox txtInRegNo;
        public System.Windows.Forms.TextBox txtYard;
        public System.Windows.Forms.TextBox txtTruck;
        public System.Windows.Forms.TextBox txtTrailer;
        public System.Windows.Forms.TextBox txtWbId;
        public System.Windows.Forms.TextBox txtCategory;
        public System.Windows.Forms.TextBox txtwbOption;
        public System.Windows.Forms.TextBox txtWType;
        public System.Windows.Forms.TextBox txtbilloption;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private Syncfusion.WinForms.Controls.SfButton btnGetWeight;
        public System.Windows.Forms.TextBox txtWeight;
        public System.Windows.Forms.TextBox txtInCash;
    }
}