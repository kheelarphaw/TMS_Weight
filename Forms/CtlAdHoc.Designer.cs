using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public List<Customer> cusList;
        // public List<WeightBridge> weightBridgeList;
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

            this.sfCbxBillOption.DataSource = new List<string> { "None", "Credit", "Cash" };
            this.sfCbxCategory.DataSource = new List<string> { "ICD", "Other", "Rail", "WH", "CCA" };

            this.sfCbxTransporter.DataSource = null;
            transporterList = await _apiService.GetTransporterList();
            if (transporterList.Count > 0)
                this.sfCbxTransporter.DataSource = transporterList;


            // Retrieve the YardCode setting from Properties
            this.txtwbId.Text = Properties.Settings.Default.WBCode;

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


            this.sfCbxCustomer.DataSource = null;
            cusList = await _apiService.GetCustomerList();
            if (cusList.Count > 0)
                this.sfCbxCustomer.DataSource = cusList;

        }


        private async Task<ResponseMessage> SaveServiceBillForAdHoc()
        {
            ResponseMessage msg = new ResponseMessage();

            if (string.IsNullOrWhiteSpace(txtAdHocWeight.Text) || sfCbxTruck.SelectedItem == null || sfCbxTrailer.SelectedItem == null
                || string.IsNullOrWhiteSpace(sfCbxCategory.SelectedItem.ToString()) || string.IsNullOrWhiteSpace(sfCbxBillOption.SelectedItem.ToString())
               )
            {
                MessageBoxAdv.Show(this, "Data are required!", "Weight Service Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return msg;
            }

            WeightServiceBill serviceBill = new WeightServiceBill();

            serviceBill.ServiceBillNo = ""; 
            serviceBill.WeightBridgeID = this.txtwbId.Text;
            serviceBill.WeightCategory = this.sfCbxCategory.SelectedItem.ToString();
            serviceBill.WeightOption = this.txtWOption.Text;
            serviceBill.WeightType = this.txtWType.Text;
            serviceBill.BillOption = this.sfCbxBillOption.SelectedItem.ToString();
            serviceBill.DONo = this.txtDoNo.Text;
            serviceBill.DriverName = this.txtDriver.Text;
            serviceBill.DriverLicense = this.txtDLicense.Text;
            serviceBill.OutWeightCash = Convert.ToDecimal(this.txtCash.Text);
            serviceBill.ContainerNo = this.txtContainer.Text;
            serviceBill.BLNo = this.txtBlNo.Text;
            serviceBill.Remark = this.txtRemark.Text;
            serviceBill.CargoInfo = this.txtCargoInfo.Text;
            serviceBill.CreatedUser = CommonData.userName;
            // Extract the numeric value using regex
            string wvalue = System.Text.RegularExpressions.Regex.Match(this.txtAdHocWeight.Text, @"\d+").Value;

            // Convert the extracted number string to an integer
            int value = int.Parse(wvalue);

            serviceBill.OutWeight = Convert.ToDecimal(value);

            if (this.sfCbxTransporter.SelectedItem is Transporter t)
                serviceBill.TransporterID = t.TransporterID;

            if (this.sfCbxTruck.SelectedItem is Vehicle truck)
                serviceBill.TruckNo = truck.VehicleRegNo;

            if (this.sfCbxTrailer.SelectedItem is Vehicle trailer)
                serviceBill.TrailerNo = trailer.VehicleRegNo;

            if (this.sfCbxCustomer.SelectedItem is Customer cus)
                serviceBill.CustomerName = cus.Name;



            DateTime date = (DateTime)this.sfDate.Value; // Date part
            //string timeString = this.txtTime.Text.ToString();
            //TimeSpan time = TimeSpan.Parse(timeString);// Time part 
            serviceBill.OutWeightTime = date ;
            serviceBill.InWeightTime = null;

            serviceBill.ServiceBillDate = serviceBill.OutWeightTime;

            //serviceBill.ServiceBillDate = (date + time).AddMinutes(390); //azure time


            msg = await _apiService.SaveServiceBillForAdHoc(serviceBill);
            if (msg.Status == true)
            {
                // LoadData();
                //ClearData();

            }

            return msg;



        }


         #region Utility Methods

        private void ShowError(string message, Exception ex)
        {
            MessageBoxAdv.Show(this, $"{message}\nDetails: {ex.Message}", "Weight Service Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion



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
            this.btnAdHocCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnAdHocSave = new Syncfusion.WinForms.Controls.SfButton();
            this.sfCbxTrailer = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxCustomer = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxTruck = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxBillOption = new Syncfusion.WinForms.ListView.SfComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sfBtnGetAdHoc = new Syncfusion.WinForms.Controls.SfButton();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtAdHocWeight = new System.Windows.Forms.TextBox();
            this.sfCbxTransporter = new Syncfusion.WinForms.ListView.SfComboBox();
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
            this.txtDoNo = new System.Windows.Forms.TextBox();
            this.txtBlNo = new System.Windows.Forms.TextBox();
            this.txtDLicense = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtCargoInfo = new System.Windows.Forms.TextBox();
            this.txtContainer = new System.Windows.Forms.TextBox();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.txtwbId = new System.Windows.Forms.TextBox();
            this.txtWType = new System.Windows.Forms.TextBox();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.txtWOption = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblDriver = new System.Windows.Forms.Label();
            this.lblWOption = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTrailer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTruck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxBillOption)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTransporter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // lbladhoc
            // 
            this.lbladhoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbladhoc.BackColor = System.Drawing.SystemColors.Control;
            this.lbladhoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladhoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbladhoc.Location = new System.Drawing.Point(0, 0);
            this.lbladhoc.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbladhoc.Name = "lbladhoc";
            this.lbladhoc.Size = new System.Drawing.Size(1534, 52);
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
            this.panel1.Controls.Add(this.btnAdHocCancel);
            this.panel1.Controls.Add(this.btnAdHocSave);
            this.panel1.Controls.Add(this.sfCbxTrailer);
            this.panel1.Controls.Add(this.sfCbxCustomer);
            this.panel1.Controls.Add(this.sfCbxTruck);
            this.panel1.Controls.Add(this.sfCbxBillOption);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.sfCbxTransporter);
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
            this.panel1.Controls.Add(this.txtDoNo);
            this.panel1.Controls.Add(this.txtBlNo);
            this.panel1.Controls.Add(this.txtDLicense);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.txtCargoInfo);
            this.panel1.Controls.Add(this.txtContainer);
            this.panel1.Controls.Add(this.txtDriver);
            this.panel1.Controls.Add(this.txtwbId);
            this.panel1.Controls.Add(this.txtWType);
            this.panel1.Controls.Add(this.txtCash);
            this.panel1.Controls.Add(this.txtWOption);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblCash);
            this.panel1.Controls.Add(this.lblDriver);
            this.panel1.Controls.Add(this.lblWOption);
            this.panel1.Controls.Add(this.lblCustomer);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(9, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.panel1.Size = new System.Drawing.Size(1497, 710);
            this.panel1.TabIndex = 0;
            // 
            // btnAdHocCancel
            // 
            this.btnAdHocCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAdHocCancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdHocCancel.ForeColor = System.Drawing.Color.White;
            this.btnAdHocCancel.ImageSize = new System.Drawing.Size(24, 24);
            this.btnAdHocCancel.Location = new System.Drawing.Point(751, 577);
            this.btnAdHocCancel.Name = "btnAdHocCancel";
            this.btnAdHocCancel.Size = new System.Drawing.Size(118, 40);
            this.btnAdHocCancel.Style.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAdHocCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnAdHocCancel.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnAdHocCancel.TabIndex = 23;
            this.btnAdHocCancel.Text = "&Cancel";
            this.btnAdHocCancel.UseVisualStyleBackColor = false;
            this.btnAdHocCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdHocSave
            // 
            this.btnAdHocSave.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdHocSave.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdHocSave.ForeColor = System.Drawing.Color.White;
            this.btnAdHocSave.ImageSize = new System.Drawing.Size(24, 24);
            this.btnAdHocSave.Location = new System.Drawing.Point(596, 577);
            this.btnAdHocSave.Name = "btnAdHocSave";
            this.btnAdHocSave.Size = new System.Drawing.Size(118, 40);
            this.btnAdHocSave.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdHocSave.Style.ForeColor = System.Drawing.Color.White;
            this.btnAdHocSave.Style.Image = global::TMS_Weight.Properties.Resources.disk_blue1;
            this.btnAdHocSave.TabIndex = 22;
            this.btnAdHocSave.Text = "&Save";
            this.btnAdHocSave.UseVisualStyleBackColor = false;
            this.btnAdHocSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // sfCbxTrailer
            // 
            this.sfCbxTrailer.DisplayMember = "VehicleRegNo";
            this.sfCbxTrailer.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxTrailer.Location = new System.Drawing.Point(1145, 29);
            this.sfCbxTrailer.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxTrailer.Name = "sfCbxTrailer";
            this.sfCbxTrailer.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxTrailer.Size = new System.Drawing.Size(312, 33);
            this.sfCbxTrailer.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfCbxTrailer.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxTrailer.TabIndex = 4;
            this.sfCbxTrailer.TabStop = false;
            this.sfCbxTrailer.ValueMember = "VehicleRegNo";
            // 
            // sfCbxCustomer
            // 
            this.sfCbxCustomer.DisplayMember = "Name";
            this.sfCbxCustomer.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxCustomer.Location = new System.Drawing.Point(171, 92);
            this.sfCbxCustomer.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxCustomer.Name = "sfCbxCustomer";
            this.sfCbxCustomer.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxCustomer.Size = new System.Drawing.Size(312, 28);
            this.sfCbxCustomer.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfCbxCustomer.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxCustomer.TabIndex = 3;
            this.sfCbxCustomer.TabStop = false;
            this.sfCbxCustomer.ValueMember = "Name";
            // 
            // sfCbxTruck
            // 
            this.sfCbxTruck.DisplayMember = "VehicleRegNo";
            this.sfCbxTruck.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxTruck.Location = new System.Drawing.Point(652, 29);
            this.sfCbxTruck.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxTruck.Name = "sfCbxTruck";
            this.sfCbxTruck.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxTruck.Size = new System.Drawing.Size(312, 33);
            this.sfCbxTruck.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfCbxTruck.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxTruck.TabIndex = 3;
            this.sfCbxTruck.TabStop = false;
            this.sfCbxTruck.ValueMember = "VehicleRegNo";
            // 
            // sfCbxBillOption
            // 
            this.sfCbxBillOption.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxBillOption.Location = new System.Drawing.Point(652, 160);
            this.sfCbxBillOption.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxBillOption.Name = "sfCbxBillOption";
            this.sfCbxBillOption.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxBillOption.Size = new System.Drawing.Size(312, 28);
            this.sfCbxBillOption.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfCbxBillOption.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxBillOption.TabIndex = 9;
            this.sfCbxBillOption.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.sfBtnGetAdHoc);
            this.panel2.Controls.Add(this.lblWeight);
            this.panel2.Controls.Add(this.txtAdHocWeight);
            this.panel2.Location = new System.Drawing.Point(52, 452);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1406, 82);
            this.panel2.TabIndex = 91;
            // 
            // sfBtnGetAdHoc
            // 
            this.sfBtnGetAdHoc.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnGetAdHoc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfBtnGetAdHoc.ForeColor = System.Drawing.Color.White;
            this.sfBtnGetAdHoc.ImageSize = new System.Drawing.Size(24, 24);
            this.sfBtnGetAdHoc.Location = new System.Drawing.Point(891, 26);
            this.sfBtnGetAdHoc.Name = "sfBtnGetAdHoc";
            this.sfBtnGetAdHoc.Size = new System.Drawing.Size(98, 30);
            this.sfBtnGetAdHoc.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.sfBtnGetAdHoc.Style.ForeColor = System.Drawing.Color.White;
            this.sfBtnGetAdHoc.Style.Image = global::TMS_Weight.Properties.Resources.window_edit;
            this.sfBtnGetAdHoc.TabIndex = 21;
            this.sfBtnGetAdHoc.Text = "&Get";
            this.sfBtnGetAdHoc.UseVisualStyleBackColor = false;
            this.sfBtnGetAdHoc.Click += new System.EventHandler(this.sfBtnGetAdHocWeight_Click);
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(412, 33);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(127, 25);
            this.lblWeight.TabIndex = 32;
            this.lblWeight.Text = "Weighing In :";
            // 
            // txtAdHocWeight
            // 
            this.txtAdHocWeight.Location = new System.Drawing.Point(566, 30);
            this.txtAdHocWeight.Margin = new System.Windows.Forms.Padding(5);
            this.txtAdHocWeight.Multiline = true;
            this.txtAdHocWeight.Name = "txtAdHocWeight";
            this.txtAdHocWeight.Size = new System.Drawing.Size(296, 26);
            this.txtAdHocWeight.TabIndex = 20;
            // 
            // sfCbxTransporter
            // 
            this.sfCbxTransporter.DisplayMember = "Name";
            this.sfCbxTransporter.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxTransporter.Location = new System.Drawing.Point(655, 303);
            this.sfCbxTransporter.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxTransporter.Name = "sfCbxTransporter";
            this.sfCbxTransporter.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxTransporter.Size = new System.Drawing.Size(309, 28);
            this.sfCbxTransporter.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfCbxTransporter.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxTransporter.TabIndex = 15;
            this.sfCbxTransporter.TabStop = false;
            this.sfCbxTransporter.ValueMember = "TransporterID";
            // 
            // sfCbxCategory
            // 
            this.sfCbxCategory.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxCategory.Location = new System.Drawing.Point(652, 98);
            this.sfCbxCategory.Margin = new System.Windows.Forms.Padding(5);
            this.sfCbxCategory.Name = "sfCbxCategory";
            this.sfCbxCategory.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sfCbxCategory.Size = new System.Drawing.Size(312, 28);
            this.sfCbxCategory.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfCbxCategory.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxCategory.TabIndex = 6;
            this.sfCbxCategory.TabStop = false;
            // 
            // lblwbId
            // 
            this.lblwbId.AutoSize = true;
            this.lblwbId.Location = new System.Drawing.Point(47, 230);
            this.lblwbId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblwbId.Name = "lblwbId";
            this.lblwbId.Size = new System.Drawing.Size(77, 25);
            this.lblwbId.TabIndex = 87;
            this.lblwbId.Text = "WB Id :";
            // 
            // lblBlno
            // 
            this.lblBlno.AutoSize = true;
            this.lblBlno.Location = new System.Drawing.Point(47, 376);
            this.lblBlno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBlno.Name = "lblBlno";
            this.lblBlno.Size = new System.Drawing.Size(83, 25);
            this.lblBlno.TabIndex = 84;
            this.lblBlno.Text = "B/L No :";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(998, 377);
            this.lblRemark.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(90, 25);
            this.lblRemark.TabIndex = 83;
            this.lblRemark.Text = "Remark :";
            // 
            // lblVesselInfo
            // 
            this.lblVesselInfo.AutoSize = true;
            this.lblVesselInfo.Location = new System.Drawing.Point(516, 377);
            this.lblVesselInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVesselInfo.Name = "lblVesselInfo";
            this.lblVesselInfo.Size = new System.Drawing.Size(109, 25);
            this.lblVesselInfo.TabIndex = 82;
            this.lblVesselInfo.Text = "Cargo Info:";
            // 
            // lblContainer
            // 
            this.lblContainer.AutoSize = true;
            this.lblContainer.Location = new System.Drawing.Point(998, 301);
            this.lblContainer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblContainer.Name = "lblContainer";
            this.lblContainer.Size = new System.Drawing.Size(108, 25);
            this.lblContainer.TabIndex = 81;
            this.lblContainer.Text = "Container :";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(998, 230);
            this.lblLicense.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(105, 25);
            this.lblLicense.TabIndex = 78;
            this.lblLicense.Text = "DLicense :";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(514, 98);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(103, 25);
            this.lblCategory.TabIndex = 51;
            this.lblCategory.Text = "Category :";
            // 
            // lblTrailer
            // 
            this.lblTrailer.AutoSize = true;
            this.lblTrailer.Location = new System.Drawing.Point(998, 34);
            this.lblTrailer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTrailer.Name = "lblTrailer";
            this.lblTrailer.Size = new System.Drawing.Size(108, 25);
            this.lblTrailer.TabIndex = 88;
            this.lblTrailer.Text = "Trailer No :";
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.Location = new System.Drawing.Point(514, 29);
            this.lblTruck.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(103, 25);
            this.lblTruck.TabIndex = 89;
            this.lblTruck.Text = "Truck No :";
            // 
            // sfDate
            // 
            this.sfDate.DateTimeIcon = null;
            this.sfDate.Location = new System.Drawing.Point(171, 21);
            this.sfDate.Margin = new System.Windows.Forms.Padding(5);
            this.sfDate.MinDateTime = new System.DateTime(2025, 1, 14, 16, 28, 53, 0);
            this.sfDate.Name = "sfDate";
            this.sfDate.Size = new System.Drawing.Size(312, 33);
            this.sfDate.TabIndex = 1;
            this.sfDate.ToolTipText = "";
            this.sfDate.Value = new System.DateTime(2025, 1, 14, 16, 28, 53, 0);
            // 
            // lblDoNo
            // 
            this.lblDoNo.AutoSize = true;
            this.lblDoNo.Location = new System.Drawing.Point(47, 301);
            this.lblDoNo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDoNo.Name = "lblDoNo";
            this.lblDoNo.Size = new System.Drawing.Size(78, 25);
            this.lblDoNo.TabIndex = 79;
            this.lblDoNo.Text = "DO No:";
            // 
            // lblTransporter
            // 
            this.lblTransporter.AutoSize = true;
            this.lblTransporter.Location = new System.Drawing.Point(514, 301);
            this.lblTransporter.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTransporter.Name = "lblTransporter";
            this.lblTransporter.Size = new System.Drawing.Size(124, 25);
            this.lblTransporter.TabIndex = 77;
            this.lblTransporter.Text = "Transporter :";
            // 
            // lblBillOption
            // 
            this.lblBillOption.AutoSize = true;
            this.lblBillOption.Location = new System.Drawing.Point(514, 163);
            this.lblBillOption.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBillOption.Name = "lblBillOption";
            this.lblBillOption.Size = new System.Drawing.Size(111, 25);
            this.lblBillOption.TabIndex = 80;
            this.lblBillOption.Text = "Bill Option :";
            // 
            // lblWType
            // 
            this.lblWType.AutoSize = true;
            this.lblWType.Location = new System.Drawing.Point(47, 160);
            this.lblWType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWType.Name = "lblWType";
            this.lblWType.Size = new System.Drawing.Size(88, 25);
            this.lblWType.TabIndex = 76;
            this.lblWType.Text = "WType :";
            // 
            // txtDoNo
            // 
            this.txtDoNo.Location = new System.Drawing.Point(170, 301);
            this.txtDoNo.Margin = new System.Windows.Forms.Padding(5);
            this.txtDoNo.Name = "txtDoNo";
            this.txtDoNo.Size = new System.Drawing.Size(312, 30);
            this.txtDoNo.TabIndex = 14;
            // 
            // txtBlNo
            // 
            this.txtBlNo.Location = new System.Drawing.Point(170, 374);
            this.txtBlNo.Margin = new System.Windows.Forms.Padding(5);
            this.txtBlNo.Name = "txtBlNo";
            this.txtBlNo.Size = new System.Drawing.Size(313, 30);
            this.txtBlNo.TabIndex = 17;
            // 
            // txtDLicense
            // 
            this.txtDLicense.Location = new System.Drawing.Point(1146, 227);
            this.txtDLicense.Margin = new System.Windows.Forms.Padding(5);
            this.txtDLicense.Name = "txtDLicense";
            this.txtDLicense.Size = new System.Drawing.Size(312, 30);
            this.txtDLicense.TabIndex = 13;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(1148, 376);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(5);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(312, 26);
            this.txtRemark.TabIndex = 19;
            // 
            // txtCargoInfo
            // 
            this.txtCargoInfo.Location = new System.Drawing.Point(655, 373);
            this.txtCargoInfo.Margin = new System.Windows.Forms.Padding(5);
            this.txtCargoInfo.Multiline = true;
            this.txtCargoInfo.Name = "txtCargoInfo";
            this.txtCargoInfo.Size = new System.Drawing.Size(309, 30);
            this.txtCargoInfo.TabIndex = 18;
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(1148, 298);
            this.txtContainer.Margin = new System.Windows.Forms.Padding(5);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(312, 30);
            this.txtContainer.TabIndex = 16;
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(652, 227);
            this.txtDriver.Margin = new System.Windows.Forms.Padding(5);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(312, 30);
            this.txtDriver.TabIndex = 12;
            // 
            // txtwbId
            // 
            this.txtwbId.Location = new System.Drawing.Point(170, 230);
            this.txtwbId.Margin = new System.Windows.Forms.Padding(5);
            this.txtwbId.Name = "txtwbId";
            this.txtwbId.Size = new System.Drawing.Size(313, 30);
            this.txtwbId.TabIndex = 8;
            // 
            // txtWType
            // 
            this.txtWType.Location = new System.Drawing.Point(170, 159);
            this.txtWType.Margin = new System.Windows.Forms.Padding(5);
            this.txtWType.Name = "txtWType";
            this.txtWType.Size = new System.Drawing.Size(313, 30);
            this.txtWType.TabIndex = 8;
            this.txtWType.Text = "Single";
            // 
            // txtCash
            // 
            this.txtCash.Location = new System.Drawing.Point(1145, 161);
            this.txtCash.Margin = new System.Windows.Forms.Padding(5);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(312, 30);
            this.txtCash.TabIndex = 10;
            this.txtCash.Text = "0";
            // 
            // txtWOption
            // 
            this.txtWOption.Location = new System.Drawing.Point(1147, 98);
            this.txtWOption.Margin = new System.Windows.Forms.Padding(5);
            this.txtWOption.Name = "txtWOption";
            this.txtWOption.Size = new System.Drawing.Size(312, 30);
            this.txtWOption.TabIndex = 7;
            this.txtWOption.Text = "Single";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(41, 25);
            this.lblDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 25);
            this.lblDate.TabIndex = 61;
            this.lblDate.Text = "Date :";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Location = new System.Drawing.Point(998, 164);
            this.lblCash.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(105, 25);
            this.lblCash.TabIndex = 64;
            this.lblCash.Text = "Cash Amt:";
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(514, 235);
            this.lblDriver.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(126, 25);
            this.lblDriver.TabIndex = 65;
            this.lblDriver.Text = "Driver Name:";
            // 
            // lblWOption
            // 
            this.lblWOption.AutoSize = true;
            this.lblWOption.Location = new System.Drawing.Point(998, 98);
            this.lblWOption.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWOption.Name = "lblWOption";
            this.lblWOption.Size = new System.Drawing.Size(96, 25);
            this.lblWOption.TabIndex = 66;
            this.lblWOption.Text = "WOption:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(41, 95);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(108, 25);
            this.lblCustomer.TabIndex = 67;
            this.lblCustomer.Text = "Customer :";
            // 
            // CtlAdHoc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbladhoc);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CtlAdHoc";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Size = new System.Drawing.Size(1545, 1102);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTrailer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTruck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxBillOption)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTransporter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbladhoc;
        private System.Windows.Forms.Panel panel1;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxTrailer;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxTruck;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxBillOption;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWeight;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxTransporter;
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
        public System.Windows.Forms.TextBox txtDoNo;
        public System.Windows.Forms.TextBox txtBlNo;
        public System.Windows.Forms.TextBox txtDLicense;
        public System.Windows.Forms.TextBox txtRemark;
        public System.Windows.Forms.TextBox txtCargoInfo;
        public System.Windows.Forms.TextBox txtContainer;
        public System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.Label lblWOption;
        private System.Windows.Forms.Label lblCustomer;
        private Syncfusion.WinForms.Controls.SfButton btnAdHocCancel;
        private Syncfusion.WinForms.Controls.SfButton btnAdHocSave;
        private Syncfusion.WinForms.Controls.SfButton sfBtnGetAdHoc;
        public System.Windows.Forms.TextBox txtAdHocWeight;
        public System.Windows.Forms.TextBox txtWType;
        public System.Windows.Forms.TextBox txtCash;
        public System.Windows.Forms.TextBox txtWOption;
        public TextBox txtwbId;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxCustomer;
    }
}
