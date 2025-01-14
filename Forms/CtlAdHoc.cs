using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Weight.Models;

namespace TMS_Weight.Forms
{
    public partial class CtlAdHoc : UserControl
    {
        SerialPort _serialPort;
        string weightString = String.Empty;
        string weightStringKG = String.Empty;
        string bufferString = String.Empty;
        int weight = 0;
        int grossWeight = 0, tareWeight = 0, netWeight = 0;
        public CtlAdHoc()
        {
            InitializeComponent();
            LoadData();

            BtnEnable();


              DateTime d = DateTime.Now;
            //this.txtTime.Text = new TimeSpan(d.Hour, d.Minute, d.Second).ToString();

            // Assuming you have a DateTimePicker control named dateTimePicker1
            sfDate.Value = DateTime.Now;

            txtwbId.Text = Properties.Settings.Default.WBCode.ToString();

        }

        private void BtnDisable()
        {
            btnAdHocSave.Enabled = false;
            btnAdHocCancel.Enabled = false;
        }

        private void BtnEnable()
        {
            btnAdHocSave.Enabled = true;
            btnAdHocCancel.Enabled = true;
            sfBtnGetAdHoc.Enabled = true;   
        }


        private void ClearDialogContents()
        {
            // Assuming you have a dialog with textboxes and combo boxes

            txtBlNo.Clear();// Clears text in TextBox
            txtCargoInfo.Clear();
            txtContainer.Clear();
            txtCustomer.Clear();
            txtDLicense.Clear();
            txtDoNo.Clear();
            txtDriver.Clear();
            txtRemark.Clear();
            sfCbxBillOption.SelectedIndex = -1; // Clears selection in ComboBox
            sfCbxCategory.SelectedIndex = -1;
            sfCbxTrailer.SelectedIndex = -1;
            sfCbxTransporter.SelectedIndex = -1;
            sfCbxTruck.SelectedIndex = -1;
            txtwbId.Clear();
            txtCash.Clear();
            txtAdHocWeight.Clear();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxAdv.Show(this,
                  "Save changes?",
                  "Weight Service Bill",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BtnDisable();
                ResponseMessage msg = await SaveServiceBillForAdHoc();
                if (msg.Status)
                {
                    ClearDialogContents();

                    FrmServiceBillPrint f = new FrmServiceBillPrint(msg.ServiceBillNo.ToString());
                    f.Show();

                    //MessageBoxAdv.Show(this, "Successfuly Saved!", "Weight Service Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnEnable();
                }
                else
                {
                    MessageBoxAdv.Show(this, msg.MessageContent, "Weight Service Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnDisable();
                }
            }
        }

        private void sfBtnGetAdHocWeight_Click(object sender, EventArgs e)
        {
            PortIntial();

            // serialPort
            if (!_serialPort.IsOpen)
                _serialPort.Open();
            string wdata = ReadWeight();
            if (wdata == "Invalid weight data")
            {
                _serialPort.Close();
                sfBtnGetAdHoc.Enabled = false;

            }
            if (_serialPort.IsOpen)
                _serialPort.Close();
            txtAdHocWeight.Text = wdata;
            sfBtnGetAdHoc.Enabled = false;


            btnAdHocCancel.Enabled = true;


            ///Manual
            //string wdata = "15700 g";
            //txtAdHocWeight.Text = wdata;

            // Extract the numeric value using regex
            string wvalue = System.Text.RegularExpressions.Regex.Match(wdata, @"\d+").Value;

            // Convert the extracted number string to an integer
            int value = int.Parse(wvalue);
            if (value > 0)
                btnAdHocSave.Enabled = true;

        }


        public void PortIntial()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            _serialPort = new SerialPort();

            try
            {
                // Configure SerialPort using settings
                _serialPort.PortName = Properties.Settings.Default.PortName;
                _serialPort.BaudRate = Properties.Settings.Default.BaudRate;
                _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), Properties.Settings.Default.Parity.ToString(), true);
                _serialPort.DataBits = Properties.Settings.Default.DataBits;
                _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Properties.Settings.Default.StopBits.ToString(), true);
                _serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), Properties.Settings.Default.Handshake.ToString(), true);
                _serialPort.ReadTimeout = 5000;
                _serialPort.WriteTimeout = 5000;

               

            }
            catch (UnauthorizedAccessException ex)
            {
                ShowError("Access to the serial port is denied.", ex);
                _serialPort.Close();
            }
            catch (IOException ex)
            {
                ShowError("Failed to open the serial port.", ex);
                _serialPort.Close();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ShowError("Invalid serial port configuration.", ex);
                _serialPort.Close();
            }
        }

        public string ReadWeight()
        {
            if (_serialPort.IsOpen)
            {
                try
                {
                    string weightData = string.Empty;
                    while (_serialPort.BytesToRead > 0)
                    {
                        weightData += _serialPort.ReadExisting();  // Read data in chunks
                    }

                    return ParseWeight(weightData);  // Parse the received weight data
                }
                catch (TimeoutException ex)
                {
                    Console.WriteLine("Read timeout.");
                    ShowError("Read timeout.", ex);

                    return string.Empty;
                }
            }
            return string.Empty;
        }

        private string ParseWeight(string data)
        {
            Console.WriteLine("Raw data: " + data);  // Log raw data for debugging

            // Adjust this to match your data format
            if (!string.IsNullOrEmpty(data) && data.Contains("G"))
            {
                // Split the data by "G" and extract the part containing the weight
                string[] parts = data.Split('G');

                foreach (var part in parts)
                {
                    // Trim leading/trailing whitespace and other control characters
                    string trimmedPart = part.Trim(new char[] { '\u0002', '\u0003', ' ', '-' });

                    // Check if the part contains a valid numeric weight
                    if (double.TryParse(trimmedPart, out double weight))
                    {
                        // Return the weight in grams (e.g., "20G")

                        if (weight > 0)
                            return weight.ToString("F2") + " g";
                    }
                }
            }

            // Return "Invalid weight data" if no valid weight is found
            return "Invalid weight data";
        }





        #region Utility Methods

        //private void ShowError(string message, Exception ex)
        //{
        //    MessageBoxAdv.Show(this, $"{message}\nDetails: {ex.Message}", "Weight Service Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}



        #endregion


    }
}
