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
using System.Net.Sockets;
using System.Net;

namespace Bid501_Client
{
    public class ClientCommCtrl : WebSocketBehavior
    {
        // View and Websocket for ClientComm instance
        private LoginView lView;
        private WebSocket ws;

        // Websocket State -- Alive or Dead
        public bool IsConnect;

        // Session credentials [ username, password ]
        private string[] clientLoginInfo = { "", "" };

        // Delegate post-login -> returns to instance of LoginView
        public delegate void LoginResponseHandler(bool success, string[] info);
        private LoginResponseHandler loginCallback;
        
        // Constructor
        public ClientCommCtrl()
        {

            string clientId = Bid501_Shared.Program.GetLocalIPAddress();
            
            // Build Websocket connection and connect
            ws = new WebSocket($"ws://10.130.160.98:8001/server");
            ws.Connect();

            // Update field to show current websocket connection
            IsConnect = ws.IsAlive;
            Console.WriteLine($"Client Connection: {IsConnect}");
        }

        public void SetView(LoginView lv)
        {
            lView = lv;
        }

        public void Close()
        {
            ws.Close();
            Console.WriteLine("Close: Controller");
        }

        // Redirects messages from the server
        protected override void OnMessage(MessageEventArgs e)
        {
            base.OnMessage(e);
            string[] parts = e.Data.Split(':');
            foreach (string s in parts) Console.WriteLine(s);

            if (parts[0] == "notifylogin")
            {
                bool isValid = bool.Parse(parts[1]);
                loginCallback?.Invoke(isValid, clientLoginInfo);
            }
            else if (parts[0] == "notifytest")
            {
                Console.WriteLine("Received");
            }
        }

        protected override void OnError(ErrorEventArgs e)
        {
            base.OnError(e);
            Console.WriteLine($"Error in Controller: {e.Message}");
        }
         
        #region LOGIN {Stuff}

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
        public bool SendBid(Bid bid, Product product) //Called from BidControl "Attemptbid"
        {
            MessageBox.Show($"Sent to Server {bid.Amount}");
            return true;
        }

        #endregion
    }
}
