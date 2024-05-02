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
using System.ComponentModel;

namespace Bid501_Server
{
    public class ServerCommCtrl : WebSocketBehavior
    {
        // Used to disconnect clients who close websocket connection
        private Dictionary<string, WebSocket> activeWebsockets;

        private AddBidDel AddBid;
        private LoginDel LogIn;

        private Model model;

        private ServerController serverController;
        private AccountController accountController;
        
        public ServerCommCtrl(ServerController sc, AddBidDel addBidDel, AccountController ac)
        {
            AddBid = addBidDel;
            accountController = ac;
            serverController = sc;
            activeWebsockets = new Dictionary<string, WebSocket>();
            //activeAccounts = new Dictionary<string, Account>();
            serverController.SetDelegates(NotifyNewProduct);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            string inJSON = e.Data;
            string[] inputs = e.Data.Split(':');
            string clientID = ID;

            foreach (string s in inputs) Console.WriteLine(s);

            switch(inputs[0])
            {
                case "login": //FIX: not adding new account to acnts.json
                    Account account = accountController.ClientLogin(inputs[1], inputs[2], false, clientID);
                    if (account != null)
                    {
                        accountController.activeAccounts.Add(clientID, account);
                        activeWebsockets[ID].Send("notifylogin:True");
                        Console.WriteLine(accountController.activeAccounts[clientID].Username);
                    }
                    else
                    {
                        activeWebsockets[ID].Send("notifylogin:False"); 
                    }
                    break;
                case "IP":
                    Send("notifytest");
                    break;
                case "logout":

                    break;
                case "newbid":

                    break;
                default:
                    break;
            }
        }

        // NEEDS: add clientIP to Dictionary of connected clients
        protected override void OnOpen()
        {
            WebSocket socket = this.Context.WebSocket;
            string clientID = ID;

            activeWebsockets.Add(clientID, socket);

            Console.WriteLine($"Client Connected: {ID}");
        }

        // generic imp, needs to be changed
        protected override void OnClose(CloseEventArgs e)
        {

            Console.WriteLine($"ClientDisconnected: {ID}");
            base.OnClose(e);
        }

        // empty
        public void NotifyNewProduct()
        {

        }

        // empty
        public void NotifyNewBid()
        {

        }

        // empty
        public void EndAuction()
        {

        }

        public BindingList<string> GiveConnectedClients()
        {
            BindingList<string> connectedClients = new BindingList<string>();

            foreach(KeyValuePair<string, WebSocket> client in activeWebsockets)
            {
                connectedClients.Add(client.Key);
            }

            return connectedClients;
        }
        
    }
}
