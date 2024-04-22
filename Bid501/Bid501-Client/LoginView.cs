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
        WebSocket ws;
        ClientCommCtrl cCtrl;

        public LoginView()
        {
            #region WebSocket Initialization
            ws = new WebSocket("ws://127.0.0.1:8001/Test");
            ws.Connect();

            #region Check WebSocket Connection
            bool conn = false;
            if (ws.IsAlive)
            {
                conn = true;
            }
            MessageBox.Show("Connection: " + conn);
            #endregion
            #endregion

            InitializeComponent();
            cCtrl = new ClientCommCtrl(ws);
        }

        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Text;

            bool loginResult = cCtrl.handleLogin(username, password);
            MessageBox.Show("Login: " + loginResult);

            //if(loginResult)
            {
                BidView bidView = new BidView();
                bidView.Show();
            }
        }
    }
}
