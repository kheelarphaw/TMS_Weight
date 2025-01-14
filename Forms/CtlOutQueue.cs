using Syncfusion.Windows.Forms;
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
using TMS_Weight.Models;

namespace TMS_Weight.Forms
{
    public partial class CtlOutQueue : UserControl
    {
        public CtlOutQueue()
        {
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            InitializeComponent();
            LoadData();

            this.sfOutQueueGrid.Style.HeaderStyle.BackColor = Color.SteelBlue;
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "InRegNo",
                HeaderText = "CheckInNo",
                Width = 100
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "Type",
                HeaderText = "Type",
                Width = 100
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CardNo",
                HeaderText = "Card No",
                Width = 100
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "TruckVehicleRegNo",
                HeaderText = "Truck No",
                Width = 100
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "TrailerVehicleRegNo",
                HeaderText = "Trailer No",
                Width = 100
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "DriverName",
                HeaderText = "Driver Name",
                Width = 100
            });

            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "WeightBridgeID",
                HeaderText = "Weight Bridge ID",
                Width = 150
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "WBOption",
                HeaderText = "Weight Bridge Option",
                Width = 150
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "BillOption",
                HeaderText = "Bill Option",
                Width = 120
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CargoType",
                HeaderText = "Cargo Type",
                Width = 120
            });

            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CargoInfo",
                HeaderText = "Cargo Info",
                Width = 120
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "DriverLicenseNo",
                HeaderText = "License No",
                Width = 120
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "DriverContactNo",
                HeaderText = "Driver Contact",
                Width = 120
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "YardID",
                HeaderText = "Yard",
                Width = 100
            });
            this.sfOutQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "GateID",
                HeaderText = "Gate",
                Width = 100
            });

        }

        private void sfBtnWeight_Click(object sender, EventArgs e)
        {

            if (sfOutQueueGrid.SelectedIndex >= 0)
            {
                // Get the selected row
                var selectedRow = sfOutQueueGrid.SelectedItem; // Get the first selected row (if you allow multi-selection, use SelectedRecords[] for more)
                                                              //var id = selectedRow.GetType().GetProperty("QueueNo")?.GetValue(selectedRow, null);
                WeightBridgeQueue queue = selectedRow as WeightBridgeQueue;
                if (queue != null)
                {
                    this.sfOutQueueGrid.SelectedIndex = -1;

                    FrmQueue f = new FrmQueue(queue);

                    // Show the form as a dialog
                    f.ShowDialog();

                    // Optionally, you can refresh the grid again if data has changed after the form closes
                    RefreshGrid();


                }

            }
            else
            {

                string message = "Please select one row.";
                string title = "Weight Bridge In Queue";
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

        private void btnEnabled()
        {
            //this.sfBtnOutView.Enabled = true;
            this.sfBtnOutWeight.Enabled = true;
        }

        private void btnDisabled()
        {
            //this.sfBtnOutView.Enabled = false;
            this.sfBtnOutWeight.Enabled = false;
        }


        // Method to refresh the grid
        private void RefreshGrid()
        {

            pnlOutQueue.Refresh();
            // Refresh or reload the data in the grid
            sfOutQueueGrid.Refresh();
            // Add a delay of 1000 milliseconds (1 second) before refreshing the grid
            System.Threading.Thread.Sleep(2000);  // Sleep for 5 second
            LoadData();
            btnEnabled();
        }


    }
}
