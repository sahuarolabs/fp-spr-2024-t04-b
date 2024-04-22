using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using static Bid501_Server.Program;
using System.Windows.Forms;
using Bid501_Shared;

namespace Bid501_Server
{
    public class ServerCommCtrl : WebSocketBehavior
    {

        private Model model;

        private AddBidDel AddBid;

        private Dictionary<User, WebSocket> clients;

        private logInDel LogIn;

        public ServerCommCtrl(AddBidDel addBidDel, logInDel logInDel)
        {
            AddBid = addBidDel;
            LogIn = logInDel;
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

        protected override void OnMessage(MessageEventArgs e)
        {
            string inJSON = e.Data;
            string[] inputs = e.Data.Split(':');
            string id = inputs[0];
            switch(id)
            {
                case "login":

                    break;
                case "logout":

                    break;
                case "newbid":

                    break;
                default:
                    Console.WriteLine("Fuck yourself");
                    break;
            }
        }

        protected override void OnOpen()
        {

        }

        public void NotifyNewProduct()
        {

        }

        public void NotfyNewBid()
        {

        }

        public void EndAuction()
        {

        }

        public Dictionary<User, WebSocket> GetClients()
        {
            return clients;
        }

        
    }

}
