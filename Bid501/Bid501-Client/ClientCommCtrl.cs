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
        ClientViews
        public WebSocket ws;
        BidCtrl bidCtrl;
        public delegate void SendToServer(Bid bid, ProductProxy product);
        // TestMergeMain

        public ClientCommCtrl(WebSocket ws)
        {
            this.ws = ws;
            this.ws.OnMessage += OnMessageHandler;
        }

        public void OnMessageHandler(object sender, MessageEventArgs e)
        {
            string msg = e.Data;
            string[] strings = msg.Split(':');
            string id = strings[0];

            switch(id)
            {
                case "notifylogin":
                    receiveLogin(strings[1]);
                    break;
            }
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
        public void sendLogin(string username, string password)
        {
            bool i = false;
            
        }

        public bool receiveLogin(string valid)
        {
            ClientViews
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
