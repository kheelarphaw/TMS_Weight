using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMS_Weight.Models;
using TMS_Weight.Services;

namespace TMS_Weight.Forms
{
    partial class CtlAdHoc
    {

        private WeightApiService _apiService = new WeightApiService();

        public List<Transporter> transporterList;
        public List<Vehicle> truckList;
        public List<Vehicle> trailerList;
        public List<WeightBridge> weightBridgeList;
        public List<Gate> gateList;
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


        private async void LoadData()
        {

            //this.sfCbxWType.DataSource = new List<string> { "In", "Out" , "AdHoc" };
            this.sfCbxWType.DataSource = new List<string> { "Single" };
            this.sfCbxWOption.DataSource = new List<string> { "Single" };
            this.sfCbxBillOption.DataSource = new List<string> { "None", "Credit", "Cash" };
            this.sfCbxCategory.DataSource = new List<string> { "ICD", "Other", "Rail", "WH", "CCA" };

            this.sfCbxTransporter.DataSource = null;
            transporterList = await _apiService.GetTransporterList();
            if (transporterList.Count > 0)
                this.sfCbxTransporter.DataSource = transporterList;

            this.sfCbxWBId.DataSource = null;
            weightBridgeList = await _apiService.GetWeightBridgeList();
            if (weightBridgeList.Count > 0)
                this.sfCbxWBId.DataSource = weightBridgeList;

            this.sfCbxTruck.DataSource = null;
            truckList = await _apiService.GetTruckList();
            if (truckList.Count > 0)
                this.sfCbxTruck.DataSource = truckList;


            this.sfCbxTrailer.DataSource = null;
            trailerList = await _apiService.GetTrailerList();
            if (trailerList.Count > 0)
                this.sfCbxTrailer.DataSource = trailerList;


            this.sfCbxTrailer.DataSource = null;
            trailerList = await _apiService.GetTrailerList();
            if (trailerList.Count > 0)
                this.sfCbxTrailer.DataSource = trailerList;

            //this.sfCbxGate.DataSource = null;
            //gateList = await _apiService.GetGateList();
            //if (gateList.Count > 0)
            //    this.sfCbxGate.DataSource = gateList;


        }


        private async Task<ResponseMessage> SaveServiceBillForAdHoc()
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
            //serviceBill.VesselName = this.txtVessel.Text;
            serviceBill.Remark = this.txtRemark.Text;
            serviceBill.CargoInfo = this.txtCargoInfo.Text;
            serviceBill.OutWeight = Convert.ToDecimal(this.sfNtxtWeight.Text);

            if (this.sfCbxTransporter.SelectedItem is Transporter t)
                serviceBill.TransporterID = t.TransporterID;

            if (this.sfCbxTruck.SelectedItem is Vehicle truck)
                serviceBill.TruckNo = truck.VehicleRegNo;

            if (this.sfCbxTrailer.SelectedItem is Vehicle trailer)
                serviceBill.TrailerNo = trailer.VehicleRegNo;

            if (this.sfCbxWBId.SelectedItem is WeightBridge wb)
                serviceBill.WeightBridgeID = wb.WeightBridgeID;

            //if (this.sfCbxGate.SelectedItem is Gate gate)
            //{
            //    serviceBill.GateID = gate.GateID;
            //    serviceBill.YardID = gate.YardID;
            //}



            DateTime date = (DateTime)this.sfDate.Value; // Date part
            string timeString = this.txtTime.Text.ToString();
            TimeSpan time = TimeSpan.Parse(timeString);// Time part 
            serviceBill.OutWeightTime = (date + time);
            serviceBill.InWeightTime = null;

            //serviceBill.ServiceBillDate = (date + time).AddMinutes(390); //azure time


