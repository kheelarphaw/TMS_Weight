using Syncfusion.Windows.Forms;
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
    public partial class FrmQueue : Form
    {
        public FrmQueue(WeightBridgeQueue queue)
        {
            InitializeComponent();
            LoadData(queue);

            DateTime d = DateTime.Now;
            this.txtTime.Text = new TimeSpan(d.Hour, d.Minute, d.Second).ToString();
        }

        private void lblwbId_Click(object sender, EventArgs e)
        {

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

        private async void btnSave_Click(object sender, EventArgs e)
        {
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
                    ClearDialogContents();
                 
                   

                    CtlQueue ctl = new CtlQueue() { Dock = DockStyle.Fill };

                    ctl.Show();
                  
                    // Add main panel and show the form
                    //p.Controls.Add(ctl);

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
            sfCbxGate.SelectedIndex = -1;
            sfCbxTrailer.SelectedIndex = -1;
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

        private void lblBlno_Click(object sender, EventArgs e)
        {

        }
    }
}
