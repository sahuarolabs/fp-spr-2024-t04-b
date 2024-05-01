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
using System.Runtime.CompilerServices;

namespace Bid501_Server
{
    public class ServerCommCtrl : WebSocketBehavior
    { 
        private AddBidDel AddBid;
        private LoginDel LogIn;

        private List<Account> Accounts = new List<Account>();
        private Dictionary<string, Account> clients;

        private Model model;

        private ServerController serverController;
        
        public ServerCommCtrl(AddBidDel addBidDel, LoginDel logInDel)
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
                case "IP":
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

        // NEEDS: add clientIP to Dictionary of connected clients
        protected override void OnOpen()
        {
            base.OnOpen();
            var clientId = this.Context.QueryString["id"];
            Console.WriteLine($"Client {clientId} connected with ID: {ID}");
        }

        // generic imp, needs to be changed
        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine("ClientDisconnected: " + e);
            base.OnClose(e);
        }

        // empty
        public void NotifyNewProduct()
        {

        }

        // empty
        public void NotfyNewBid()
        {

        }

        // empty
        public void EndAuction()
        {

        }

        public Dictionary<string, Account> GetClients()
        {
            return clients;
        }  
        
    }
}
