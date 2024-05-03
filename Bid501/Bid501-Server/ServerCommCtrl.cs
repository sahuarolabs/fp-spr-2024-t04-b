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
    public delegate Dictionary<string, Account> ActiveClientsDel();

    public class ServerCommCtrl : WebSocketBehavior
    {
        // Used to disconnect clients who close websocket connection
        private static Dictionary<string, WebSocket> activeWebsockets = new Dictionary<string, WebSocket>();
        
        // Controller for lower server
        private ServerController serverController;

        // Delegates
        private AddBidDel AddBid;
        private LoginDel LogIn;        
        
        public ServerCommCtrl(ServerController sc, AddBidDel addBidDel, AccountController ac)
        {
            AddBid = addBidDel;
            serverController = sc;
            serverController.accountController = ac;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            JObject jObj = JObject.Parse(e.Data);
            Message.Type msgType = (Message.Type) Enum.Parse(typeof(Message.Type), (string)jObj["MsgType"]);

            switch (msgType) { 
                case Message.Type.LoginRequest:
                    LoginRequest req = JsonConvert.DeserializeObject<LoginRequest>(e.Data);
                    bool success = serverController.accountController.Login(req.Username, req.Password, false);
                    if (success)
                    {
                        serverController.accountController.activeAccounts.Add(ID, serverController.accountController.FindAccount(req.Username));
                        if (serverController.serverView != null) serverController.serverView.UpdateClients();
                    }
                    LoginResponse resp = new LoginResponse(success);
                    Send(JsonConvert.SerializeObject(resp));

                    List<Product> products = serverController.GetProducts();
                    ProductListMsg prodMsg = new ProductListMsg(products);
                    Send(JsonConvert.SerializeObject(prodMsg));
                    break;
                case Message.Type.NewBid:
                    Console.WriteLine("Bid Received");
                    ///FROM
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                        ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };
                    BidRequest bidreq = JsonConvert.DeserializeObject<BidRequest>(e.Data, settings);
                    ///TO
                    //BidRequest bidreq = JsonConvert.DeserializeObject<BidRequest>(e.Data);
                    bool bidsuccess = serverController.AddBid(bidreq.NewBid);
                    NewBidMsg bidMsg = new NewBidMsg(bidsuccess, bidreq.NewBid);
                    Send(JsonConvert.SerializeObject(bidMsg));
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
            serverController.accountController.activeAccounts.Remove(ID);
            if (serverController.serverView != null) serverController.serverView.RefreshView();
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

        /*
        public static void NotifyNewBid(Bid bid)
        {
            NewBidMsg bidMsg = new NewBidMsg(bid);
            string msg = JsonConvert.SerializeObject(bidMsg);

            // notify each of the connected clients of the new bid
            foreach (var entry in activeWebsockets)
                entry.Value.Send(msg);
        }
        */

        // empty
        public static void EndAuction()
        {

        }        
    }
}
