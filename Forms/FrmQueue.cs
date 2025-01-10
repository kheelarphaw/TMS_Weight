using Syncfusion.Windows.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Weight.Models;
using Syncfusion.Windows.Forms.Tools.Win32API;

namespace TMS_Weight.Forms
{
    public partial class FrmQueue : Form
    {

        SerialPort _serialPort;
       
        public FrmQueue(WeightBridgeQueue queue)
        {
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            InitializeComponent();
            LoadData(queue);

            btnGetWeight.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;


            DateTime d = DateTime.Now;
            this.txtTime.Text = new TimeSpan(d.Hour, d.Minute, d.Second).ToString();

            // Assuming you have a DateTimePicker control named dateTimePicker1
            sfDate.Value = DateTime.Now;

        }

        private void BtnDisable()
        {
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnGetWeight.Enabled = false;
        }

        private void BtnEnable()
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnGetWeight.Enabled = true;
        }

        private void btnGetWeight_Click(object sender, EventArgs e)
        {

            PortIntial();

            ///serialPort
            if (!_serialPort.IsOpen)
                _serialPort.Open();
            string wdata = ReadWeight();
            if (wdata == "Invalid weight data")
            {
                _serialPort.Close();
                btnGetWeight.Enabled = false;

            }
            if (_serialPort.IsOpen)
                _serialPort.Close();
            txtWeight.Text = wdata;
            btnGetWeight.Enabled = false;


            btnCancel.Enabled = true;


            ///Manual
            //string wdata = "15700 g";
            //txtWeight.Text = wdata;

            // Extract the numeric value using regex
            string wvalue = System.Text.RegularExpressions.Regex.Match(wdata, @"\d+").Value;

            // Convert the extracted number string to an integer
            int value = int.Parse(wvalue);
            if (value > 0)
                btnSave.Enabled = true;

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

                // Attach event handler
                //   _serialPort.DataReceived += SerialPortDataReceived;

                // Open the serial port

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            _serialPort.Close();
        }

        private async void sfBtnSave_Click(object sender, EventArgs e)
        {
            ResponseMessage message = new ResponseMessage();
            DialogResult result = MessageBoxAdv.Show(this,
                  "Save changes?",
                  "Weight Service Bill",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                BtnDisable();
                ResponseMessage msg = await SaveServiceBillForQueue();
                if (msg.Status)
                {

                    if (msg.ServiceBillNo == null)
                    {
                        
                        string message1 = "Successfuly Saved!";
                        string title = "Service Bill";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult res = MessageBox.Show(message1, title, buttons, MessageBoxIcon.Information);
                        if (res == DialogResult.Yes)
                        {
                            BtnEnable();
                        }

                    }

                }
                else
                {
                    MessageBox.Show(this, msg.MessageContent, "Weight Service Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnDisable();
                }
            }
            // If the user clicks No, prevent the form from closing or saving
            else 
            {
                return;
            }

        }


        #region Utility Methods

        private void ShowError(string message, Exception ex)
        {
            MessageBoxAdv.Show(this, $"{message}\nDetails: {ex.Message}", "Weight Service Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

    }
}
