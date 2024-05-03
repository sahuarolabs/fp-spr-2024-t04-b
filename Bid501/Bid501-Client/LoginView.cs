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
        public BidCtrl bCtrl;
        bool isConnected;

        public LoginView(ClientCommCtrl Ctrl)
        {
            cCtrl = Ctrl;
            InitializeComponent();
            isConnected = cCtrl.IsConnect;
            if (isConnected) UxConnectionText.Text = "Connected";
            else UxConnectionText.Text = "Not Connected";
        }

        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Text;
            UxLoginButton.Enabled = false;
            cCtrl.sendLogin(username, password, HandleLoginResponse);
        }

        /// <summary>
        /// Method for delegate to handle the response of Login Verification
        /// </summary>
        /// <param name="isSuccess">Bool indicating whether Login was successful</param>
        private void HandleLoginResponse(bool isSuccess, string[] userInfo)
        {
            Invoke((MethodInvoker)delegate
            {
                if (isSuccess)
                {
                    //assuming user no admin perms
                    bCtrl = new BidCtrl(new Bid501_Shared.Account(userInfo[0], userInfo[1], false), cCtrl);
                }
            });
        }

        private void UsernameTextbox_TextChanged(object sender, EventArgs e)
        {
            UxLoginButton.Enabled = UsernameTextbox.Text != "" && PasswordTextbox.Text != "" && isConnected;
        }

        private void PasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            UxLoginButton.Enabled = UsernameTextbox.Text != "" && PasswordTextbox.Text != "" && isConnected;
        }
    }
}