            msg = await _apiService.SaveServiceBillForAdHoc(serviceBill);
            if (msg.Status == true)
            {
                // LoadData();
                //ClearData();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAdHoc));
            this.lbladhoc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSave = new Syncfusion.WinForms.Controls.SfButton();
            this.sfNtxtCash = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.sfCbxWBId = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxTrailer = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxTruck = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxBillOption = new Syncfusion.WinForms.ListView.SfComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sfBtnGet = new Syncfusion.WinForms.Controls.SfButton();
            this.sfNtxtWeight = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.sfCbxTransporter = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxWType = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxWOption = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxCategory = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblwbId = new System.Windows.Forms.Label();
            this.lblBlno = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblVesselInfo = new System.Windows.Forms.Label();
            this.lblContainer = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblTrailer = new System.Windows.Forms.Label();
            this.lblTruck = new System.Windows.Forms.Label();
            this.sfDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.lblDoNo = new System.Windows.Forms.Label();
            this.lblTransporter = new System.Windows.Forms.Label();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWBId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTrailer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTruck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxBillOption)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTransporter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // lbladhoc
            // 
            this.lbladhoc.BackColor = System.Drawing.SystemColors.Control;
            this.lbladhoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladhoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbladhoc.Location = new System.Drawing.Point(0, 0);
            this.lbladhoc.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbladhoc.Name = "lbladhoc";
            this.lbladhoc.Size = new System.Drawing.Size(1210, 52);
            this.lbladhoc.TabIndex = 21;
            this.lbladhoc.Text = "Weight Data";
            this.lbladhoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.sfNtxtCash);
            this.panel1.Controls.Add(this.sfCbxWBId);
            this.panel1.Controls.Add(this.sfCbxTrailer);
            this.panel1.Controls.Add(this.sfCbxTruck);
            this.panel1.Controls.Add(this.sfCbxBillOption);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.sfCbxTransporter);
            this.panel1.Controls.Add(this.sfCbxWType);
            this.panel1.Controls.Add(this.sfCbxWOption);
            this.panel1.Controls.Add(this.sfCbxCategory);
            this.panel1.Controls.Add(this.lblwbId);
            this.panel1.Controls.Add(this.lblBlno);
            this.panel1.Controls.Add(this.lblRemark);
            this.panel1.Controls.Add(this.lblVesselInfo);
            this.panel1.Controls.Add(this.lblContainer);
            this.panel1.Controls.Add(this.lblLicense);
            this.panel1.Controls.Add(this.lblCategory);
            this.panel1.Controls.Add(this.lblTrailer);
            this.panel1.Controls.Add(this.lblTruck);
            this.panel1.Controls.Add(this.sfDate);
            this.panel1.Controls.Add(this.lblDoNo);
            this.panel1.Controls.Add(this.lblTransporter);
            this.panel1.Controls.Add(this.lblBillOption);
            this.panel1.Controls.Add(this.lblWType);
            this.panel1.Controls.Add(this.txtTime);
            this.panel1.Controls.Add(this.txtDoNo);
            this.panel1.Controls.Add(this.txtBlNo);
            this.panel1.Controls.Add(this.txtDLicense);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.txtCargoInfo);
            this.panel1.Controls.Add(this.txtContainer);
            this.panel1.Controls.Add(this.txtDriver);
            this.panel1.Controls.Add(this.txtCustomer);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblCash);
            this.panel1.Controls.Add(this.lblDriver);
            this.panel1.Controls.Add(this.lblWOption);
            this.panel1.Controls.Add(this.lblCustomer);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(6, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1191, 710);
            this.panel1.TabIndex = 22;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageSize = new System.Drawing.Size(24, 24);
            this.btnCancel.Location = new System.Drawing.Point(671, 608);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 40);
            this.btnCancel.Style.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnCancel.TabIndex = 96;
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
            this.btnSave.Location = new System.Drawing.Point(526, 608);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 40);
            this.btnSave.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSave.Style.ForeColor = System.Drawing.Color.White;
            this.btnSave.Style.Image = global::TMS_Weight.Properties.Resources.disk_blue1;
            this.btnSave.TabIndex = 95;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // sfNtxtCash
            // 
            this.sfNtxtCash.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sfNtxtCash.Location = new System.Drawing.Point(135, 228);
            this.sfNtxtCash.Margin = new System.Windows.Forms.Padding(5);
            this.sfNtxtCash.Name = "sfNtxtCash";
            this.sfNtxtCash.Size = new System.Drawing.Size(263, 30);
            this.sfNtxtCash.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sfNtxtCash.TabIndex = 57;
            // 
            // sfCbxWBId
            // 
            this.sfCbxWBId.DisplayMember = "Name";
            this.sfCbxWBId.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxWBId.Location = new System.Drawing.Point(516, 233);
            this.sfCbxWBId.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxWBId.Name = "sfCbxWBId";
            this.sfCbxWBId.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxWBId.Size = new System.Drawing.Size(265, 28);
            this.sfCbxWBId.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxWBId.TabIndex = 58;
            this.sfCbxWBId.TabStop = false;
            this.sfCbxWBId.ValueMember = "WeghtBridgeID";
            // 
            // sfCbxTrailer
            // 
            this.sfCbxTrailer.DisplayMember = "VehicleRegNo";
            this.sfCbxTrailer.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxTrailer.Location = new System.Drawing.Point(133, 91);
            this.sfCbxTrailer.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxTrailer.Name = "sfCbxTrailer";
            this.sfCbxTrailer.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxTrailer.Size = new System.Drawing.Size(265, 28);
            this.sfCbxTrailer.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxTrailer.TabIndex = 50;
            this.sfCbxTrailer.TabStop = false;
            this.sfCbxTrailer.ValueMember = "VehicleRegNo";
            // 
            // sfCbxTruck
            // 
            this.sfCbxTruck.DisplayMember = "VehicleRegNo";
            this.sfCbxTruck.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxTruck.Location = new System.Drawing.Point(916, 22);
            this.sfCbxTruck.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxTruck.Name = "sfCbxTruck";
            this.sfCbxTruck.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxTruck.Size = new System.Drawing.Size(265, 28);
            this.sfCbxTruck.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxTruck.TabIndex = 49;
            this.sfCbxTruck.TabStop = false;
            this.sfCbxTruck.ValueMember = "VehicleRegNo";
            // 
            // sfCbxBillOption
            // 
            this.sfCbxBillOption.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxBillOption.Location = new System.Drawing.Point(921, 167);
            this.sfCbxBillOption.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxBillOption.Name = "sfCbxBillOption";
            this.sfCbxBillOption.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxBillOption.Size = new System.Drawing.Size(260, 28);
            this.sfCbxBillOption.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxBillOption.TabIndex = 56;
            this.sfCbxBillOption.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.sfBtnGet);
            this.panel2.Controls.Add(this.sfNtxtWeight);
            this.panel2.Controls.Add(this.lblWeight);
            this.panel2.Location = new System.Drawing.Point(18, 511);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1168, 82);
            this.panel2.TabIndex = 91;
            // 
            // sfBtnGet
            // 
            this.sfBtnGet.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnGet.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnGet.ForeColor = System.Drawing.Color.White;
            this.sfBtnGet.ImageSize = new System.Drawing.Size(24, 24);
            this.sfBtnGet.Location = new System.Drawing.Point(839, 25);
            this.sfBtnGet.Name = "sfBtnGet";
            this.sfBtnGet.Size = new System.Drawing.Size(98, 30);
            this.sfBtnGet.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnGet.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnGet.Style.Image = global::TMS_Weight.Properties.Resources.disk_blue1;
            this.sfBtnGet.TabIndex = 95;
            this.sfBtnGet.Text = "&Get";
            this.sfBtnGet.UseVisualStyleBackColor = false;
            this.sfBtnGet.Click += new System.EventHandler(this.sfBtnGet_Click);
            // 
            // sfNtxtWeight
            // 
            this.sfNtxtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfNtxtWeight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sfNtxtWeight.Location = new System.Drawing.Point(415, 25);
            this.sfNtxtWeight.Margin = new System.Windows.Forms.Padding(5);
            this.sfNtxtWeight.Name = "sfNtxtWeight";
            this.sfNtxtWeight.Size = new System.Drawing.Size(375, 34);
            this.sfNtxtWeight.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sfNtxtWeight.TabIndex = 22;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(263, 30);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(127, 25);
            this.lblWeight.TabIndex = 32;
            this.lblWeight.Text = "Weighing In :";
            // 
            // sfCbxTransporter
            // 
            this.sfCbxTransporter.DisplayMember = "Name";
            this.sfCbxTransporter.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxTransporter.Location = new System.Drawing.Point(919, 304);
            this.sfCbxTransporter.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxTransporter.Name = "sfCbxTransporter";
            this.sfCbxTransporter.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxTransporter.Size = new System.Drawing.Size(262, 28);
            this.sfCbxTransporter.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxTransporter.TabIndex = 68;
            this.sfCbxTransporter.TabStop = false;
            this.sfCbxTransporter.ValueMember = "TransporterID";
            // 
            // sfCbxWType
            // 
            this.sfCbxWType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxWType.Location = new System.Drawing.Point(515, 160);
            this.sfCbxWType.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxWType.Name = "sfCbxWType";
            this.sfCbxWType.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxWType.Size = new System.Drawing.Size(265, 28);
            this.sfCbxWType.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxWType.TabIndex = 55;
            this.sfCbxWType.TabStop = false;
            // 
            // sfCbxWOption
            // 
            this.sfCbxWOption.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxWOption.Location = new System.Drawing.Point(133, 160);
            this.sfCbxWOption.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxWOption.Name = "sfCbxWOption";
            this.sfCbxWOption.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxWOption.Size = new System.Drawing.Size(265, 28);
            this.sfCbxWOption.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxWOption.TabIndex = 54;
            this.sfCbxWOption.TabStop = false;
            // 
            // sfCbxCategory
            // 
            this.sfCbxCategory.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxCategory.Location = new System.Drawing.Point(917, 94);
            this.sfCbxCategory.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxCategory.Name = "sfCbxCategory";
            this.sfCbxCategory.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxCategory.Size = new System.Drawing.Size(265, 28);
            this.sfCbxCategory.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxCategory.TabIndex = 53;
            this.sfCbxCategory.TabStop = false;
            // 
            // lblwbId
            // 
            this.lblwbId.AutoSize = true;
            this.lblwbId.Location = new System.Drawing.Point(421, 233);
            this.lblwbId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblwbId.Name = "lblwbId";
            this.lblwbId.Size = new System.Drawing.Size(77, 25);
            this.lblwbId.TabIndex = 87;
            this.lblwbId.Text = "WB Id :";
            // 
            // lblBlno
            // 
            this.lblBlno.AutoSize = true;
            this.lblBlno.Location = new System.Drawing.Point(426, 373);
            this.lblBlno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBlno.Name = "lblBlno";
            this.lblBlno.Size = new System.Drawing.Size(83, 25);
            this.lblBlno.TabIndex = 84;
            this.lblBlno.Text = "B/L No :";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(23, 448);
            this.lblRemark.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(90, 25);
            this.lblRemark.TabIndex = 83;
            this.lblRemark.Text = "Remark :";
            // 
            // lblVesselInfo
            // 
            this.lblVesselInfo.AutoSize = true;
            this.lblVesselInfo.Location = new System.Drawing.Point(800, 373);
            this.lblVesselInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVesselInfo.Name = "lblVesselInfo";
            this.lblVesselInfo.Size = new System.Drawing.Size(109, 25);
            this.lblVesselInfo.TabIndex = 82;
            this.lblVesselInfo.Text = "Cargo Info:";
            // 
            // lblContainer
            // 
            this.lblContainer.AutoSize = true;
            this.lblContainer.Location = new System.Drawing.Point(21, 373);
            this.lblContainer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblContainer.Name = "lblContainer";
            this.lblContainer.Size = new System.Drawing.Size(108, 25);
            this.lblContainer.TabIndex = 81;
            this.lblContainer.Text = "Container :";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(21, 304);
            this.lblLicense.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(105, 25);
            this.lblLicense.TabIndex = 78;
            this.lblLicense.Text = "DLicense :";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(811, 95);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(103, 25);
            this.lblCategory.TabIndex = 51;
            this.lblCategory.Text = "Category :";
            // 
            // lblTrailer
            // 
            this.lblTrailer.AutoSize = true;
            this.lblTrailer.Location = new System.Drawing.Point(18, 95);
            this.lblTrailer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTrailer.Name = "lblTrailer";
            this.lblTrailer.Size = new System.Drawing.Size(108, 25);
            this.lblTrailer.TabIndex = 88;
            this.lblTrailer.Text = "Trailer No :";
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.Location = new System.Drawing.Point(811, 22);
            this.lblTruck.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(103, 25);
            this.lblTruck.TabIndex = 89;
            this.lblTruck.Text = "Truck No :";
            // 
            // sfDate
            // 
            this.sfDate.DateTimeIcon = null;
            this.sfDate.Location = new System.Drawing.Point(133, 16);
            this.sfDate.Margin = new System.Windows.Forms.Padding(5);
            this.sfDate.Name = "sfDate";
            this.sfDate.Size = new System.Drawing.Size(264, 29);
            this.sfDate.TabIndex = 46;
            this.sfDate.ToolTipText = "";
            this.sfDate.Value = new System.DateTime(2024, 12, 25, 0, 0, 0, 0);
            // 
            // lblDoNo
            // 
            this.lblDoNo.AutoSize = true;
            this.lblDoNo.Location = new System.Drawing.Point(421, 304);
            this.lblDoNo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDoNo.Name = "lblDoNo";
            this.lblDoNo.Size = new System.Drawing.Size(78, 25);
            this.lblDoNo.TabIndex = 79;
            this.lblDoNo.Text = "DO No:";
            // 
            // lblTransporter
            // 
            this.lblTransporter.AutoSize = true;
            this.lblTransporter.Location = new System.Drawing.Point(796, 304);
            this.lblTransporter.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTransporter.Name = "lblTransporter";
            this.lblTransporter.Size = new System.Drawing.Size(124, 25);
            this.lblTransporter.TabIndex = 77;
            this.lblTransporter.Text = "Transporter :";
            // 
            // lblBillOption
            // 
            this.lblBillOption.AutoSize = true;
            this.lblBillOption.Location = new System.Drawing.Point(811, 164);
            this.lblBillOption.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBillOption.Name = "lblBillOption";
            this.lblBillOption.Size = new System.Drawing.Size(111, 25);
            this.lblBillOption.TabIndex = 80;
            this.lblBillOption.Text = "Bill Option :";
            // 
            // lblWType
            // 
            this.lblWType.AutoSize = true;
            this.lblWType.Location = new System.Drawing.Point(421, 164);
            this.lblWType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWType.Name = "lblWType";
            this.lblWType.Size = new System.Drawing.Size(88, 25);
            this.lblWType.TabIndex = 76;
            this.lblWType.Text = "WType :";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(514, 20);
            this.txtTime.Margin = new System.Windows.Forms.Padding(5);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(263, 30);
            this.txtTime.TabIndex = 47;
            // 
            // txtDoNo
            // 
            this.txtDoNo.Location = new System.Drawing.Point(516, 301);
            this.txtDoNo.Margin = new System.Windows.Forms.Padding(5);
            this.txtDoNo.Name = "txtDoNo";
            this.txtDoNo.Size = new System.Drawing.Size(263, 30);
            this.txtDoNo.TabIndex = 63;
            // 
            // txtBlNo
            // 
            this.txtBlNo.Location = new System.Drawing.Point(517, 368);
            this.txtBlNo.Margin = new System.Windows.Forms.Padding(5);
            this.txtBlNo.Name = "txtBlNo";
            this.txtBlNo.Size = new System.Drawing.Size(263, 30);
            this.txtBlNo.TabIndex = 70;
            // 
            // txtDLicense
            // 
            this.txtDLicense.Location = new System.Drawing.Point(134, 299);
            this.txtDLicense.Margin = new System.Windows.Forms.Padding(5);
            this.txtDLicense.Name = "txtDLicense";
            this.txtDLicense.Size = new System.Drawing.Size(263, 30);
            this.txtDLicense.TabIndex = 60;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(134, 445);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(5);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(263, 26);
            this.txtRemark.TabIndex = 73;
            // 
            // txtCargoInfo
            // 
            this.txtCargoInfo.Location = new System.Drawing.Point(919, 373);
            this.txtCargoInfo.Margin = new System.Windows.Forms.Padding(5);
            this.txtCargoInfo.Multiline = true;
            this.txtCargoInfo.Name = "txtCargoInfo";
            this.txtCargoInfo.Size = new System.Drawing.Size(263, 30);
            this.txtCargoInfo.TabIndex = 72;
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(134, 366);
            this.txtContainer.Margin = new System.Windows.Forms.Padding(5);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(263, 30);
            this.txtContainer.TabIndex = 69;
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(921, 234);
            this.txtDriver.Margin = new System.Windows.Forms.Padding(5);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(261, 30);
            this.txtDriver.TabIndex = 59;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(516, 89);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(5);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(263, 30);
            this.txtCustomer.TabIndex = 52;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(421, 25);
            this.lblTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(67, 25);
            this.lblTime.TabIndex = 62;
            this.lblTime.Text = "Time :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(18, 25);
            this.lblDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 25);
            this.lblDate.TabIndex = 61;
            this.lblDate.Text = "Date :";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Location = new System.Drawing.Point(18, 233);
            this.lblCash.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(105, 25);
            this.lblCash.TabIndex = 64;
            this.lblCash.Text = "Cash Amt:";
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(796, 233);
            this.lblDriver.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(126, 25);
            this.lblDriver.TabIndex = 65;
            this.lblDriver.Text = "Driver Name:";
            // 
            // lblWOption
            // 
            this.lblWOption.AutoSize = true;
            this.lblWOption.Location = new System.Drawing.Point(18, 164);
            this.lblWOption.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWOption.Name = "lblWOption";
            this.lblWOption.Size = new System.Drawing.Size(96, 25);
            this.lblWOption.TabIndex = 66;
            this.lblWOption.Text = "WOption:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(408, 95);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(108, 25);
            this.lblCustomer.TabIndex = 67;
            this.lblCustomer.Text = "Customer :";
            // 
            // CtlAdHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbladhoc);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CtlAdHoc";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Size = new System.Drawing.Size(1210, 771);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWBId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTrailer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTruck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxBillOption)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTransporter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbladhoc;
        private System.Windows.Forms.Panel panel1;
        public Syncfusion.WinForms.Input.SfNumericTextBox sfNtxtCash;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxWBId;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxTrailer;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxTruck;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxBillOption;
        private System.Windows.Forms.Panel panel2;
        public Syncfusion.WinForms.Input.SfNumericTextBox sfNtxtWeight;
        private System.Windows.Forms.Label lblWeight;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxTransporter;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxWType;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxWOption;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxCategory;
        private System.Windows.Forms.Label lblwbId;
        private System.Windows.Forms.Label lblBlno;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblVesselInfo;
        private System.Windows.Forms.Label lblContainer;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblTrailer;
        private System.Windows.Forms.Label lblTruck;
        public Syncfusion.WinForms.Input.SfDateTimeEdit sfDate;
        private System.Windows.Forms.Label lblDoNo;
        private System.Windows.Forms.Label lblTransporter;
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
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.WinForms.Controls.SfButton sfBtnGet;
    }
}
