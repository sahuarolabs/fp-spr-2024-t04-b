using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using Bid501_Shared;
using System.Runtime.Remoting.Messaging;
using WebSocketSharp.Server;
using System.Windows.Forms.VisualStyles;
using System.Runtime.CompilerServices;

namespace Bid501_Client
{
    public class ClientCommCtrl : WebSocketBehavior
    {
        public WebSocket ws;
        BidCtrl bidCtrl;
        public delegate void SendToServer(Bid bid, ProductProxy product);
        public delegate void LoginResponseHandler(bool success, string[] info);
        private LoginResponseHandler loginCallback;
        private string[] cDetails = { "", "" };

        public ClientCommCtrl(WebSocket ws)
        {
            this.ws = ws;
            this.ws.OnMessage += OnMessageHandler;
            int tries = 0;
            while (!ws.IsAlive && tries < 4)
            {
                this.ws.Connect(); 
                tries++;
            } 
        }

        /// <summary>
        /// Receives messages from the server and redirects split strings to appropriate method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">string of information</param>
        private void OnMessageHandler(object sender, MessageEventArgs e)
        {
            string[] parts = e.Data.Split(':');
            if (parts[0] == "notifylogin")
            {
                bool isValid = bool.Parse(parts[1]);
                loginCallback?.Invoke(isValid, cDetails);
            }
        }

        #region LOGIN Stuff

        /// <summary>
        /// TO server -- Login
        /// Working on 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void sendLogin(string username, string password, LoginResponseHandler callback)
        {
            cDetails[0] = username; cDetails[1] = password;
            string x = $"login:{username}:{password}";
            ws.Send(x);
            this.loginCallback = callback;

        }
        #endregion

        #region BID Stuff
        /// <summary>
        /// Gets a bid from BidCtrl "Attemptbid", Sends that bid to the server to verify that bid is good
        /// </summary>
        /// <param name="bid">The bid added from bidctrl</param>
        /// <returns>A bool for if the bid was verified</returns>
        public bool SendBid(Bid bid, IProduct product) //Called from BidControl "Attemptbid"
        {
            MessageBox.Show($"Sent to Server {bid.Ammount}");
            return true;
        }

        #endregion
    }
}
