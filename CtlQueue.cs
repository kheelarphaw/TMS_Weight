using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TMS_Weight.Forms;
using TMS_Weight.Models;
using Xamarin.Forms;

namespace TMS_Weight
{
	public partial class CtlQueue : UserControl
	{
		public CtlQueue()
		{
			InitializeComponent();
            LoadData();

            var p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Remove(this);
            }

            BtnEnable();
            sfQueueGrid.Refresh();


            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "InRegNo",
                HeaderText = "CheckInNo",
                Width = 100
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "Type",
                HeaderText = "Type",
                Width = 100
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CardNo",
                HeaderText = "Card No",
                Width = 100
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "TruckVehicleRegNo",
                HeaderText = "Truck No",
                Width = 100
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "TrailerVehicleRegNo",
                HeaderText = "Trailer No",
                Width = 100
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "DriverName",
                HeaderText = "Driver Name",
                Width = 100
            }); 
            
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "WeightBridgeID",
                HeaderText = "Weight Bridge ID",
                Width = 150
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "WBOption",
                HeaderText = "Weight Bridge Option",
                Width = 150
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "BillOption",
                HeaderText = "Bill Option",
                Width = 120
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CargoType",
                HeaderText = "Cargo Type",
                Width = 120
            });

            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CargoInfo",
                HeaderText = "Cargo Info",
                Width = 120
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "DriverLicenseNo",
                HeaderText = "License No",
                Width = 120
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "DriverContactNo",
                HeaderText = "Driver Contact",
                Width = 120
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "YardID",
                HeaderText = "Yard",
                Width = 100
            });
            this.sfQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "GateID",
                HeaderText = "Gate",
                Width = 100
            });


        }


        private void BtnDisable()
        {
            btnAddHoc.Enabled = false;
            btnClose.Enabled = false;
            btnWeight.Enabled = false;
        }

        private void BtnEnable()
        {
            btnAddHoc.Enabled = true;
            btnClose.Enabled = true;
            btnWeight.Enabled = true;
        }

        private void btnWeight_Click(object sender, EventArgs e)
        {
            if (sfQueueGrid.SelectedIndex >= 0)
            {
                // Get the selected row
                var selectedRow = sfQueueGrid.SelectedItem; // Get the first selected row (if you allow multi-selection, use SelectedRecords[] for more)
                                                            //var id = selectedRow.GetType().GetProperty("QueueNo")?.GetValue(selectedRow, null);
                WeightBridgeQueue queue = selectedRow as WeightBridgeQueue;
                if (queue != null)
                {
                    FrmQueue f = new FrmQueue(queue);
                    f.ShowDialog();

                }
                
            }
            else
            {

                string message = "Please select one row.";
                string title = "Weight Bridge Queue";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                }
                else
                {
                    // Do something
                }
            }
        }

        private void btnAddHoc_Click(object sender, EventArgs e)
        {

            FrmAdHoc f = new FrmAdHoc();
            f.ShowDialog();
            
            // f.textBox2.Text = "9h-11234";
            //DialogResult result= f.ShowDialog();
            // if(result==DialogResult.OK)
            // {
            //     var text = f.textBox2.Text;


            //     MessageBox.Show(text, "Weight", MessageBoxButtons.OK,MessageBoxIcon.Information);
            // }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Remove(this);
            }
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sfQueueGrid_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
