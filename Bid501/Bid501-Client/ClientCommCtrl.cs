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
        /// <summary>
        /// The WebSocket that connects to The server
        /// </summary>
        private WebSocket ws = new WebSocket($"ws://127.0.0.1:8001/server");

        /// <summary>
        /// The Login View
        /// </summary>
        private LoginView lView;
        private WebSocket ws;

        /// <summary>
        /// a string[] that stores the current username, password
        /// </summary>
        private string[] clientLoginInfo = { "", "" };

        /// <summary>
        /// Delegate for the LoginView
        /// </summary>
        /// <param name="success"> Bool to determine if the login was successful</param>
        /// <param name="info">The clientLoginInfo of {"Username", "Password"}</param>
        public delegate void LoginResponseHandler(bool success, string[] info);

        /// <summary>
        /// Delegate to go back to LoginView
        /// </summary>
        private LoginResponseHandler loginCallback;
        

        public ClientCommCtrl(LoginView view)
        {
            lView = view;
            this.ws = ws = new WebSocket($"ws://10.130.160.31:8001/server");
            ws.OnMessage += OnMessageHandler;
            ws.OnError += OnErrorHandler;
            this.ws.Connect();
            if (!ws.IsAlive) ;
        }

        public void Close()
        {
            ws.Close();
            Console.WriteLine("Close: Controller");
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
                loginCallback?.Invoke(isValid, clientLoginInfo);
            }
        }

        private void OnErrorHandler(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"Eror in Controller: {e.Message}");
        }

        #region LOGIN Stuff

        public void sendLogin(string username, string password, LoginResponseHandler callback)
        {
            clientLoginInfo[0] = username; 
            clientLoginInfo[1] = password;
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
