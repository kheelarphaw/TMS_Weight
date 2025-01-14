using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Weight.Models;
using TMS_Weight.Services;

namespace TMS_Weight.Forms
{
    
    public partial class FrmServiceBillPrint : Form
    {
        public string yard = "";
        public string address = "";
        public string phoneNo = "";
        public string email = "";
        public string serviceBillNo = "";
        private WeightApiService _apiService= new WeightApiService();

        public FrmServiceBillPrint(string billNo)
        {
            InitializeComponent();

           
            this.serviceBillNo = billNo;
            // Retrieve the YardCode setting from Properties
            this.yard = Properties.Settings.Default.YardCode;
            this.address = Properties.Settings.Default.Address;
            this.phoneNo = Properties.Settings.Default.PhoneNo;
            this.email= Properties.Settings.Default.Email;

            this.reportViewer1.Dock = DockStyle.Fill;
        }

        private async void FrmServiceBillPrint_Load(object sender, EventArgs e)
        {
            WeightServiceBill bill = new WeightServiceBill();
            
            bill = await _apiService.GetServiceBillPrintData(this.serviceBillNo);

            ReportParameter[] parameters = new ReportParameter[21];
            parameters[0] = new ReportParameter("Address", this.address);
            parameters[1] = new ReportParameter("Phone", this.phoneNo);
            parameters[2] = new ReportParameter("Email", this.email);
            parameters[3] = new ReportParameter("CustomerName", !string.IsNullOrEmpty(bill.CustomerName.ToString()) ? bill.CustomerName.ToString() : " ");
            parameters[4] = new ReportParameter("CustomerAddress", !string.IsNullOrEmpty(bill.CustomerAddress.ToString()) ? bill.CustomerAddress.ToString() : " ");
            parameters[5] = new ReportParameter("CustomerPhone", !string.IsNullOrEmpty(bill.CustomerPhone.ToString()) ? bill.CustomerPhone.ToString() : " ");
            parameters[6] = new ReportParameter("Truck", !string.IsNullOrEmpty(bill.TruckNo.ToString()) ? bill.TruckNo.ToString() : " ");
            parameters[7] = new ReportParameter("Trailer", !string.IsNullOrEmpty(bill.TrailerNo.ToString()) ? bill.TrailerNo.ToString() : " ");

            parameters[8] = new ReportParameter("QueueNo", !string.IsNullOrEmpty(bill.QRegNo.ToString()) ? bill.QRegNo.ToString() : " ");
            parameters[9] = new ReportParameter("Category", !string.IsNullOrEmpty(bill.WeightCategory.ToString()) ? bill.WeightCategory.ToString() : " ");
            parameters[10] = new ReportParameter("InWeight", !string.IsNullOrEmpty(bill.InWeight.ToString()) ? bill.InWeight.ToString() : " ");
            parameters[11] = new ReportParameter("OutWeight", bill.OutWeight.ToString());
            parameters[12] = new ReportParameter("NetWeight", bill.NetWeight.ToString());
            parameters[13] = new ReportParameter("CargoInfo", !string.IsNullOrEmpty(bill.CargoInfo.ToString()) ? bill.CargoInfo.ToString() : " ");
            parameters[14] = new ReportParameter("DoNo", !string.IsNullOrWhiteSpace(bill.DONo.ToString()) ? bill.DONo.ToString() : " ");

            parameters[15] = new ReportParameter("Remark", !string.IsNullOrEmpty(bill.Remark.ToString()) ? bill.Remark.ToString() : " ");
            parameters[16] = new ReportParameter("ContainerNo", !string.IsNullOrEmpty(bill.ContainerNo.ToString()) ? bill.ContainerNo.ToString() : " ");
            parameters[17] = new ReportParameter("BlNo", !string.IsNullOrEmpty(bill.BLNo.ToString()) ? bill.BLNo.ToString() : " ");

            parameters[18] = new ReportParameter("InWeightTime", !string.IsNullOrEmpty(bill.InWeightTime.ToString()) ? (string.Format("{0:dd-MM-yyyy hh:mm}", bill.InWeightTime.ToString())) : " ");
            parameters[19] = new ReportParameter("OutWeightTime", !string.IsNullOrEmpty(bill.OutWeightTime.ToString()) ? string.Format("{0:dd-MM-yyyy hh:mm}", bill.OutWeightTime.ToString()) : " ");

            parameters[20] = new ReportParameter("CardNo", !string.IsNullOrEmpty(bill.CardNo.ToString()) ? bill.CardNo.ToString() : " ");

            // Pass the parameters to the report

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet", "");
            this.reportViewer1.LocalReport.ReportPath = "WeightReport.rdlc";
            this.reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.LocalReport.DataSources.Add(source);

            this.reportViewer1.RefreshReport();

        }
    }
}
