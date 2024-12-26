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

namespace TMS_Weight.Forms
{
    public partial class FrmServiceBillPrint : Form
    {
        public string yard = "";
        public string serviceNo = "";
        public FrmServiceBillPrint(string billNo, string yard)
        {
            InitializeComponent();
            this.yard = yard;
            this.serviceNo = billNo;

            // this.reportViewer1.Dock = DockStyle.Fill;
        }

        private void FrmServiceBillPrint_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-EQEB97CE;Initial Catalog=tmsdb;User ID=sa;Password=123;Encrypt=False");
            string sql = "SELECT wsb.*, y.Address, y.Phone, y.Email  FROM  WeightServiceBill wsb LEFT OUTER JOIN Yard y ON wsb.YardID= y.YardID Where wsb.YardID =@yard AND ServiceBillNo =@id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@yard", this.yard);
            cmd.Parameters.AddWithValue("@id", this.serviceNo);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);

            ReportParameter[] parameters = new ReportParameter[22];
            parameters[0] = new ReportParameter("Address", !string.IsNullOrEmpty(dt.Rows[0]["Address"].ToString()) ? dt.Rows[0]["Address"].ToString() : " ");
            parameters[1] = new ReportParameter("Phone", !string.IsNullOrEmpty(dt.Rows[0]["Phone"].ToString()) ? dt.Rows[0]["Phone"].ToString() : " ");
            parameters[2] = new ReportParameter("Email", !string.IsNullOrEmpty(dt.Rows[0]["Email"].ToString()) ? dt.Rows[0]["Email"].ToString() : " ");
            parameters[3] = new ReportParameter("CustomerName", !string.IsNullOrEmpty(dt.Rows[0]["CustomerName"].ToString()) ? dt.Rows[0]["CustomerId"].ToString() : " ");
            parameters[4] = new ReportParameter("CustomerAddress", !string.IsNullOrEmpty(dt.Rows[0]["CustomerName"].ToString()) ? dt.Rows[0]["CustomerName"].ToString() : " ");
            parameters[5] = new ReportParameter("CustomerPhone", !string.IsNullOrEmpty(dt.Rows[0]["CustomerName"].ToString()) ? dt.Rows[0]["CustomerName"].ToString() : " ");
            parameters[6] = new ReportParameter("CustomerFax", !string.IsNullOrEmpty(dt.Rows[0]["CustomerName"].ToString()) ? dt.Rows[0]["CustomerName"].ToString() : " ");
            parameters[7] = new ReportParameter("Truck", !string.IsNullOrEmpty(dt.Rows[0]["TruckNo"].ToString()) ? dt.Rows[0]["TruckNo"].ToString() : " ");
            parameters[8] = new ReportParameter("Trailer", !string.IsNullOrEmpty(dt.Rows[0]["TrailerNo"].ToString()) ? dt.Rows[0]["TrailerNo"].ToString() : " ");

            parameters[9] = new ReportParameter("QueueNo", !string.IsNullOrEmpty(dt.Rows[0]["QRegNo"].ToString()) ? dt.Rows[0]["QRegNo"].ToString() : " ");
            parameters[10] = new ReportParameter("Category", !string.IsNullOrEmpty(dt.Rows[0]["WeightCategory"].ToString()) ? dt.Rows[0]["WeightCategory"].ToString() : " ");
            parameters[11] = new ReportParameter("InWeight", !string.IsNullOrEmpty(dt.Rows[0]["InWeight"].ToString()) ? dt.Rows[0]["InWeight"].ToString() : " ");
            parameters[12] = new ReportParameter("OutWeight", dt.Rows[0]["OutWeight"].ToString());
            parameters[13] = new ReportParameter("NetWeight", dt.Rows[0]["NetWeight"].ToString());
            parameters[14] = new ReportParameter("CargoInfo", !string.IsNullOrEmpty(dt.Rows[0]["CargoInfo"].ToString()) ? dt.Rows[0]["CargoInfo"].ToString() : " ");
            parameters[15] = new ReportParameter("DoNo", !string.IsNullOrEmpty(dt.Rows[0]["DoNo"].ToString()) ? dt.Rows[0]["DoNo"].ToString() : " ");

            parameters[16] = new ReportParameter("Remark", !string.IsNullOrEmpty(dt.Rows[0]["Remark"].ToString()) ? dt.Rows[0]["Remark"].ToString() : " ");
            parameters[17] = new ReportParameter("ContainerNo", !string.IsNullOrEmpty(dt.Rows[0]["ContainerNo"].ToString()) ? dt.Rows[0]["ContainerNo"].ToString() : " ");
            parameters[18] = new ReportParameter("BlNo", !string.IsNullOrEmpty(dt.Rows[0]["BLNo"].ToString()) ? dt.Rows[0]["BLNo"].ToString() : " ");
            parameters[19] = new ReportParameter("Vessel", !string.IsNullOrEmpty(dt.Rows[0]["VesselName"].ToString()) ? dt.Rows[0]["VesselName"].ToString() : " ");


            parameters[20] = new ReportParameter("InWeightTime", !string.IsNullOrEmpty(dt.Rows[0]["InWeightTime"].ToString()) ? (string.Format("{0:dd-MM-yyyy hh:mm}", dt.Rows[0]["InWeightTime"].ToString())) : " ");
            parameters[21] = new ReportParameter("OutWeightTime", !string.IsNullOrEmpty(dt.Rows[0]["OutWeightTime"].ToString()) ? string.Format("{0:dd-MM-yyyy hh:mm}", dt.Rows[0]["OutWeightTime"].ToString()) : " ");

            // Pass the parameters to the report

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet", dt);
            this.reportViewer1.LocalReport.ReportPath = "WeightReport.rdlc";
            this.reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.LocalReport.DataSources.Add(source);

            this.reportViewer1.RefreshReport();

            //!string.IsNullOrEmpty(grn.RecDate.ToString()) ? (string.Format("{0:dd-MM-yyyy}", grn.RecDate)) : ""

        }
    }
}
