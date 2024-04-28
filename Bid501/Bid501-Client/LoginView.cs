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

namespace Bid501_Client
{
    public partial class LoginView : Form
    {

        public ClientCommCtrl cCtrl;

        public LoginView(ClientCommCtrl cCtrl)
        {
            InitializeComponent();
            this.cCtrl = cCtrl;
            if (cCtrl.ws.IsAlive)
            {
                uxSocketStat.Text = "  Connection: True";
            }
            else
            {
                uxSocketStat.Text = " Connection: False";
            }
        }

        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Text;

            cCtrl.sendLogin(username, password, HandleLoginResponse);
        }

        private void HandleLoginResponse(bool isSuccess)
        {
            Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("Login: " + (isSuccess ? "Successful" : "Failed"));
            });
        }
    }
}
