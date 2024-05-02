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
        // Used to disconnect clients who close websocket connection
        private Dictionary<string, WebSocket> activeWebsockets;
        // Used to associate accounts with a matching ID in above Dict<>
        private Dictionary<string, Account> activeAccounts;


        private AddBidDel AddBid;
        private LoginDel LogIn;

        private Model model;

        private ServerController serverController;
        
        public ServerCommCtrl(ServerController sc, AddBidDel addBidDel, LoginDel logInDel)
        {
            AddBid = addBidDel;
            LogIn = logInDel;
            serverController = sc;
            activeWebsockets = new Dictionary<string, WebSocket>();
            activeAccounts = new Dictionary<string, Account>();
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (activeWebsockets.ContainsKey(ID))
            {
                Console.WriteLine("ID exists in active websockets");
                Console.Write("Websocket is ");
                if (activeWebsockets[ID].ReadyState == WebSocketState.Open) Console.WriteLine("Ready"); else Console.WriteLine("Closed");
            }
            string inJSON = e.Data;
            string[] inputs = e.Data.Split(':');
            string clientID = ID;

            Console.WriteLine($"Message from Client: {ID}");

            foreach (string s in inputs) Console.WriteLine(s);

            switch(inputs[0])
            {
                case "login": //FIX: not adding new account to acnts.json
                    //FIX: 
                    if (LogIn(inputs[1], inputs[2], false))
                    {
                        Console.WriteLine("CLIENT LOGIN SUCCESS");
                        activeWebsockets[ID].Send("notifylogin:True");
                    }
                    else
                    {
                        activeWebsockets[ID].Send("notifylogin:False"); 
                        Console.WriteLine("CLIENT LOGIN FAILURE");
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
        
    }
}
