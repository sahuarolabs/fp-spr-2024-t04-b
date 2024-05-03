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
using Bid501_Shared;

namespace Bid501_Server
{
    public partial class LoginView : Form
    {
        // Delegates for login button
        private LoginDel login;
        private AfterLoginActionDel afterLogin;

        AccountController accountController;
        ServerController serverController;

        public LoginView()
        {
            InitializeComponent();
        }

        public LoginView(AccountController aCtrl, ServerController sCtrl)
        {
            accountController = aCtrl;
            serverController = sCtrl;
            InitializeComponent();
        }

        public void SetLoginDelegates(LoginDel lDel, AfterLoginActionDel alDel)
        {
            this.login = lDel;
            this.afterLogin = alDel;
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


        // enables the login button if and only if both username and password are filled
        private void CheckCredentialsFilled(object sender, EventArgs e)
        {
            UxLoginButton.Enabled = !UsernameTextbox.Text.IsNullOrEmpty() && !PasswordTextbox.Text.IsNullOrEmpty();
        }
    }
}
