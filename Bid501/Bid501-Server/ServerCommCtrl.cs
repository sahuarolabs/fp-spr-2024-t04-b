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
using Newtonsoft.Json.Linq;
using Message = Bid501_Shared.Message;

namespace Bid501_Server
{
    public class ServerCommCtrl : WebSocketBehavior
    {
        // Used to disconnect clients who close websocket connection
        private Dictionary<string, WebSocket> activeWebsockets;

        private AddBidDel AddBid;
        private LoginDel LogIn;

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
            JObject jObj = JObject.Parse(e.Data);
            Message.Type msgType = (Message.Type) Enum.Parse(typeof(Message.Type), (string)jObj["MsgType"]);

            switch (msgType) { 
                case Message.Type.LoginRequest:
                    LoginRequest req = JsonConvert.DeserializeObject<LoginRequest>(e.Data);
                    bool success = accountController.Login(req.Username, req.Password, false);
                    LoginResponse resp = new LoginResponse(success);
                    activeWebsockets[ID].Send(JsonConvert.SerializeObject(resp));

                    List<Product> products = serverController.GetProducts();
                    ProductListMsg prodMsg = new ProductListMsg(products);
                    activeWebsockets[ID].Send(JsonConvert.SerializeObject(prodMsg));
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
