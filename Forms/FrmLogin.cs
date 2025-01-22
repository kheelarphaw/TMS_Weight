using Syncfusion.Windows.Forms;
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
using TMS_Weight.Services;

namespace TMS_Weight.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            ValidUser();
            //lblGate.Text =Properties.Settings.Default.Gate;
            lblLogin.Text = lblLogin.Text + " (" + Properties.Settings.Default.WBCode + ")";

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUserName.Text) && !String.IsNullOrEmpty(txtUserName.Text))
            {
                DialogResult result = MessageBoxAdv.Show(this,
                 "Are you sure?",
                 "Log In",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    LoginUser loginUser = new LoginUser();
                    loginUser.Email = txtUserName.Text;
                    loginUser.Password = txtPassword.Text;
                    loginUser.YardCode = Properties.Settings.Default.YardCode;
                    loginUser.Operation = Properties.Settings.Default.WBCode;
                    btnLogin.Enabled = false;
                    btnQuit.Enabled = false;
                    AuthResponse msg = new AuthResponse();

                    msg = await SaveLogIn(loginUser);
                    if (msg.IsAuthSuccessful)
                    {
                        MessageBoxAdv.Show(this, "Login success!", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLogin.Enabled = true;
                        btnQuit.Enabled = true;
                        CommonData.userName = loginUser.Email;
                        CommonData.password = loginUser.Password;
                        CommonData.token = msg.Token;
                        txtUserName.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                        this.Hide();
                        FrmMain main = new FrmMain();
                        main.Show();
                    }
                    else
                    {
                        MessageBoxAdv.Show(this, msg.ErrorMessage, "Log In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnLogin.Enabled = true;
                        btnQuit.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBoxAdv.Show(this, "Please enter username and password!", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
