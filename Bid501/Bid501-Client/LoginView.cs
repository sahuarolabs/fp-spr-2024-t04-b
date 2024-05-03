using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WebSocketSharp;

namespace Bid501_Client
{
    public partial class LoginView : Form
    {
        public ClientCommCtrl cCtrl;

        public LoginView(ClientCommCtrl Ctrl)
        {
            cCtrl = Ctrl;

            InitializeComponent();
            UxConnectionText.Text = cCtrl.IsConnect ? "Connected" : "Not Connected";
        }

        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Text;
            UxLoginButton.Enabled = false;
            cCtrl.sendLogin(username, password);
        }

        private void UsernameTextbox_TextChanged(object sender, EventArgs e)
        {
            UxLoginButton.Enabled = UsernameTextbox.Text != "" && PasswordTextbox.Text != "" && cCtrl.IsConnect;
        }

        private void PasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            UxLoginButton.Enabled = UsernameTextbox.Text != "" && PasswordTextbox.Text != "" && cCtrl.IsConnect;
        }
    }
}
