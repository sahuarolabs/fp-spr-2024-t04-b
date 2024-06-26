﻿using System;
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
        private AccountController accountController;
        
        public ServerCommCtrl(ServerController sc, AccountController ac)
        {
            serverController = sc;
            accountController = ac;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            JObject jObj = JObject.Parse(e.Data);
            Message.Type msgType = (Message.Type) Enum.Parse(typeof(Message.Type), (string)jObj["MsgType"]);

            switch (msgType) { 
                case Message.Type.LoginRequest:
                    LoginRequest req = JsonConvert.DeserializeObject<LoginRequest>(e.Data);

                    // verify credentials and send back response
                    bool success = accountController.Login(req.Username, req.Password, false);
                    LoginResponse resp = new LoginResponse(success);
                    Send(JsonConvert.SerializeObject(resp));

                    // if the login is unsuccessful, don't register the client and don't send the product list
                    if (!success)
                        break;

                    // update client list
                    accountController.activeAccounts.Add(ID, accountController.FindAccount(req.Username));
                    serverController.RefreshViews();

                    // send product list to newly connected client
                    List<Product> products = serverController.GetProducts();
                    ProductListMsg prodMsg = new ProductListMsg(products);
                    Send(JsonConvert.SerializeObject(prodMsg));

                    break;

                case Message.Type.NewBid:
                    NewBidMsg bidReq = JsonConvert.DeserializeObject<NewBidMsg>(e.Data);

                    // if the bid is valid, send it back to all clients
                    if (serverController.AddBid(bidReq.ProductId, bidReq.BidInfo))
                        NotifyNewBid(bidReq.ProductId, bidReq.BidInfo);

                    break;
            }
        }

        protected override void OnOpen()
        {
            WebSocket socket = this.Context.WebSocket;
            string clientID = ID;

            activeWebsockets.Add(clientID, socket);

            Console.WriteLine($"Client Connected: {ID}");
        }

        protected override void OnClose(CloseEventArgs e)
        {
            accountController.activeAccounts.Remove(ID);
            activeWebsockets.Remove(ID);

            serverController.RefreshViews();

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

        public static void NotifyAuctionEnd(int productId, Bid highestBid)
        {
            AuctionEndMsg endMsg = new AuctionEndMsg(productId, highestBid.Bidder.Username, highestBid.Amount);
            string msg = JsonConvert.SerializeObject(endMsg);

            // notify all clients about the auction end
            foreach (var entry in activeWebsockets)
                entry.Value.Send(msg);
        }        
    }
}
