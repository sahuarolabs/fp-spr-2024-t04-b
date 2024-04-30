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
        private LoginDel login;
        private AfterLoginActionDel afterLogin;

        public LoginView(LoginDel login, AfterLoginActionDel afterLogin)
        {
            this.login = login;
            this.afterLogin = afterLogin;
            InitializeComponent();
        }

        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Text;

            // call the delegates for login and after login logic
            bool success = true;// login(username, password, false);
            bool shouldClose = afterLogin(success);

            // hide the window if login is successful
            // (closing it would terminate the application at this point)
            if (shouldClose)
                Hide();
        }

        // enables the login button if and only if both username and password are filled
        private void CheckCredentialsFilled(object sender, EventArgs e)
        {
            UxLoginButton.Enabled = !UsernameTextbox.Text.IsNullOrEmpty() && !PasswordTextbox.Text.IsNullOrEmpty();
        }
    }
}
