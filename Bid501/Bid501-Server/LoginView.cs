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
        LoginDel login;
        AfterLoginActionDel afterLogin;

        public LoginView(LoginDel login, AfterLoginActionDel afterLogin)
        {
            this.login = login;
            this.afterLogin = afterLogin;

            InitializeComponent();
        }

        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            // Get username/password
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Text;

            // call the delegates for login and after login logic
            bool success = login(username, password, true);
            bool shouldClose = afterLogin(success);
        }


        private void HandleLoginResponse(bool isSuccess, string[] deets)
        {
            Invoke((MethodInvoker)delegate
            {
                if (isSuccess)
                {
                    // ServerView serverView = new ServerView();
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
