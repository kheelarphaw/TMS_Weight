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
            pnlMain.Controls.Add(ctl);
			
		}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            CtlServiceBill ctl = new CtlServiceBill();
            ctl.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(ctl);
        }


        //private void btnAddHoc_Click(object sender, EventArgs e)
        //{
        //    pnlMain.Controls.Clear();
        //    //var ctl = new () { Dock = DockStyle.Fill };

        //    //pnlMain.Controls.Add(ctl);
        //}
    }
}
