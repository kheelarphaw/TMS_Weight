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
    public partial class CtlChangePsw : UserControl
    {
        public CtlChangePsw()
        {
            InitializeComponent();
            txtEmail.Text = CommonData.userName;
           
        }

        private async void btnChange_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrEmpty(txtPsw.Text) && !String.IsNullOrEmpty(txtConfirmPsw.Text))
            {
                if (txtPsw.Text != txtConfirmPsw.Text)
                {
                    MessageBoxAdv.Show(this, "Password and Confirm Password are not matched!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                LoginUser loginUser = new LoginUser();
                loginUser.Email = txtEmail.Text;
                loginUser.Password = txtPsw.Text;
                loginUser.ConfirmPassword = txtConfirmPsw.Text;
                btnChange.Enabled = false;
                btnClose.Enabled = false;
                AuthResponse msg = new AuthResponse();
                msg = await ChangePassword(loginUser);
                if (msg.IsAuthSuccessful)
                {
                    MessageBoxAdv.Show(this, "Successfully changed!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CommonData.password = loginUser.Password;
                    txtPsw.Text = string.Empty;
                    txtConfirmPsw.Text = string.Empty;
                    btnChange.Enabled = true;
                    btnClose.Enabled = true;
                }
                else
                {
                    MessageBoxAdv.Show(this, msg.ErrorMessage, "Log In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnChange.Enabled = true;
                    btnClose.Enabled = true;
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            txtPsw.Text = string.Empty;
            txtConfirmPsw.Text = string.Empty;
            var p = this.Parent as Panel;
            if (p != null)
            {
                FrmMain main = new FrmMain();
                p.Controls.Remove(this);
                p.Controls.Add(main.pictureHome);

            }
        }
    }
}
