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
            InitializeComponent();

            #region WebSocket Initialization
            string ip = "10.130.160.134";
            ws = new WebSocket("ws://"+ ip + ":8001/server");
            ws.Connect();

            #region Check WebSocket Connection
            bool conn = false;
            if (ws.IsAlive)
            {
                conn = true;
            }
            #endregion
            #endregion

            cCtrl = new ClientCommCtrl(ws);
            uxSocketStat.Text = "  Connection: " + conn + "\n IP: " + ip;
        }

        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Text;

            //bool loginResult = cCtrl.sendLogin(username, password);
            //MessageBox.Show("Login: " + loginResult);
        }
    }
}
