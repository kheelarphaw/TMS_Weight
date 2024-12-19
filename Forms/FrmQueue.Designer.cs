using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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

        public List<Transporter> transporterList;
        public List<Vehicle> truckList;
        public List<Vehicle> trailerList;
        public List<WeightBridge> weightBridgeList;
        public List<Gate> gateList;
        public int QRegNo;

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
            this.txtInRegNo.Text = queue.InRegNo.ToString();
            this.sfCbxWType.DataSource = new List<string> { "In", "Out" };
            this.sfCbxWType.SelectedItem = queue.Type;
            this.sfCbxWOption.DataSource = new List<string> { "Both" };
            this.sfCbxWOption.SelectedItem = queue.WBOption;
            this.sfCbxBillOption.DataSource = new List<string> { "None", "Credit", "Cash" };
            this.sfCbxBillOption.SelectedItem = queue.BillOption;
            this.sfCbxCategory.DataSource = new List<string> { "ICD", "Other", "Rail", "WH", "CCA" };

            this.txtDriver.Text = queue.DriverName;
            this.txtDLicense.Text = queue.DriverLicenseNo;
            this.txtContainer.Text = queue.ContainerNo;
            this.txtBlNo.Text = queue.BLNo;
            this.txtCargoInfo.Text = queue.CargoInfo;
            this.txtCustomer.Text = queue.Customer;
            //this.sfCbxTransporter.DataSource = null;
            //transporterList = await _apiService.GetTransporterList();
            //if (transporterList.Count > 0)
            //    this.sfCbxTransporter.DataSource = transporterList;

            this.sfCbxWBId.DataSource = null;
            weightBridgeList = await _apiService.GetWeightBridgeList();
            if (weightBridgeList.Count > 0)
            {
                this.sfCbxWBId.DataSource = weightBridgeList;
                this.sfCbxWBId.SelectedItem = queue.WeightBridgeID;
            }
                

            this.sfCbxTruck.DataSource = null;
            truckList = await _apiService.GetTruckList();
            if (truckList.Count > 0)
            {
                this.sfCbxTruck.DataSource = truckList;
                this.sfCbxTruck.SelectedItem = queue.TruckVehicleRegNo;
            }
                

            this.sfCbxTrailer.DataSource = null;
            trailerList = await _apiService.GetTrailerList();
            if (trailerList.Count > 0)
            {
                this.sfCbxTrailer.DataSource = trailerList;
                this.sfCbxTrailer.SelectedItem = queue.TrailerVehicleRegNo;

            }

            this.sfCbxGate.DataSource = null;
            gateList = await _apiService.GetGateList();
            if (gateList.Count > 0)
            {
                this.sfCbxGate.DataSource = gateList;
                this.sfCbxGate.SelectedItem = queue.GateID;
            }


        }
        private async Task<ResponseMessage> SaveServiceBillForQueue()
        {
            ResponseMessage msg = new ResponseMessage();

            //if (string.IsNullOrWhiteSpace(txtQueueNo.Text) || ddlOperator.SelectedItem == null || ddlTechnician.SelectedItem == null
            //    || string.IsNullOrWhiteSpace(ddlCSize.SelectedItem.ToString()) || string.IsNullOrWhiteSpace(ddlCType.SelectedItem.ToString())
            //    || string.IsNullOrWhiteSpace(ddlGrade.SelectedItem.ToString()) || ddlCStatus.SelectedItem == null
            //    || string.IsNullOrWhiteSpace(manufactureDate.Text) || string.IsNullOrWhiteSpace(gross.Text) || string.IsNullOrWhiteSpace(tare.Text)
            //    || string.IsNullOrWhiteSpace(payload.Text) || ddlUOM.SelectedItem == null || string.IsNullOrWhiteSpace(vehicleNo.Text))
            //{
            //    await MessageBox.Show("Warning", "Data are required!", "OK");
            //    return msg;
            //}

            WeightServiceBill serviceBill = new WeightServiceBill();

            serviceBill.ServiceBillNo = "";
            serviceBill.QRegNo = this.QRegNo;
            serviceBill.CheckInRegNo = Convert.ToInt32(this.txtInRegNo.Text);
            serviceBill.CustomerId = this.txtCustomer.Text;
            serviceBill.WeightCategory = this.sfCbxCategory.SelectedItem.ToString();
            serviceBill.WeightOption = this.sfCbxWOption.SelectedItem.ToString();
            serviceBill.WeightType = this.sfCbxWType.SelectedItem.ToString();
            serviceBill.BillOption = this.sfCbxBillOption.SelectedItem.ToString();
            serviceBill.DONo = this.txtDoNo.Text;
            serviceBill.DriverName = this.txtDriver.Text;
            serviceBill.DriverLicense = this.txtDLicense.Text;
            serviceBill.CashAmt = Convert.ToDecimal(this.sfNtxtCash.Text);
            serviceBill.ContainerNo = this.txtContainer.Text;
            serviceBill.BLNo = this.txtBlNo.Text;
            serviceBill.Remark = this.txtRemark.Text;
            serviceBill.CargoInfo = this.txtCargoInfo.Text;
            

            //if (this.sfCbxTransporter.SelectedItem is Transporter t)
            //    serviceBill.TransporterID = t.TransporterID;

            //if (this.sfCbxTruck.SelectedItem is Vehicle truck)
            serviceBill.TruckNo = this.sfCbxTruck.SelectedItem.ToString();

            //if (this.sfCbxTrailer.SelectedItem is Vehicle trailer)
            serviceBill.TrailerNo = this.sfCbxTrailer.SelectedItem.ToString();

            //if (this.sfCbxWBId.SelectedItem is WeightBridge wb)
            serviceBill.WeightBridgeID = this.sfCbxWBId.SelectedItem.ToString();

            //if (this.sfCbxGate.SelectedItem is Gate gate)
            //{
            //    serviceBill.GateID = gate.GateID; i => i.GateID == this.sfCbxGate.SelectedItem
            //    serviceBill.YardID = gate.YardID;
            //}

            serviceBill.GateID = this.sfCbxGate.SelectedItem.ToString();
            serviceBill.YardID = "YTG";


            if (serviceBill.WeightType == "In")
            {
                DateTime date = (DateTime)this.sfDate.Value; // Date part
                string timeString = this.txtTime.Text.ToString();
                TimeSpan time = TimeSpan.Parse(timeString);// Time part 
                serviceBill.InWeightTime = (date + time);
               //serviceBill.OutWeightTime = null;
                serviceBill.ServiceBillDate = serviceBill.InWeightTime;
                serviceBill.InWeight = Convert.ToDecimal(this.sfNtxtWeight.Text);
            }
            else
            {
                DateTime date = (DateTime)this.sfDate.Value; // Date part
                string timeString = this.txtTime.Text.ToString();
                TimeSpan time = TimeSpan.Parse(timeString);// Time part 
                serviceBill.OutWeightTime = (date + time);
                //serviceBill.InWeightTime = null;
                serviceBill.ServiceBillDate = serviceBill.OutWeightTime;
                serviceBill.OutWeight = Convert.ToDecimal(this.sfNtxtWeight.Text);
            }

            if(serviceBill.WeightType == "In")
            {
                msg = await _apiService.SaveServiceBillForQueue(serviceBill);
            }
            else
            {
                msg = await _apiService.UpdateServiceBillForQueue(serviceBill);
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
            this.sfNtxtCash = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.sfCbxGate = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxWBId = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxTrailer = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxTruck = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxBillOption = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfNtxtWeight = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWeight = new System.Windows.Forms.Label();
            this.sfCbxWType = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxWOption = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxCategory = new Syncfusion.WinForms.ListView.SfComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
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
            this.btnSave = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxGate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWBId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTrailer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTruck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxBillOption)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxCategory)).BeginInit();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // sfNtxtCash
            // 
            this.sfNtxtCash.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sfNtxtCash.Location = new System.Drawing.Point(122, 325);
            this.sfNtxtCash.Name = "sfNtxtCash";
            this.sfNtxtCash.Size = new System.Drawing.Size(212, 22);
            this.sfNtxtCash.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sfNtxtCash.TabIndex = 13;
            // 
            // sfCbxGate
            // 
            this.sfCbxGate.DisplayMember = "GateInfo";
            this.sfCbxGate.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxGate.Location = new System.Drawing.Point(122, 150);
            this.sfCbxGate.Name = "sfCbxGate";
            this.sfCbxGate.Size = new System.Drawing.Size(212, 22);
            this.sfCbxGate.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxGate.TabIndex = 4;
            this.sfCbxGate.TabStop = false;
            this.sfCbxGate.ValueMember = "GateID";
            // 
            // sfCbxWBId
            // 
            this.sfCbxWBId.DisplayMember = "Name";
            this.sfCbxWBId.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxWBId.Location = new System.Drawing.Point(456, 208);
            this.sfCbxWBId.Name = "sfCbxWBId";
            this.sfCbxWBId.Size = new System.Drawing.Size(212, 22);
            this.sfCbxWBId.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxWBId.TabIndex = 17;
            this.sfCbxWBId.TabStop = false;
            this.sfCbxWBId.ValueMember = "WeghtBridgeID";
            // 
            // sfCbxTrailer
            // 
            this.sfCbxTrailer.DisplayMember = "VehicleRegNo";
            this.sfCbxTrailer.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxTrailer.Location = new System.Drawing.Point(804, 150);
            this.sfCbxTrailer.Name = "sfCbxTrailer";
            this.sfCbxTrailer.Size = new System.Drawing.Size(212, 22);
            this.sfCbxTrailer.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxTrailer.TabIndex = 6;
            this.sfCbxTrailer.TabStop = false;
            this.sfCbxTrailer.ValueMember = "VehicleRegNo";
            // 
            // sfCbxTruck
            // 
            this.sfCbxTruck.DisplayMember = "VehicleRegNo";
            this.sfCbxTruck.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxTruck.Location = new System.Drawing.Point(458, 150);
            this.sfCbxTruck.Name = "sfCbxTruck";
            this.sfCbxTruck.Size = new System.Drawing.Size(212, 22);
            this.sfCbxTruck.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxTruck.TabIndex = 5;
            this.sfCbxTruck.TabStop = false;
            this.sfCbxTruck.ValueMember = "VehicleRegNo";
            // 
            // sfCbxBillOption
            // 
            this.sfCbxBillOption.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxBillOption.Location = new System.Drawing.Point(804, 267);
            this.sfCbxBillOption.Name = "sfCbxBillOption";
            this.sfCbxBillOption.Size = new System.Drawing.Size(212, 22);
            this.sfCbxBillOption.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxBillOption.TabIndex = 12;
            this.sfCbxBillOption.TabStop = false;
            // 
            // sfNtxtWeight
            // 
            this.sfNtxtWeight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sfNtxtWeight.Location = new System.Drawing.Point(332, 17);
            this.sfNtxtWeight.Name = "sfNtxtWeight";
            this.sfNtxtWeight.Size = new System.Drawing.Size(301, 22);
            this.sfNtxtWeight.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sfNtxtWeight.TabIndex = 27;
            // 
            // btnGet
            // 
            this.btnGet.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGet.Location = new System.Drawing.Point(671, 13);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 29);
            this.btnGet.TabIndex = 28;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.sfNtxtWeight);
            this.panel1.Controls.Add(this.lblWeight);
            this.panel1.Controls.Add(this.btnGet);
            this.panel1.Location = new System.Drawing.Point(38, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 66);
            this.panel1.TabIndex = 91;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(210, 24);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(83, 16);
            this.lblWeight.TabIndex = 32;
            this.lblWeight.Text = "Weighing In :";
            // 
            // sfCbxWType
            // 
            this.sfCbxWType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxWType.Location = new System.Drawing.Point(458, 267);
            this.sfCbxWType.Name = "sfCbxWType";
            this.sfCbxWType.Size = new System.Drawing.Size(212, 22);
            this.sfCbxWType.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxWType.TabIndex = 11;
            this.sfCbxWType.TabStop = false;
            // 
            // sfCbxWOption
            // 
            this.sfCbxWOption.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxWOption.Location = new System.Drawing.Point(123, 267);
            this.sfCbxWOption.Name = "sfCbxWOption";
            this.sfCbxWOption.Size = new System.Drawing.Size(212, 22);
            this.sfCbxWOption.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxWOption.TabIndex = 10;
            this.sfCbxWOption.TabStop = false;
            // 
            // sfCbxCategory
            // 
            this.sfCbxCategory.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxCategory.Location = new System.Drawing.Point(804, 208);
            this.sfCbxCategory.Name = "sfCbxCategory";
            this.sfCbxCategory.Size = new System.Drawing.Size(212, 22);
            this.sfCbxCategory.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxCategory.TabIndex = 9;
            this.sfCbxCategory.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(538, 593);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 39);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblwbId
            // 
            this.lblwbId.AutoSize = true;
            this.lblwbId.Location = new System.Drawing.Point(371, 214);
            this.lblwbId.Name = "lblwbId";
            this.lblwbId.Size = new System.Drawing.Size(49, 16);
            this.lblwbId.TabIndex = 87;
            this.lblwbId.Text = "WB Id :";
            this.lblwbId.Click += new System.EventHandler(this.lblwbId_Click);
            // 
            // lblBlno
            // 
            this.lblBlno.AutoSize = true;
            this.lblBlno.Location = new System.Drawing.Point(719, 393);
            this.lblBlno.Name = "lblBlno";
            this.lblBlno.Size = new System.Drawing.Size(54, 16);
            this.lblBlno.TabIndex = 84;
            this.lblBlno.Text = "B/L No :";
            this.lblBlno.Click += new System.EventHandler(this.lblBlno_Click);
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(371, 455);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(61, 16);
            this.lblRemark.TabIndex = 83;
            this.lblRemark.Text = "Remark :";
            // 
            // lblVesselInfo
            // 
            this.lblVesselInfo.AutoSize = true;
            this.lblVesselInfo.Location = new System.Drawing.Point(33, 446);
            this.lblVesselInfo.Name = "lblVesselInfo";
            this.lblVesselInfo.Size = new System.Drawing.Size(71, 16);
            this.lblVesselInfo.TabIndex = 82;
            this.lblVesselInfo.Text = "Cargo Info:";
            // 
            // lblContainer
            // 
            this.lblContainer.AutoSize = true;
            this.lblContainer.Location = new System.Drawing.Point(371, 390);
            this.lblContainer.Name = "lblContainer";
            this.lblContainer.Size = new System.Drawing.Size(70, 16);
            this.lblContainer.TabIndex = 81;
            this.lblContainer.Text = "Container :";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(719, 331);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(70, 16);
            this.lblLicense.TabIndex = 78;
            this.lblLicense.Text = "DLicense :";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(715, 214);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(68, 16);
            this.lblCategory.TabIndex = 51;
            this.lblCategory.Text = "Category :";
            // 
            // lblTrailer
            // 
            this.lblTrailer.AutoSize = true;
            this.lblTrailer.Location = new System.Drawing.Point(715, 156);
            this.lblTrailer.Name = "lblTrailer";
            this.lblTrailer.Size = new System.Drawing.Size(73, 16);
            this.lblTrailer.TabIndex = 88;
            this.lblTrailer.Text = "Trailer No :";
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.Location = new System.Drawing.Point(371, 156);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(68, 16);
            this.lblTruck.TabIndex = 89;
            this.lblTruck.Text = "Truck No :";
            // 
            // lblheader
            // 
            this.lblheader.AutoSize = true;
            this.lblheader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheader.Location = new System.Drawing.Point(440, 13);
            this.lblheader.Name = "lblheader";
            this.lblheader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblheader.Size = new System.Drawing.Size(120, 25);
            this.lblheader.TabIndex = 1;
            this.lblheader.Text = "Weight Data";
            this.lblheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(433, 593);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // sfDate
            // 
            this.sfDate.DateTimeIcon = null;
            this.sfDate.Location = new System.Drawing.Point(457, 92);
            this.sfDate.Name = "sfDate";
            this.sfDate.Size = new System.Drawing.Size(211, 24);
            this.sfDate.TabIndex = 2;
            this.sfDate.ToolTipText = "";
            this.sfDate.Value = new System.DateTime(2024, 12, 17, 0, 0, 0, 0);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnHeader.Controls.Add(this.lblheader);
            this.pnHeader.Location = new System.Drawing.Point(-1, 1);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1059, 55);
            this.pnHeader.TabIndex = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 85;
            this.label1.Text = "Yard:";
            // 
            // lblDoNo
            // 
            this.lblDoNo.AutoSize = true;
            this.lblDoNo.Location = new System.Drawing.Point(33, 393);
            this.lblDoNo.Name = "lblDoNo";
            this.lblDoNo.Size = new System.Drawing.Size(51, 16);
            this.lblDoNo.TabIndex = 79;
            this.lblDoNo.Text = "DO No:";
            // 
            // lblBillOption
            // 
            this.lblBillOption.AutoSize = true;
            this.lblBillOption.Location = new System.Drawing.Point(719, 273);
            this.lblBillOption.Name = "lblBillOption";
            this.lblBillOption.Size = new System.Drawing.Size(73, 16);
            this.lblBillOption.TabIndex = 80;
            this.lblBillOption.Text = "Bill Option :";
            // 
            // lblWType
            // 
            this.lblWType.AutoSize = true;
            this.lblWType.Location = new System.Drawing.Point(371, 273);
            this.lblWType.Name = "lblWType";
            this.lblWType.Size = new System.Drawing.Size(58, 16);
            this.lblWType.TabIndex = 76;
            this.lblWType.Text = "WType :";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(801, 94);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(212, 22);
            this.txtTime.TabIndex = 3;
            // 
            // txtDoNo
            // 
            this.txtDoNo.Location = new System.Drawing.Point(122, 386);
            this.txtDoNo.Name = "txtDoNo";
            this.txtDoNo.Size = new System.Drawing.Size(212, 22);
            this.txtDoNo.TabIndex = 20;
            // 
            // txtBlNo
            // 
            this.txtBlNo.Location = new System.Drawing.Point(804, 386);
            this.txtBlNo.Name = "txtBlNo";
            this.txtBlNo.Size = new System.Drawing.Size(212, 22);
            this.txtBlNo.TabIndex = 23;
            // 
            // txtDLicense
            // 
            this.txtDLicense.Location = new System.Drawing.Point(804, 325);
            this.txtDLicense.Name = "txtDLicense";
            this.txtDLicense.Size = new System.Drawing.Size(212, 22);
            this.txtDLicense.TabIndex = 19;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(456, 449);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(212, 22);
            this.txtRemark.TabIndex = 26;
            // 
            // txtCargoInfo
            // 
            this.txtCargoInfo.Location = new System.Drawing.Point(123, 449);
            this.txtCargoInfo.Multiline = true;
            this.txtCargoInfo.Name = "txtCargoInfo";
            this.txtCargoInfo.Size = new System.Drawing.Size(212, 22);
            this.txtCargoInfo.TabIndex = 25;
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(458, 386);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(212, 22);
            this.txtContainer.TabIndex = 22;
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(457, 325);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(212, 22);
            this.txtDriver.TabIndex = 18;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(123, 208);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(212, 22);
            this.txtCustomer.TabIndex = 7;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(719, 100);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(44, 16);
            this.lblTime.TabIndex = 62;
            this.lblTime.Text = "Time :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(371, 100);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 16);
            this.lblDate.TabIndex = 61;
            this.lblDate.Text = "Date :";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Location = new System.Drawing.Point(33, 331);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(67, 16);
            this.lblCash.TabIndex = 64;
            this.lblCash.Text = "Cash Amt:";
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(371, 331);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(86, 16);
            this.lblDriver.TabIndex = 65;
            this.lblDriver.Text = "Driver Name:";
            // 
            // lblWOption
            // 
            this.lblWOption.AutoSize = true;
            this.lblWOption.Location = new System.Drawing.Point(35, 273);
            this.lblWOption.Name = "lblWOption";
            this.lblWOption.Size = new System.Drawing.Size(62, 16);
            this.lblWOption.TabIndex = 66;
            this.lblWOption.Text = "WOption:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(35, 214);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(70, 16);
            this.lblCustomer.TabIndex = 67;
            this.lblCustomer.Text = "Customer :";
            // 
            // lblQRegNo
            // 
            this.lblQRegNo.AutoSize = true;
            this.lblQRegNo.Location = new System.Drawing.Point(33, 97);
            this.lblQRegNo.Name = "lblQRegNo";
            this.lblQRegNo.Size = new System.Drawing.Size(70, 16);
            this.lblQRegNo.TabIndex = 89;
            this.lblQRegNo.Text = "InReg No :";
            // 
            // txtInRegNo
            // 
            this.txtInRegNo.Location = new System.Drawing.Point(123, 94);
            this.txtInRegNo.Name = "txtInRegNo";
            this.txtInRegNo.Size = new System.Drawing.Size(212, 22);
            this.txtInRegNo.TabIndex = 1;
            // 
            // FrmQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1057, 650);
            this.Controls.Add(this.sfNtxtCash);
            this.Controls.Add(this.sfCbxGate);
            this.Controls.Add(this.sfCbxWBId);
            this.Controls.Add(this.sfCbxTrailer);
            this.Controls.Add(this.sfCbxTruck);
            this.Controls.Add(this.sfCbxBillOption);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sfCbxWType);
            this.Controls.Add(this.sfCbxWOption);
            this.Controls.Add(this.sfCbxCategory);
            this.Controls.Add(this.btnCancel);
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
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.sfDate);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDoNo);
            this.Controls.Add(this.lblBillOption);
            this.Controls.Add(this.lblWType);
            this.Controls.Add(this.txtInRegNo);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtDoNo);
            this.Controls.Add(this.txtBlNo);
            this.Controls.Add(this.txtDLicense);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtCargoInfo);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.lblDriver);
            this.Controls.Add(this.lblWOption);
            this.Controls.Add(this.lblCustomer);
            this.Name = "FrmQueue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm Queue";
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxGate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWBId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTrailer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTruck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxBillOption)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxCategory)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Syncfusion.WinForms.Input.SfNumericTextBox sfNtxtCash;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxGate;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxWBId;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxTrailer;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxTruck;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxBillOption;
        public Syncfusion.WinForms.Input.SfNumericTextBox sfNtxtWeight;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWeight;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxWType;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxWOption;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxCategory;
        private System.Windows.Forms.Button btnCancel;
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
        private System.Windows.Forms.Button btnSave;
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
    }
}