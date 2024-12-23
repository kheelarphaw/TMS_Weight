﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Weight.Forms;

namespace TMS_Weight
{
	public partial class FrmMain : Form
	{
		public FrmMain()
		{
			InitializeComponent();
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnQueue_Click(object sender, EventArgs e)
		{
			CtlQueue ctl=new CtlQueue();
            ctl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ctl);
			
		}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            CtlServiceBill ctl = new CtlServiceBill();
            ctl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ctl);
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
            FrmAdHoc f = new FrmAdHoc();
            f.ShowDialog();
        }

        private void toolStripBtnBill_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var ctl = new CtlServiceBill() { Dock = DockStyle.Fill };

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

        }
    }
}
