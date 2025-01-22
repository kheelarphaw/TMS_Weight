using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Weight.Models;

namespace TMS_Weight.Forms
{
    public partial class CtlWeightServiceBill : UserControl
    {
        public CtlWeightServiceBill()
        {
            InitializeComponent();
            this.sfSBGrid.Style.HeaderStyle.BackColor = Color.SteelBlue;

            this.sfSBGrid.Columns.Add(new GridDateTimeColumn()
            {
                MappingName = "ServiceBillDate",
                HeaderText = "Date",
                Format = "dd/MM/yyyy hh:mm:ss",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "TruckNo",
                HeaderText = "Truck",
                Width = 80
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CardNo",
                HeaderText = "Card No",
                Width = 100
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "TrailerNo",
                HeaderText = "Trailer",
                Width = 80
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CustomerName",
                HeaderText = "Customer",
                Width = 300
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "InWeightTime",
                HeaderText = "In Weight Time",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "OutWeightTime",
                HeaderText = "Out Weight Time",
                Width = 150
            });
            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "InWeight",
                HeaderText = "Weighing In",
                Width = 150,
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "OutWeight",
                HeaderText = "Weighing Out",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "NetWeight",
                HeaderText = "Net Weight",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "InWeightCash",
                HeaderText = "In Weight Cash",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "OutWeightCash",
                HeaderText = "Out Weight Cash",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "Status",
                HeaderText = "Status",
                Width = 100
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "WeightBridgeID",
                HeaderText = "In Weight Bridge",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "OutWeightBridgeID",
                HeaderText = "Out Weight Bridge",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "GateID",
                HeaderText = "Gate",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "YardID",
                HeaderText = "Yard",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "DriverName",
                HeaderText = "Driver Name",
                Width = 120
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "WeightOption",
                HeaderText = "Weight Option",
                Width = 120
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "BillOption",
                HeaderText = "Bill Option",
                Width = 100
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "WeightCategory",
                HeaderText = "Weight Category",
                Width = 120
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "CargoInfo",
                HeaderText = "Cargo Info",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "ContainerNo",
                HeaderText = "Container",
                Width = 200
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "BLNo",
                HeaderText = "BL No",
                Width = 100
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "TransporterID",
                HeaderText = "Transporter",
                Width = 100
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "Remark",
                HeaderText = "Remark",
                Width = 150
            });

            this.sfSBGrid.Columns.Add(new GridTextColumn()
            {
                MappingName = "ServiceBillNo",
                HeaderText = "Service Bill No",
                Width = 170
            });

        }

        private void BtnDisable()
        {
            sfBtnSBView.Enabled = false;
            sfBtnPrint.Enabled = false;
        }

        private void BtnEnable()
        {
            sfBtnSBView.Enabled = true;
            sfBtnPrint.Enabled = true;
        }

        private async void sfBtnSBView_Click(object sender, EventArgs e)
        {
            this.sfSBGrid.AllowResizingColumns = true;
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

        private void sfBtnPrint_Click(object sender, EventArgs e)
        {
            if (sfSBGrid.SelectedIndex >= 0)
            {
                // Get the selected row
                var selectedRow = sfSBGrid.SelectedItem; // Get the first selected row (if you allow multi-selection, use SelectedRecords[] for more)

                var id = selectedRow.GetType().GetProperty("ServiceBillNo")?.GetValue(selectedRow, null);
                //var yard = selectedRow.GetType().GetProperty("YardID")?.GetValue(selectedRow, null);
                //var inWeight = selectedRow.GetType().GetProperty("InWeight")?.GetValue(selectedRow, null);
                //var outWeight = selectedRow.GetType().GetProperty("OutWeight")?.GetValue(selectedRow, null);
                var status = selectedRow.GetType().GetProperty("Status")?.GetValue(selectedRow, null);

                if (status.ToString() != "In(Weight)")
                {
                    FrmServiceBillPrint f = new FrmServiceBillPrint(id.ToString());
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
                        sfSBGrid.SelectedItem = null;
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

        private void sfbtnInExport_Click(object sender, EventArgs e)
        {
            if (sfSBGrid.View != null)
            {
                var options = new ExcelExportingOptions
                {
                    ExcelVersion = ExcelVersion.Excel2013
                };
                var excelEngine = this.sfSBGrid.ExportToExcel(sfSBGrid.View, options);
                var workBook = excelEngine.Excel.Workbooks[0];

                using (SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx",
                    FilterIndex = 2
                })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream stream = saveFileDialog.OpenFile())
                        {
                            switch (saveFileDialog.FilterIndex)
                            {
                                case 1:
                                    workBook.Version = ExcelVersion.Excel97to2003;
                                    break;
                                case 2:
                                    workBook.Version = ExcelVersion.Excel2010;
                                    break;
                                case 3:
                                    workBook.Version = ExcelVersion.Excel2013;
                                    break;
                            }
                            workBook.SaveAs(stream);
                        }

                        if (MessageBox.Show("Do you want to view the workbook?", "Export Successful",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(saveFileDialog.FileName);
                        }
                    }
                }
            }
            else
            {
                MessageBoxAdv.Show(this, "No Data!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
