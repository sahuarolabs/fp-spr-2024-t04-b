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

namespace Bid501_Client
{
    public class ClientCommCtrl : WebSocketBehavior
    {
        public WebSocket ws;
        BidCtrl bidCtrl;
        public delegate void SendToServer(Bid bid, ProductProxy product);
        public delegate void LoginResponseHandler(bool success);
        private LoginResponseHandler loginCallback;

        public ClientCommCtrl(WebSocket ws)
        {
            this.ws = ws;
            this.ws.OnMessage += OnMessageHandler;
            this.ws.Connect();
        }

        /// <summary>
        /// Receives messages from the server and redirects split strings to appropriate method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">string of information</param>
        public void OnMessageHandler(object sender, MessageEventArgs e)
        {
            string[] parts = e.Data.Split(':');
            if (parts[0] == "notifylogin")
            {
                bool isValid = bool.Parse(parts[1]);
                loginCallback?.Invoke(isValid);
            }
        }

        #region LOGIN SHIT

        /// <summary>
        /// TO server -- Login
        /// Working on 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void sendLogin(string username, string password, LoginResponseHandler callback)
        {
            string x = $"login:{username}:{password}:False";
            ws.Send(x);
            this.loginCallback = callback;

        }
        #endregion

        #region BID SHIT
        /// <summary>
        /// Sends a bid from bidctrl to websocket for the server to check
        /// </summary>
        /// <param name="bid">The bid added from bidctrl</param>
        public void SendBid(Bid bid, IProduct product)
        {
            MessageBox.Show($"Sent to Server {bid.Ammount}");
        }

        #endregion
    }
}
