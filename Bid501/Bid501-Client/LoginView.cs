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
        private BidCtrl bCtrl;

        public LoginView(ClientCommCtrl cCtrl)
        {
            InitializeComponent();
            this.cCtrl = cCtrl;
            ConnectionVerification();
        }

        /// <summary>
        /// Checks the Connection
        /// </summary>
        private void ConnectionVerification()
        {
            if (cCtrl.ws.IsAlive)
            {
                uxSocketStat.Text = "  Connection: True";
            }
            else
            {
                uxSocketStat.Text = " Connection: False";
            }
        }

        /// <summary>
        /// Handle Login Button Click
        /// </summary>
        /// <param name="sender">event</param>
        /// <param name="e">data</param>
        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Text;

            cCtrl.sendLogin(username, password, HandleLoginResponse);
        }

        /// <summary>
        /// Method for delegate to handle the response of Login Verification
        /// </summary>
        /// <param name="isSuccess">Bool indicating whether Login was successful</param>
        private void HandleLoginResponse(bool isSuccess, string[] deets)
        {
            Invoke((MethodInvoker)delegate
            {
                if (isSuccess)
                {
                    bCtrl = new BidCtrl(new Bid501_Shared.Account(deets[0], deets[1], false), cCtrl);
                }
            });
        }
    }
}
