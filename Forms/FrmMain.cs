using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Weight.Services;

namespace TMS_Weight.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void toolStripBtnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripBtnInQueue_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var ctl = new CtlInQueue() { Dock = DockStyle.Fill };

            panelMain.Controls.Add(ctl);
        }

        private void toolStripBtnOutQueue_Click(object sender, EventArgs e)
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

        private void toolStripBtnPsw_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var ctl = new CtlChangePsw() { Dock = DockStyle.Fill };

            panelMain.Controls.Add(ctl);
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
            panelTool.Controls.Clear();
            panelTool.Controls.Add(this.toolStrip1);
        }
    }
}
