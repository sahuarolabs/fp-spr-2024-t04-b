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

        public ClientCommCtrl(WebSocket ws)
        {
            this.ws = ws;
            this.ws.OnMessage += OnMessageHandler;
        }

        public void OnMessageHandler(object sender, MessageEventArgs e)
        {
            //e.Data = 
        }
         
        /// <summary>
        /// Sends a bid from bidctrl to websocket for the server to check
        /// </summary>
        /// <param name="bid">The bid added from bidctrl</param>
        public void SendBid(Bid bid, IProduct product)
        {
            MessageBox.Show($"Sent to Server {bid.Ammount}");
        }

        /// <summary>
        /// FIX:
        /// Working on 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool handleLogin(string username, string password)
        {
            bool i = false;
            ws.OnMessage += (sender, e) =>
                i = Convert.ToBoolean(e.Data);

            Console.WriteLine(i);
            MessageBox.Show("Login: " + i);
            if(true) //replace true with i whenever we get to actually do logins
            {
                bidCtrl = new BidCtrl(new Account("Dummy", "Password", new List<Permission>()), SendBid);
            }
            return i;
        }
    }
}
