using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Weight.Models;
using TMS_Weight.Services;

namespace TMS_Weight.Forms
{
    partial class FrmAdHoc
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.sfDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lblheader = new System.Windows.Forms.Label();
            this.lblVessel = new System.Windows.Forms.Label();
            this.lblBlno = new System.Windows.Forms.Label();
            this.lblContainer = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblTruck = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblTrailer = new System.Windows.Forms.Label();
            this.sfCbxCategory = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblTransporter = new System.Windows.Forms.Label();
            this.sfCbxTransporter = new Syncfusion.WinForms.ListView.SfComboBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblWOption = new System.Windows.Forms.Label();
            this.lblWType = new System.Windows.Forms.Label();
            this.sfCbxWOption = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxWType = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblDoNo = new System.Windows.Forms.Label();
            this.txtDoNo = new System.Windows.Forms.TextBox();
            this.lblDriver = new System.Windows.Forms.Label();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.lblLicense = new System.Windows.Forms.Label();
            this.txtDLicense = new System.Windows.Forms.TextBox();
            this.lblCash = new System.Windows.Forms.Label();
            this.txtContainer = new System.Windows.Forms.TextBox();
            this.txtBlNo = new System.Windows.Forms.TextBox();
            this.txtVessel = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sfNtxtWeight = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.sfNtxtCash = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.lblVesselInfo = new System.Windows.Forms.Label();
            this.txtCargoInfo = new System.Windows.Forms.TextBox();
            this.lblwbId = new System.Windows.Forms.Label();
            this.sfCbxWBId = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxTruck = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfCbxTrailer = new Syncfusion.WinForms.ListView.SfComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sfCbxGate = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblBillOption = new System.Windows.Forms.Label();
            this.sfCbxBillOption = new Syncfusion.WinForms.ListView.SfComboBox();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTransporter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWType)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWBId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTruck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTrailer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxGate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxBillOption)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(670, 749);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 49);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(544, 749);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 49);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // sfDate
            // 
            this.sfDate.DateTimeIcon = null;
            this.sfDate.Location = new System.Drawing.Point(154, 115);
            this.sfDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfDate.Name = "sfDate";
            this.sfDate.Size = new System.Drawing.Size(264, 28);
            this.sfDate.TabIndex = 1;
            this.sfDate.ToolTipText = "";
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnHeader.Controls.Add(this.lblheader);
            this.pnHeader.Location = new System.Drawing.Point(-1, 1);
            this.pnHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1324, 69);
            this.pnHeader.TabIndex = 35;
            // 
            // lblheader
            // 
            this.lblheader.AutoSize = true;
            this.lblheader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheader.Location = new System.Drawing.Point(568, 16);
            this.lblheader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblheader.Name = "lblheader";
            this.lblheader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblheader.Size = new System.Drawing.Size(120, 25);
            this.lblheader.TabIndex = 1;
            this.lblheader.Text = "Weight Data";
            this.lblheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVessel
            // 
            this.lblVessel.AutoSize = true;
            this.lblVessel.Location = new System.Drawing.Point(41, 558);
            this.lblVessel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVessel.Name = "lblVessel";
            this.lblVessel.Size = new System.Drawing.Size(70, 20);
            this.lblVessel.TabIndex = 33;
            this.lblVessel.Text = "Vessel :";
            // 
            // lblBlno
            // 
            this.lblBlno.AutoSize = true;
            this.lblBlno.Location = new System.Drawing.Point(899, 488);
            this.lblBlno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlno.Name = "lblBlno";
            this.lblBlno.Size = new System.Drawing.Size(72, 20);
            this.lblBlno.TabIndex = 32;
            this.lblBlno.Text = "B/L No :";
            // 
            // lblContainer
            // 
            this.lblContainer.AutoSize = true;
            this.lblContainer.Location = new System.Drawing.Point(460, 488);
            this.lblContainer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContainer.Name = "lblContainer";
            this.lblContainer.Size = new System.Drawing.Size(91, 20);
            this.lblContainer.TabIndex = 31;
            this.lblContainer.Text = "Container :";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(41, 268);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(86, 20);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Category :";
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.Location = new System.Drawing.Point(40, 195);
            this.lblTruck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(87, 20);
            this.lblTruck.TabIndex = 34;
            this.lblTruck.Text = "Truck No :";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(571, 115);
            this.txtTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(264, 27);
            this.txtTime.TabIndex = 2;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(464, 125);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(56, 20);
            this.lblTime.TabIndex = 15;
            this.lblTime.Text = "Time :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(41, 125);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(55, 20);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "Date :";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(894, 191);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(92, 20);
            this.lblCustomer.TabIndex = 16;
            this.lblCustomer.Text = "Customer :";
            // 
            // lblTrailer
            // 
            this.lblTrailer.AutoSize = true;
            this.lblTrailer.Location = new System.Drawing.Point(460, 191);
            this.lblTrailer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrailer.Name = "lblTrailer";
            this.lblTrailer.Size = new System.Drawing.Size(93, 20);
            this.lblTrailer.TabIndex = 34;
            this.lblTrailer.Text = "Trailer No :";
            // 
            // sfCbxCategory
            // 
            this.sfCbxCategory.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxCategory.Location = new System.Drawing.Point(154, 260);
            this.sfCbxCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfCbxCategory.Name = "sfCbxCategory";
            this.sfCbxCategory.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.sfCbxCategory.Size = new System.Drawing.Size(265, 28);
            this.sfCbxCategory.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxCategory.TabIndex = 7;
            this.sfCbxCategory.TabStop = false;
            // 
            // lblTransporter
            // 
            this.lblTransporter.AutoSize = true;
            this.lblTransporter.Location = new System.Drawing.Point(40, 488);
            this.lblTransporter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransporter.Name = "lblTransporter";
            this.lblTransporter.Size = new System.Drawing.Size(106, 20);
            this.lblTransporter.TabIndex = 28;
            this.lblTransporter.Text = "Transporter :";
            // 
            // sfCbxTransporter
            // 
            this.sfCbxTransporter.DisplayMember = "Name";
            this.sfCbxTransporter.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxTransporter.Location = new System.Drawing.Point(152, 480);
            this.sfCbxTransporter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfCbxTransporter.Name = "sfCbxTransporter";
            this.sfCbxTransporter.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.sfCbxTransporter.Size = new System.Drawing.Size(265, 28);
            this.sfCbxTransporter.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxTransporter.TabIndex = 16;
            this.sfCbxTransporter.TabStop = false;
            this.sfCbxTransporter.ValueMember = "TransporterID";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(1005, 184);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(264, 27);
            this.txtCustomer.TabIndex = 6;
            // 
            // lblWOption
            // 
            this.lblWOption.AutoSize = true;
            this.lblWOption.Location = new System.Drawing.Point(460, 268);
            this.lblWOption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWOption.Name = "lblWOption";
            this.lblWOption.Size = new System.Drawing.Size(79, 20);
            this.lblWOption.TabIndex = 16;
            this.lblWOption.Text = "WOption:";
            // 
            // lblWType
            // 
            this.lblWType.AutoSize = true;
            this.lblWType.Location = new System.Drawing.Point(894, 268);
            this.lblWType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWType.Name = "lblWType";
            this.lblWType.Size = new System.Drawing.Size(71, 20);
            this.lblWType.TabIndex = 28;
            this.lblWType.Text = "WType :";
            // 
            // sfCbxWOption
            // 
            this.sfCbxWOption.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxWOption.Location = new System.Drawing.Point(571, 260);
            this.sfCbxWOption.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfCbxWOption.Name = "sfCbxWOption";
            this.sfCbxWOption.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.sfCbxWOption.Size = new System.Drawing.Size(265, 28);
            this.sfCbxWOption.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxWOption.TabIndex = 8;
            this.sfCbxWOption.TabStop = false;
            // 
            // sfCbxWType
            // 
            this.sfCbxWType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxWType.Location = new System.Drawing.Point(1005, 260);
            this.sfCbxWType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfCbxWType.Name = "sfCbxWType";
            this.sfCbxWType.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.sfCbxWType.Size = new System.Drawing.Size(265, 28);
            this.sfCbxWType.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxWType.TabIndex = 9;
            this.sfCbxWType.TabStop = false;
            // 
            // lblDoNo
            // 
            this.lblDoNo.AutoSize = true;
            this.lblDoNo.Location = new System.Drawing.Point(899, 414);
            this.lblDoNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoNo.Name = "lblDoNo";
            this.lblDoNo.Size = new System.Drawing.Size(66, 20);
            this.lblDoNo.TabIndex = 28;
            this.lblDoNo.Text = "DO No:";
            // 
            // txtDoNo
            // 
            this.txtDoNo.Location = new System.Drawing.Point(1005, 410);
            this.txtDoNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDoNo.Name = "txtDoNo";
            this.txtDoNo.Size = new System.Drawing.Size(264, 27);
            this.txtDoNo.TabIndex = 15;
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(40, 414);
            this.lblDriver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(109, 20);
            this.lblDriver.TabIndex = 16;
            this.lblDriver.Text = "Driver Name:";
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(152, 406);
            this.txtDriver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(264, 27);
            this.txtDriver.TabIndex = 13;
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(461, 414);
            this.lblLicense.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(91, 20);
            this.lblLicense.TabIndex = 28;
            this.lblLicense.Text = "DLicense :";
            // 
            // txtDLicense
            // 
            this.txtDLicense.Location = new System.Drawing.Point(572, 406);
            this.txtDLicense.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDLicense.Name = "txtDLicense";
            this.txtDLicense.Size = new System.Drawing.Size(264, 27);
            this.txtDLicense.TabIndex = 14;
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Location = new System.Drawing.Point(464, 341);
            this.lblCash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(88, 20);
            this.lblCash.TabIndex = 16;
            this.lblCash.Text = "Cash Amt:";
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(571, 480);
            this.txtContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(264, 27);
            this.txtContainer.TabIndex = 17;
            // 
            // txtBlNo
            // 
            this.txtBlNo.Location = new System.Drawing.Point(1005, 480);
            this.txtBlNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBlNo.Name = "txtBlNo";
            this.txtBlNo.Size = new System.Drawing.Size(264, 27);
            this.txtBlNo.TabIndex = 18;
            // 
            // txtVessel
            // 
            this.txtVessel.Location = new System.Drawing.Point(154, 554);
            this.txtVessel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVessel.Name = "txtVessel";
            this.txtVessel.Size = new System.Drawing.Size(264, 27);
            this.txtVessel.TabIndex = 19;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(899, 561);
            this.lblRemark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(77, 20);
            this.lblRemark.TabIndex = 31;
            this.lblRemark.Text = "Remark :";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(1005, 550);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(264, 26);
            this.txtRemark.TabIndex = 21;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(262, 30);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(106, 20);
            this.lblWeight.TabIndex = 32;
            this.lblWeight.Text = "Weighing In :";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.sfNtxtWeight);
            this.panel1.Controls.Add(this.lblWeight);
            this.panel1.Controls.Add(this.btnGet);
            this.panel1.Location = new System.Drawing.Point(44, 621);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1222, 82);
            this.panel1.TabIndex = 45;
            // 
            // sfNtxtWeight
            // 
            this.sfNtxtWeight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sfNtxtWeight.Location = new System.Drawing.Point(415, 21);
            this.sfNtxtWeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfNtxtWeight.Name = "sfNtxtWeight";
            this.sfNtxtWeight.Size = new System.Drawing.Size(375, 27);
            this.sfNtxtWeight.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sfNtxtWeight.TabIndex = 22;
            // 
            // btnGet
            // 
            this.btnGet.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGet.Location = new System.Drawing.Point(839, 16);
            this.btnGet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(94, 36);
            this.btnGet.TabIndex = 23;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            // 
            // sfNtxtCash
            // 
            this.sfNtxtCash.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sfNtxtCash.Location = new System.Drawing.Point(571, 334);
            this.sfNtxtCash.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfNtxtCash.Name = "sfNtxtCash";
            this.sfNtxtCash.Size = new System.Drawing.Size(264, 27);
            this.sfNtxtCash.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sfNtxtCash.TabIndex = 11;
            // 
            // lblVesselInfo
            // 
            this.lblVesselInfo.AutoSize = true;
            this.lblVesselInfo.Location = new System.Drawing.Point(456, 558);
            this.lblVesselInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVesselInfo.Name = "lblVesselInfo";
            this.lblVesselInfo.Size = new System.Drawing.Size(91, 20);
            this.lblVesselInfo.TabIndex = 31;
            this.lblVesselInfo.Text = "Cargo Info:";
            // 
            // txtCargoInfo
            // 
            this.txtCargoInfo.Location = new System.Drawing.Point(572, 554);
            this.txtCargoInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCargoInfo.Multiline = true;
            this.txtCargoInfo.Name = "txtCargoInfo";
            this.txtCargoInfo.Size = new System.Drawing.Size(264, 26);
            this.txtCargoInfo.TabIndex = 20;
            // 
            // lblwbId
            // 
            this.lblwbId.AutoSize = true;
            this.lblwbId.Location = new System.Drawing.Point(894, 341);
            this.lblwbId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblwbId.Name = "lblwbId";
            this.lblwbId.Size = new System.Drawing.Size(65, 20);
            this.lblwbId.TabIndex = 33;
            this.lblwbId.Text = "WB Id :";
            // 
            // sfCbxWBId
            // 
            this.sfCbxWBId.DisplayMember = "Name";
            this.sfCbxWBId.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxWBId.Location = new System.Drawing.Point(1005, 334);
            this.sfCbxWBId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfCbxWBId.Name = "sfCbxWBId";
            this.sfCbxWBId.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.sfCbxWBId.Size = new System.Drawing.Size(265, 28);
            this.sfCbxWBId.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxWBId.TabIndex = 12;
            this.sfCbxWBId.TabStop = false;
            this.sfCbxWBId.ValueMember = "WeghtBridgeID";
            // 
            // sfCbxTruck
            // 
            this.sfCbxTruck.DisplayMember = "VehicleRegNo";
            this.sfCbxTruck.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxTruck.Location = new System.Drawing.Point(154, 188);
            this.sfCbxTruck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfCbxTruck.Name = "sfCbxTruck";
            this.sfCbxTruck.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.sfCbxTruck.Size = new System.Drawing.Size(265, 28);
            this.sfCbxTruck.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxTruck.TabIndex = 4;
            this.sfCbxTruck.TabStop = false;
            this.sfCbxTruck.ValueMember = "VehicleRegNo";
            // 
            // sfCbxTrailer
            // 
            this.sfCbxTrailer.DisplayMember = "VehicleRegNo";
            this.sfCbxTrailer.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxTrailer.Location = new System.Drawing.Point(571, 184);
            this.sfCbxTrailer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfCbxTrailer.Name = "sfCbxTrailer";
            this.sfCbxTrailer.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.sfCbxTrailer.Size = new System.Drawing.Size(265, 28);
            this.sfCbxTrailer.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxTrailer.TabIndex = 5;
            this.sfCbxTrailer.TabStop = false;
            this.sfCbxTrailer.ValueMember = "VehicleRegNo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(894, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Yard:";
            // 
            // sfCbxGate
            // 
            this.sfCbxGate.DisplayMember = "GateInfo";
            this.sfCbxGate.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxGate.Location = new System.Drawing.Point(1005, 118);
            this.sfCbxGate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfCbxGate.Name = "sfCbxGate";
            this.sfCbxGate.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.sfCbxGate.Size = new System.Drawing.Size(265, 28);
            this.sfCbxGate.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxGate.TabIndex = 3;
            this.sfCbxGate.TabStop = false;
            this.sfCbxGate.ValueMember = "GateID";
            // 
            // lblBillOption
            // 
            this.lblBillOption.AutoSize = true;
            this.lblBillOption.Location = new System.Drawing.Point(40, 341);
            this.lblBillOption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillOption.Name = "lblBillOption";
            this.lblBillOption.Size = new System.Drawing.Size(97, 20);
            this.lblBillOption.TabIndex = 28;
            this.lblBillOption.Text = "Bill Option :";
            // 
            // sfCbxBillOption
            // 
            this.sfCbxBillOption.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfCbxBillOption.Location = new System.Drawing.Point(152, 334);
            this.sfCbxBillOption.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfCbxBillOption.Name = "sfCbxBillOption";
            this.sfCbxBillOption.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.sfCbxBillOption.Size = new System.Drawing.Size(265, 28);
            this.sfCbxBillOption.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfCbxBillOption.TabIndex = 10;
            this.sfCbxBillOption.TabStop = false;
            // 
            // FrmAdHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1321, 935);
            this.Controls.Add(this.sfNtxtCash);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sfCbxGate);
            this.Controls.Add(this.sfCbxWBId);
            this.Controls.Add(this.sfCbxTrailer);
            this.Controls.Add(this.sfCbxTruck);
            this.Controls.Add(this.sfCbxTransporter);
            this.Controls.Add(this.sfCbxWType);
            this.Controls.Add(this.sfCbxWOption);
            this.Controls.Add(this.sfCbxBillOption);
            this.Controls.Add(this.sfCbxCategory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.sfDate);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblwbId);
            this.Controls.Add(this.lblVessel);
            this.Controls.Add(this.lblBlno);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblVesselInfo);
            this.Controls.Add(this.lblContainer);
            this.Controls.Add(this.lblDoNo);
            this.Controls.Add(this.lblTransporter);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblBillOption);
            this.Controls.Add(this.lblWType);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblTrailer);
            this.Controls.Add(this.lblTruck);
            this.Controls.Add(this.txtVessel);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmAdHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm AdHoc";
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTransporter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWType)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxWBId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTruck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxTrailer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxGate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfCbxBillOption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



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

            this.sfCbxGate.DataSource = null;
            gateList = await _apiService.GetGateList();
            if (gateList.Count > 0)
                this.sfCbxGate.DataSource = gateList;


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
            serviceBill.VesselName = this.txtVessel.Text;
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

            if (this.sfCbxGate.SelectedItem is Gate gate)
            {
                serviceBill.GateID = gate.GateID;
                serviceBill.YardID = gate.YardID;
            }
                
                

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

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        public Syncfusion.WinForms.Input.SfDateTimeEdit sfDate;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label lblheader;
        private System.Windows.Forms.Label lblVessel;
        private System.Windows.Forms.Label lblBlno;
        private System.Windows.Forms.Label lblContainer;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblTruck;
        public System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblTrailer;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxCategory;
        private System.Windows.Forms.Label lblTransporter;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxTransporter;
        public System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblWOption;
        private System.Windows.Forms.Label lblWType;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxWOption;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxWType;
        private System.Windows.Forms.Label lblDoNo;
        public System.Windows.Forms.TextBox txtDoNo;
        private System.Windows.Forms.Label lblDriver;
        public System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label lblLicense;
        public System.Windows.Forms.TextBox txtDLicense;
        private System.Windows.Forms.Label lblCash;
        public System.Windows.Forms.TextBox txtContainer;
        public System.Windows.Forms.TextBox txtBlNo;
        public System.Windows.Forms.TextBox txtVessel;
        private System.Windows.Forms.Label lblRemark;
        public System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGet;
        public Syncfusion.WinForms.Input.SfNumericTextBox sfNtxtCash;
        public Syncfusion.WinForms.Input.SfNumericTextBox sfNtxtWeight;
        private Label lblVesselInfo;
        public TextBox txtCargoInfo;
        private Label lblwbId;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxWBId;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxTruck;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxTrailer;
        private Label label1;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxGate;
        private Label lblBillOption;
        public Syncfusion.WinForms.ListView.SfComboBox sfCbxBillOption;
    }
}