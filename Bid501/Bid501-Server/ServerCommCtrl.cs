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
        private static Dictionary<string, WebSocket> activeWebsockets = new Dictionary<string, WebSocket>();

        private AddBidDel AddBid;
        private LoginDel LogIn;

        private ServerController serverController;
        private AccountController accountController;
        
        public ServerCommCtrl(ServerController sc, AddBidDel addBidDel, AccountController ac)
        {
            AddBid = addBidDel;
            accountController = ac;
            serverController = sc;
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
                    Send(JsonConvert.SerializeObject(resp));

                    List<Product> products = serverController.GetProducts();
                    ProductListMsg prodMsg = new ProductListMsg(products);
                    Send(JsonConvert.SerializeObject(prodMsg));
                    break;
                case Message.Type.NewBid:
                    // Console.WriteLine("Bid Received");
                    NewBidMsg bidReq = JsonConvert.DeserializeObject<NewBidMsg>(e.Data);

                    // if the bid is valid, send it back to all clients
                    NotifyNewBid(bidReq.ProductId, bidReq.BidInfo);
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
            activeWebsockets.Remove(ID);
            Console.WriteLine($"ClientDisconnected: {ID}");
            base.OnClose(e);
        }

        public static void NotifyNewProduct(Product newProd)
        {
            NewProductMsg prodMsg = new NewProductMsg(newProd);
            string msg = JsonConvert.SerializeObject(prodMsg);

            // notify each of the connected clients of the new product
            foreach (var entry in activeWebsockets)
                entry.Value.Send(msg);
        }

        public static void NotifyNewBid(int productId, Bid bid)
        {
            NewBidMsg bidMsg = new NewBidMsg(productId, bid);
            string msg = JsonConvert.SerializeObject(bidMsg);

            // notify each of the connected clients of the new bid
            foreach (var entry in activeWebsockets)
                entry.Value.Send(msg);
        }

        // empty
        public static void EndAuction()
        {

        }

        public static BindingList<string> GiveConnectedClients()
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
