using System.Threading.Tasks;
using System;
using TMS_Weight.Models;
using TMS_Weight.Services;
using Syncfusion.Windows.Forms;
using System.Windows.Forms;

namespace TMS_Weight.Forms
{
    partial class FrmOutQueue
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
        private async Task<ResponseMessage> SaveServiceBillForOutQueue()
        {
            ResponseMessage msg = new ResponseMessage();

            WeightServiceBill serviceBill = new WeightServiceBill();

            serviceBill.ServiceBillNo = "";
            serviceBill.QRegNo = this.QRegNo;
            serviceBill.GateID = this.gateId;
            serviceBill.CheckInRegNo = Convert.ToInt32(this.txtInRegNo.Text);
            serviceBill.CustomerId = this.txtCustomer.Text;
            serviceBill.CustomerName = this.txtCustomer.Text;
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
            serviceBill.WeightCategory = this.txtCategory.Text;
            serviceBill.YardID = this.txtYard.Text;

            // Extract the numeric value using regex
            string wvalue = System.Text.RegularExpressions.Regex.Match(this.txtWeight.Text, @"\d+").Value;

            // Convert the extracted number string to an integer
            int value = int.Parse(wvalue);

            DateTime d = DateTime.Now;
            string timeString = new TimeSpan(d.Hour, d.Minute, d.Second).ToString();
            TimeSpan time = TimeSpan.Parse(timeString);// Time part 
 
            DateTime date = (DateTime)this.sfDate.Value; // Date part
            //string timeString = this.txtTime.Text.ToString();
            //TimeSpan time = TimeSpan.Parse(timeString);// Time part 
            serviceBill.OutWeightTime = (date + time);
            serviceBill.ServiceBillDate = serviceBill.OutWeightTime;
            serviceBill.OutWeight = Convert.ToDecimal(value);
            serviceBill.UpdatedUser = CommonData.userName;

            msg = await _apiService.UpdateServiceBillForOutQueue(serviceBill);
            if(msg.Status)
            {
                this.Close();
                FrmServiceBillPrint f = new FrmServiceBillPrint(msg.ServiceBillNo.ToString());
                f.Show();
            }
            else
            {
                MessageBoxAdv.Show(this, msg.MessageContent, "Weight Out Queue", MessageBoxButtons.OK, MessageBoxIcon.Error);              
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOutQueue));
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSave = new Syncfusion.WinForms.Controls.SfButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetWeight = new Syncfusion.WinForms.Controls.SfButton();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblheader = new System.Windows.Forms.Label();
            this.lblwbId = new System.Windows.Forms.Label();
            this.lblBlno = new System.Windows.Forms.Label();
            this.lblVesselInfo = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblContainer = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblTrailer = new System.Windows.Forms.Label();
            this.lblQRegNo = new System.Windows.Forms.Label();
            this.lblTruck = new System.Windows.Forms.Label();
            this.sfDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDoNo = new System.Windows.Forms.Label();
            this.lblBillOption = new System.Windows.Forms.Label();
            this.lblWType = new System.Windows.Forms.Label();
            this.txtbilloption = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtTrailer = new System.Windows.Forms.TextBox();
            this.txtWType = new System.Windows.Forms.TextBox();
            this.txtWbId = new System.Windows.Forms.TextBox();
            this.txtTruck = new System.Windows.Forms.TextBox();
            this.txtYard = new System.Windows.Forms.TextBox();
            this.txtInRegNo = new System.Windows.Forms.TextBox();
            this.txtInCash = new System.Windows.Forms.TextBox();
            this.txtDoNo = new System.Windows.Forms.TextBox();
            this.txtDLicense = new System.Windows.Forms.TextBox();
            this.txtBlNo = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtCargoInfo = new System.Windows.Forms.TextBox();
            this.txtContainer = new System.Windows.Forms.TextBox();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.txtwbOption = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblDriver = new System.Windows.Forms.Label();
            this.lblWOption = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageSize = new System.Drawing.Size(24, 24);
            this.btnCancel.Location = new System.Drawing.Point(682, 744);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 45);
            this.btnCancel.Style.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.Style.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnCancel.TabIndex = 112;
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
            this.btnSave.Location = new System.Drawing.Point(519, 744);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 45);
            this.btnSave.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSave.Style.ForeColor = System.Drawing.Color.White;
            this.btnSave.Style.Image = global::TMS_Weight.Properties.Resources.disk_blue1;
            this.btnSave.TabIndex = 111;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnGetWeight);
            this.panel1.Controls.Add(this.txtWeight);
            this.panel1.Controls.Add(this.lblWeight);
            this.panel1.Location = new System.Drawing.Point(16, 632);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1305, 81);
            this.panel1.TabIndex = 133;
            // 
            // btnGetWeight
            // 
            this.btnGetWeight.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnGetWeight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetWeight.ForeColor = System.Drawing.Color.White;
            this.btnGetWeight.ImageSize = new System.Drawing.Size(24, 24);
            this.btnGetWeight.Location = new System.Drawing.Point(831, 21);
            this.btnGetWeight.Name = "btnGetWeight";
            this.btnGetWeight.Size = new System.Drawing.Size(110, 34);
            this.btnGetWeight.Style.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnGetWeight.Style.ForeColor = System.Drawing.Color.White;
            this.btnGetWeight.Style.Image = global::TMS_Weight.Properties.Resources.window_edit;
            this.btnGetWeight.TabIndex = 21;
            this.btnGetWeight.Text = "&Get";
            this.btnGetWeight.UseVisualStyleBackColor = false;
            this.btnGetWeight.Click += new System.EventHandler(this.btnGetWeight_Click);
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtWeight.Location = new System.Drawing.Point(493, 27);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtWeight.Multiline = true;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(295, 28);
            this.txtWeight.TabIndex = 20;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(342, 27);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(143, 25);
            this.lblWeight.TabIndex = 83;
            this.lblWeight.Text = "Weighing Out :";
            // 
            // lblheader
            // 
            this.lblheader.AutoSize = true;
            this.lblheader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheader.Location = new System.Drawing.Point(565, 18);
            this.lblheader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblheader.Name = "lblheader";
            this.lblheader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblheader.Size = new System.Drawing.Size(170, 32);
            this.lblheader.TabIndex = 1;
            this.lblheader.Text = "Weight Data";
            this.lblheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblwbId
            // 
            this.lblwbId.AutoSize = true;
            this.lblwbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwbId.Location = new System.Drawing.Point(14, 261);
            this.lblwbId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblwbId.Name = "lblwbId";
            this.lblwbId.Size = new System.Drawing.Size(77, 25);
            this.lblwbId.TabIndex = 128;
            this.lblwbId.Text = "WB Id :";
            // 
            // lblBlno
            // 
            this.lblBlno.AutoSize = true;
            this.lblBlno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlno.Location = new System.Drawing.Point(454, 490);
            this.lblBlno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlno.Name = "lblBlno";
            this.lblBlno.Size = new System.Drawing.Size(83, 25);
            this.lblBlno.TabIndex = 126;
            this.lblBlno.Text = "B/L No :";
            // 
            // lblVesselInfo
            // 
            this.lblVesselInfo.AutoSize = true;
            this.lblVesselInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVesselInfo.Location = new System.Drawing.Point(909, 492);
            this.lblVesselInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVesselInfo.Name = "lblVesselInfo";
            this.lblVesselInfo.Size = new System.Drawing.Size(109, 25);
            this.lblVesselInfo.TabIndex = 125;
            this.lblVesselInfo.Text = "Cargo Info:";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(7, 565);
            this.lblRemark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(90, 25);
            this.lblRemark.TabIndex = 124;
            this.lblRemark.Text = "Remark :";
            // 
            // lblContainer
            // 
            this.lblContainer.AutoSize = true;
            this.lblContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContainer.Location = new System.Drawing.Point(14, 488);
            this.lblContainer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContainer.Name = "lblContainer";
            this.lblContainer.Size = new System.Drawing.Size(108, 25);
            this.lblContainer.TabIndex = 123;
            this.lblContainer.Text = "Container :";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicense.Location = new System.Drawing.Point(453, 413);
            this.lblLicense.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(105, 25);
            this.lblLicense.TabIndex = 120;
            this.lblLicense.Text = "DLicense :";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(453, 268);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(103, 25);
            this.lblCategory.TabIndex = 113;
            this.lblCategory.Text = "Category :";
            // 
            // lblTrailer
            // 
            this.lblTrailer.AutoSize = true;
            this.lblTrailer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrailer.Location = new System.Drawing.Point(453, 190);
            this.lblTrailer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrailer.Name = "lblTrailer";
            this.lblTrailer.Size = new System.Drawing.Size(108, 25);
            this.lblTrailer.TabIndex = 129;
            this.lblTrailer.Text = "Trailer No :";
            // 
            // lblQRegNo
            // 
            this.lblQRegNo.AutoSize = true;
            this.lblQRegNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQRegNo.Location = new System.Drawing.Point(11, 123);
            this.lblQRegNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQRegNo.Name = "lblQRegNo";
            this.lblQRegNo.Size = new System.Drawing.Size(104, 25);
            this.lblQRegNo.TabIndex = 130;
            this.lblQRegNo.Text = "InReg No :";
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTruck.Location = new System.Drawing.Point(12, 190);
            this.lblTruck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(103, 25);
            this.lblTruck.TabIndex = 131;
            this.lblTruck.Text = "Truck No :";
            // 
            // sfDate
            // 
            this.sfDate.DateTimeIcon = null;
            this.sfDate.Location = new System.Drawing.Point(593, 119);
            this.sfDate.Margin = new System.Windows.Forms.Padding(4);
            this.sfDate.MinDateTime = new System.DateTime(2025, 1, 14, 16, 28, 26, 0);
            this.sfDate.Name = "sfDate";
            this.sfDate.Size = new System.Drawing.Size(288, 26);
            this.sfDate.TabIndex = 93;
            this.sfDate.ToolTipText = "";
            this.sfDate.Value = new System.DateTime(2025, 1, 14, 16, 28, 26, 0);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnHeader.Controls.Add(this.lblheader);
            this.pnHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnHeader.Location = new System.Drawing.Point(-2, -1);
            this.pnHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1346, 66);
            this.pnHeader.TabIndex = 132;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(909, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 127;
            this.label1.Text = "Yard:";
            // 
            // lblDoNo
            // 
            this.lblDoNo.AutoSize = true;
            this.lblDoNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoNo.Location = new System.Drawing.Point(908, 415);
            this.lblDoNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoNo.Name = "lblDoNo";
            this.lblDoNo.Size = new System.Drawing.Size(78, 25);
            this.lblDoNo.TabIndex = 121;
            this.lblDoNo.Text = "DO No:";
            // 
            // lblBillOption
            // 
            this.lblBillOption.AutoSize = true;
            this.lblBillOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillOption.Location = new System.Drawing.Point(454, 343);
            this.lblBillOption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillOption.Name = "lblBillOption";
            this.lblBillOption.Size = new System.Drawing.Size(111, 25);
            this.lblBillOption.TabIndex = 122;
            this.lblBillOption.Text = "Bill Option :";
            // 
            // lblWType
            // 
            this.lblWType.AutoSize = true;
            this.lblWType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWType.Location = new System.Drawing.Point(14, 335);
            this.lblWType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWType.Name = "lblWType";
            this.lblWType.Size = new System.Drawing.Size(88, 25);
            this.lblWType.TabIndex = 119;
            this.lblWType.Text = "WType :";
            // 
            // txtbilloption
            // 
            this.txtbilloption.BackColor = System.Drawing.SystemColors.Control;
            this.txtbilloption.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.txtbilloption.Enabled = false;
            this.txtbilloption.Location = new System.Drawing.Point(596, 345);
            this.txtbilloption.Margin = new System.Windows.Forms.Padding(4);
            this.txtbilloption.Name = "txtbilloption";
            this.txtbilloption.Size = new System.Drawing.Size(284, 24);
            this.txtbilloption.TabIndex = 102;
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.SystemColors.Control;
            this.txtCategory.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.txtCategory.Enabled = false;
            this.txtCategory.Location = new System.Drawing.Point(593, 268);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(288, 24);
            this.txtCategory.TabIndex = 99;
            // 
            // txtTrailer
            // 
            this.txtTrailer.BackColor = System.Drawing.SystemColors.Control;
            this.txtTrailer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.txtTrailer.Enabled = false;
            this.txtTrailer.Location = new System.Drawing.Point(593, 192);
            this.txtTrailer.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrailer.Name = "txtTrailer";
            this.txtTrailer.Size = new System.Drawing.Size(288, 24);
            this.txtTrailer.TabIndex = 96;
            // 
            // txtWType
            // 
            this.txtWType.BackColor = System.Drawing.SystemColors.Control;
            this.txtWType.Enabled = false;
            this.txtWType.Location = new System.Drawing.Point(138, 345);
            this.txtWType.Margin = new System.Windows.Forms.Padding(4);
            this.txtWType.Name = "txtWType";
            this.txtWType.Size = new System.Drawing.Size(288, 24);
            this.txtWType.TabIndex = 101;
            // 
            // txtWbId
            // 
            this.txtWbId.BackColor = System.Drawing.SystemColors.Control;
            this.txtWbId.Enabled = false;
            this.txtWbId.Location = new System.Drawing.Point(144, 268);
            this.txtWbId.Margin = new System.Windows.Forms.Padding(4);
            this.txtWbId.Name = "txtWbId";
            this.txtWbId.Size = new System.Drawing.Size(284, 24);
            this.txtWbId.TabIndex = 98;
            // 
            // txtTruck
            // 
            this.txtTruck.BackColor = System.Drawing.SystemColors.Control;
            this.txtTruck.Enabled = false;
            this.txtTruck.Location = new System.Drawing.Point(143, 190);
            this.txtTruck.Margin = new System.Windows.Forms.Padding(4);
            this.txtTruck.Name = "txtTruck";
            this.txtTruck.Size = new System.Drawing.Size(285, 24);
            this.txtTruck.TabIndex = 95;
            // 
            // txtYard
            // 
            this.txtYard.BackColor = System.Drawing.SystemColors.Control;
            this.txtYard.Enabled = false;
            this.txtYard.Location = new System.Drawing.Point(1030, 123);
            this.txtYard.Margin = new System.Windows.Forms.Padding(4);
            this.txtYard.Name = "txtYard";
            this.txtYard.Size = new System.Drawing.Size(288, 24);
            this.txtYard.TabIndex = 94;
            // 
            // txtInRegNo
            // 
            this.txtInRegNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtInRegNo.Enabled = false;
            this.txtInRegNo.Location = new System.Drawing.Point(141, 119);
            this.txtInRegNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInRegNo.Name = "txtInRegNo";
            this.txtInRegNo.Size = new System.Drawing.Size(288, 24);
            this.txtInRegNo.TabIndex = 92;
            // 
            // txtInCash
            // 
            this.txtInCash.Location = new System.Drawing.Point(1030, 345);
            this.txtInCash.Margin = new System.Windows.Forms.Padding(4);
            this.txtInCash.Name = "txtInCash";
            this.txtInCash.Size = new System.Drawing.Size(290, 24);
            this.txtInCash.TabIndex = 103;
            // 
            // txtDoNo
            // 
            this.txtDoNo.Location = new System.Drawing.Point(1030, 417);
            this.txtDoNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoNo.Name = "txtDoNo";
            this.txtDoNo.Size = new System.Drawing.Size(290, 24);
            this.txtDoNo.TabIndex = 106;
            // 
            // txtDLicense
            // 
            this.txtDLicense.Location = new System.Drawing.Point(596, 415);
            this.txtDLicense.Margin = new System.Windows.Forms.Padding(4);
            this.txtDLicense.Name = "txtDLicense";
            this.txtDLicense.ReadOnly = true;
            this.txtDLicense.Size = new System.Drawing.Size(284, 24);
            this.txtDLicense.TabIndex = 105;
            // 
            // txtBlNo
            // 
            this.txtBlNo.Location = new System.Drawing.Point(596, 493);
            this.txtBlNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBlNo.Name = "txtBlNo";
            this.txtBlNo.Size = new System.Drawing.Size(284, 24);
            this.txtBlNo.TabIndex = 108;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(138, 567);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(290, 26);
            this.txtRemark.TabIndex = 110;
            // 
            // txtCargoInfo
            // 
            this.txtCargoInfo.Location = new System.Drawing.Point(1033, 494);
            this.txtCargoInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCargoInfo.Multiline = true;
            this.txtCargoInfo.Name = "txtCargoInfo";
            this.txtCargoInfo.Size = new System.Drawing.Size(288, 26);
            this.txtCargoInfo.TabIndex = 109;
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(138, 490);
            this.txtContainer.Margin = new System.Windows.Forms.Padding(4);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(290, 24);
            this.txtContainer.TabIndex = 107;
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(138, 415);
            this.txtDriver.Margin = new System.Windows.Forms.Padding(4);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.ReadOnly = true;
            this.txtDriver.Size = new System.Drawing.Size(290, 24);
            this.txtDriver.TabIndex = 104;
            // 
            // txtwbOption
            // 
            this.txtwbOption.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtwbOption.Enabled = false;
            this.txtwbOption.Location = new System.Drawing.Point(1030, 270);
            this.txtwbOption.Margin = new System.Windows.Forms.Padding(4);
            this.txtwbOption.Name = "txtwbOption";
            this.txtwbOption.ReadOnly = true;
            this.txtwbOption.Size = new System.Drawing.Size(288, 24);
            this.txtwbOption.TabIndex = 100;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(453, 119);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 25);
            this.lblDate.TabIndex = 114;
            this.lblDate.Text = "Date :";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.Location = new System.Drawing.Point(908, 345);
            this.lblCash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(105, 25);
            this.lblCash.TabIndex = 115;
            this.lblCash.Text = "Cash Amt:";
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriver.Location = new System.Drawing.Point(11, 407);
            this.lblDriver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(121, 25);
            this.lblDriver.TabIndex = 116;
            this.lblDriver.Text = "DriverName:";
            // 
            // lblWOption
            // 
            this.lblWOption.AutoSize = true;
            this.lblWOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWOption.Location = new System.Drawing.Point(909, 268);
            this.lblWOption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWOption.Name = "lblWOption";
            this.lblWOption.Size = new System.Drawing.Size(96, 25);
            this.lblWOption.TabIndex = 117;
            this.lblWOption.Text = "WOption:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(1030, 195);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(288, 24);
            this.txtCustomer.TabIndex = 97;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(909, 192);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(108, 25);
            this.lblCustomer.TabIndex = 118;
            this.lblCustomer.Text = "Customer :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 565);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 25);
            this.label2.TabIndex = 124;
            this.label2.Text = "Remark :";
            // 
            // FrmOutQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 830);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblwbId);
            this.Controls.Add(this.lblBlno);
            this.Controls.Add(this.lblVesselInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRemark);
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
            this.Controls.Add(this.txtInCash);
            this.Controls.Add(this.txtDoNo);
            this.Controls.Add(this.txtDLicense);
            this.Controls.Add(this.txtBlNo);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtCargoInfo);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.txtwbOption);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.lblDriver);
            this.Controls.Add(this.lblWOption);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmOutQueue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Weight Out  Queue";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton btnCancel;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.WinForms.Controls.SfButton btnGetWeight;
        public System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblheader;
        private System.Windows.Forms.Label lblwbId;
        private System.Windows.Forms.Label lblBlno;
        private System.Windows.Forms.Label lblVesselInfo;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblContainer;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblTrailer;
        private System.Windows.Forms.Label lblQRegNo;
        private System.Windows.Forms.Label lblTruck;
        public Syncfusion.WinForms.Input.SfDateTimeEdit sfDate;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDoNo;
        private System.Windows.Forms.Label lblBillOption;
        private System.Windows.Forms.Label lblWType;
        public System.Windows.Forms.TextBox txtbilloption;
        public System.Windows.Forms.TextBox txtCategory;
        public System.Windows.Forms.TextBox txtTrailer;
        public System.Windows.Forms.TextBox txtWType;
        public System.Windows.Forms.TextBox txtWbId;
        public System.Windows.Forms.TextBox txtTruck;
        public System.Windows.Forms.TextBox txtYard;
        public System.Windows.Forms.TextBox txtInRegNo;
        public System.Windows.Forms.TextBox txtInCash;
        public System.Windows.Forms.TextBox txtDoNo;
        public System.Windows.Forms.TextBox txtDLicense;
        public System.Windows.Forms.TextBox txtBlNo;
        public System.Windows.Forms.TextBox txtRemark;
        public System.Windows.Forms.TextBox txtCargoInfo;
        public System.Windows.Forms.TextBox txtContainer;
        public System.Windows.Forms.TextBox txtDriver;
        public System.Windows.Forms.TextBox txtwbOption;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.Label lblWOption;
        public System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private Label label2;
    }
}