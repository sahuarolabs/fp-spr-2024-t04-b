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
        
        private LoginView lView;
        private WebSocket ws;

        private string[] clientLoginInfo = { "", "" };
        public delegate void LoginResponseHandler(bool success, string[] info);
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

        #region LOGIN SHIT

        public void sendLogin(string username, string password, LoginResponseHandler callback)
        {
            clientLoginInfo[0] = username; 
            clientLoginInfo[1] = password;
            string x = $"login:{username}:{password}";

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
