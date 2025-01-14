﻿using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
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
    public partial class CtlInQueue : UserControl
    {
        public CtlInQueue()
        {
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            InitializeComponent();
            LoadData();
            btnEnabled();

            this.sfInQueueGrid.Style.HeaderStyle.BackColor = Color.SteelBlue;
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "InRegNo",
                HeaderText = "CheckInNo",
                Width = 100
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "Type",
                HeaderText = "Type",
                Width = 50
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CardNo",
                HeaderText = "Card No",
                Width = 100
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "TruckVehicleRegNo",
                HeaderText = "Truck No",
                Width = 100
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "TrailerVehicleRegNo",
                HeaderText = "Trailer No",
                Width = 100
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "DriverName",
                HeaderText = "Driver Name",
                Width = 100
            });

            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "WeightBridgeID",
                HeaderText = "Weight Bridge ID",
                Width = 150
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "WBOption",
                HeaderText = "Weight Bridge Option",
                Width = 150
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "BillOption",
                HeaderText = "Bill Option",
                Width = 120
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CargoType",
                HeaderText = "Cargo Type",
                Width = 120
            });

            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CargoInfo",
                HeaderText = "Cargo Info",
                Width = 120
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "DriverLicenseNo",
                HeaderText = "License No",
                Width = 120
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "DriverContactNo",
                HeaderText = "Driver Contact",
                Width = 120
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "YardID",
                HeaderText = "Yard",
                Width = 100
            });
            this.sfInQueueGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "GateID",
                HeaderText = "Gate",
                Width = 100
            });
        }

        private void btnEnabled()
        {
            this.sfbtnExport.Enabled = true;
            this.sfBtnInWeight.Enabled = true;
        }

        private void btnDisabled()
        {
            this.sfbtnExport.Enabled = false;
            this.sfBtnInWeight.Enabled = false;
        }

        private void sfBtnWeight_Click(object sender, EventArgs e)
        {

            if (sfInQueueGrid.SelectedIndex >= 0)
            {
                // Get the selected row
                var selectedRow = sfInQueueGrid.SelectedItem; // Get the first selected row (if you allow multi-selection, use SelectedRecords[] for more)
                                                            //var id = selectedRow.GetType().GetProperty("QueueNo")?.GetValue(selectedRow, null);
                WeightBridgeQueue queue = selectedRow as WeightBridgeQueue;
                if (queue != null)
                {
                    this.sfInQueueGrid.SelectedIndex = -1;

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


        // Method to refresh the grid
        private void RefreshGrid()
        {
            btnEnabled();
            pnlInQueue.Refresh();
            // Add a delay of 1000 milliseconds (1 second) before refreshing the grid
            System.Threading.Thread.Sleep(2000);  // Sleep for 5 second
                                                  // Refresh or reload the data in the grid
            sfInQueueGrid.Refresh();
            LoadData();

        }

    }
}



