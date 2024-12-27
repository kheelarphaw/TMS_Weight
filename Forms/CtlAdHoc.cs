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

            DateTime d = DateTime.Now;
            this.txtTime.Text = new TimeSpan(d.Hour, d.Minute, d.Second).ToString();

        }

        private void BtnDisable()
        {
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void BtnEnable()
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
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
            sfCbxWBId.SelectedIndex = -1;
            sfCbxWOption.SelectedIndex = -1;
            sfCbxWType.SelectedIndex = -1;
            sfNtxtCash.Clear();
            sfNtxtWeight.Clear();

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

                    MessageBoxAdv.Show(this, "Successfuly Saved!", "Weight Service Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnEnable();
                }
                else
                {
                    MessageBoxAdv.Show(this, msg.MessageContent, "Weight Service Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnDisable();
                }
            }
        }

        private void sfBtnGet_Click(object sender, EventArgs e)
        {
            SerialPortProcess();
        }

        #region Serial Port Properties
        public void SerialPortProcess()
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
                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;

                // Attach event handler
                _serialPort.DataReceived += SerialPortDataReceived;

                // Open the serial port
                _serialPort.Open();
            }
            catch (UnauthorizedAccessException ex)
            {
                ShowError("Access to the serial port is denied.", ex);
            }
            catch (IOException ex)
            {
                ShowError("Failed to open the serial port.", ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ShowError("Invalid serial port configuration.", ex);
            }
        }

        #endregion

        #region Serial Port Data Receive Function
        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Read available bytes from the serial port
                byte[] buffer = new byte[_serialPort.BytesToRead];
                int bytesRead = _serialPort.Read(buffer, 0, buffer.Length);

                if (bytesRead > 0)
                {
                    string rawData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    ProcessWeightData(rawData);
                }
            }
            catch (Exception ex)
            {
                ShowError("Error while receiving data from the serial port.", ex);
            }
        }

        private void ProcessWeightData(string data)
        {
            try
            {
                string weightString = ParseWeightFromData(data);

                if (!string.IsNullOrEmpty(weightString))
                {
                    string weightStringKG = AddKG(weightString);

                    // Update UI in a thread-safe manner
                    sfNtxtWeight.Invoke((MethodInvoker)delegate
                    {
                        sfNtxtWeight.Text = weightStringKG;
                    });
                }
            }
            catch (FormatException ex)
            {
                ShowError("Failed to parse weight data.", ex);
            }
        }

        private string ParseWeightFromData(string data)
        {
            StringBuilder bufferString = new StringBuilder();
            bool readingWeight = false;

            foreach (char ch in data)
            {
                if (ch == '+')
                {
                    if (readingWeight) break; // End of weight
                    readingWeight = true; // Start reading weight
                    continue;
                }

                if (readingWeight && (char.IsDigit(ch) || ch == '.'))
                {
                    bufferString.Append(ch);
                }
            }

            string result = bufferString.ToString();

            // Adjust for specific device quirks
            if (result == "0.0005") result = "0.000";

            return result.Length > 4 ? result : string.Empty;
        }

 

        #endregion

        #region Utility Methods

        private void ShowError(string message, Exception ex)
        {
            MessageBoxAdv.Show(this, $"{message}\nDetails: {ex.Message}", "Weight Service Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string AddKG(string weightValue)
        {
            return string.IsNullOrEmpty(weightValue) ? "0 kg" : $"{weightValue} kg";
        }

        #endregion


    }
}
