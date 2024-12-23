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
    public partial class CtlServiceBill : UserControl
    {
        public CtlServiceBill()
        {
            InitializeComponent();

            this.sfServiceGrid.Columns.Add(new GridDateTimeColumn()
            {
                MappingName = "ServiceBillDate",
                HeaderText = "Date",
                Format = "dd/MM/yyyy hh:mm:ss",
                Width = 150
            });
            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "InWeightTime",
                HeaderText = "In Weight Time",
                Width = 150
            });
            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "OutWeightTime",
                HeaderText = "Out Weight Time",
                Width = 150
            });
            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "InWeight",
                HeaderText = "Weighing In",
                Width = 150
            });
            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "OutWeight",
                HeaderText = "Weighing Out",
                Width = 150
            });
            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "NetWeight",
                HeaderText = "Net Weight",
                Width = 150
            });

            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "WeightBridgeID",
                HeaderText = "Weight Bridge",
                Width = 150
            });
            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "GateID",
                HeaderText = "Gate",
                Width = 150
            });
            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "YardID",
                HeaderText = "Yard",
                Width = 150
            });
            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "DriverName",
                HeaderText = "Driver Name",
                Width = 150
            });
            
            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "WBOption",
                HeaderText = "Weight Bridge Option",
                Width = 150
            });
            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "BillOption",
                HeaderText = "Bill Option",
                Width = 150
            });
            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CargoInfo",
                HeaderText = "Cargo Info",
                Width = 150
            });

            this.sfServiceGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "Remark",
                HeaderText = "Remark",
                Width = 150
            });


        }

        private void BtnDisable()
        {
            sfBtnPrint.Enabled = false;
            sfBtnView.Enabled = false;
        }

        private void BtnEnable()
        {
            sfBtnPrint.Enabled = true;
            sfBtnView.Enabled = true;
        }

        private async void btnView_Click(object sender, EventArgs e)
        {
            ResponseMessage msg = await GetServiceBill();
            if (msg.Status)
            {
                BtnEnable();
            }
            else
            {
                MessageBoxAdv.Show(this, "Data not found!", "Weight Service Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnEnable();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (sfServiceGrid.SelectedIndex >= 0)
            {
                // Get the selected row
                var selectedRow = sfServiceGrid.SelectedItem; // Get the first selected row (if you allow multi-selection, use SelectedRecords[] for more)

                var id = selectedRow.GetType().GetProperty("ServiceBillNo")?.GetValue(selectedRow, null);
                var yard = selectedRow.GetType().GetProperty("YardID")?.GetValue(selectedRow, null);
                var inWeight = selectedRow.GetType().GetProperty("InWeight")?.GetValue(selectedRow, null);
                var outWeight = selectedRow.GetType().GetProperty("InWeight")?.GetValue(selectedRow, null);
                if(inWeight != null && outWeight != null)
                {
                    FrmServiceBillPrint f = new FrmServiceBillPrint(id.ToString(), yard.ToString());
                    f.Show();
                }
                else
                {
                    string message = "Weighing does not complete!";
                    string title = "Service Bill";
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
            else
            {

                string message = "Please select one row.";
                string title = "Weight Service Bill";
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            var p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Remove(this);
            }
        }
    }
}
