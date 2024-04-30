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
            string clientId = GetLocalIPAddress();
            this.ws = ws = new WebSocket($"ws://10.130.160.136:8001/server?id={clientId}");
            ws.OnMessage += OnMessageHandler;
            ws.OnError += OnErrorHandler;
            this.ws.OnOpen += OnOpen;
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
            else if (parts[0] == "notifytest")
            {
                Console.WriteLine("Received");
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    MessageBox.Show(ip.ToString());
                    return ip.ToString();
                }
            }
            MessageBox.Show("No network adapters with an IPv4 address in the system!");
            return "";
        }

        private void OnErrorHandler(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"Error in Controller: {e.Message}");
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

        public void OnOpen(object sender, EventArgs e)
        {
            //ws.Send("IP:"+GetLocalIPAddress());
        }

        #region BID Stuff
        /// <summary>
        /// Gets a bid from BidCtrl "Attemptbid", Sends that bid to the server to verify that bid is good
        /// </summary>
        /// <param name="bid">The bid added from bidctrl</param>
        /// <returns>A bool for if the bid was verified</returns>
        public bool SendBid(Bid bid, IProduct product) //Called from BidControl "Attemptbid"
        {
            MessageBox.Show($"Sent to Server {bid.Amount}");
            return true;
        }

        #endregion
    }
}
