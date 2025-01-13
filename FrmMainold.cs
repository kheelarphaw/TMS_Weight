using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Weight.Forms;
using TMS_Weight.Services;

namespace TMS_Weight
{
	public partial class FrmMainold : Form
	{
		public FrmMainold()
		{
			InitializeComponent();
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnQueue_Click(object sender, EventArgs e)
		{
			
			
		}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
           
        }

        private void toolStripBtnQ_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripBtnIn_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var ctl = new CtlInQueue() { Dock = DockStyle.Fill };

            panelMain.Controls.Add(ctl);
        }

        private void toolStripBtnOut_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var ctl = new CtlOutQueue() { Dock = DockStyle.Fill };

            panelMain.Controls.Add(ctl);
        }

        private void toolStripBtnAdHoc_Click(object sender, EventArgs e)
        {
            
            panelMain.Controls.Clear();
            var ctl = new CtlAdHoc() { Dock = DockStyle.Fill };

            panelMain.Controls.Add(ctl);
        }

        private void toolStripBtnBill_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var ctl = new CtlWeightServiceBill() { Dock = DockStyle.Fill };

            panelMain.Controls.Add(ctl);
        }

        private void toolStripBtnLogin_Click(object sender, EventArgs e)
        {

        }

        private void toolStripBtnChangePassword_Click(object sender, EventArgs e)
        {

        }

        private void toolStripBtnLogout_Click(object sender, EventArgs e)
        {
            CommonData.userName = string.Empty;
            CommonData.password = string.Empty;
            CommonData.token = string.Empty;
            this.Hide();
            Application.OpenForms["FrmLogin"]?.Show(); // Show the hidden FrmLogin

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Controls.Clear();
            menuStrip1.Controls.Add(this.toolStrip1);

        }
    }
}
