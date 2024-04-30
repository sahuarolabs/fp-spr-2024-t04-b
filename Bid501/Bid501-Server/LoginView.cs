using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace Bid501_Server
{
    public partial class LoginView : Form
    {
        AccountController accountController;
        ServerController serverController;

        public LoginView(AccountController aCtrl, ServerController sCtrl)
        {
            InitializeComponent();
        }

        /// Set controllers instantiated in Program.cs
        public void SetController(AccountController aCtrl, ServerController sCtrl)
        {
            accountController = aCtrl;
            serverController = sCtrl;
        }

        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            // Get username/password
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Text;

            serverController.LogIn(username, password, HandleLoginResponse);
        }

        private void HandleLoginResponse(bool isSuccess, string[] deets)
        {
            Invoke((MethodInvoker)delegate
            {
                if (isSuccess)
                {
                    ServerView serverView = new ServerView()
                }
            });
        }

        // enables the login button if and only if both username and password are filled
        private void CheckCredentialsFilled(object sender, EventArgs e)
        {
            UxLoginButton.Enabled = !UsernameTextbox.Text.IsNullOrEmpty() && !PasswordTextbox.Text.IsNullOrEmpty();
        }
    }
}
