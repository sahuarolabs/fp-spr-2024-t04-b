using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using Bid501_Shared;
using System.IO;
using Newtonsoft.Json;

namespace Bid501_Server
{
    public class ServerCommCtrl : WebSocketBehavior
    { 
        private AddBidDel AddBid;
        private logInDel LogIn;

        private List<Account> Accounts = new List<Account>();
        private Dictionary<User, WebSocket> clients;
        private Model model;

        private ServerController serverController;
        
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
                    Send("notifylogin:True");
                    break;
                case "test":
                    Send("notifytest");
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
            Console.WriteLine("ClientConnected ");
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine("ClientDisconnected: " + e);
            base.OnClose(e);
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
