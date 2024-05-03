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
using System.Windows.Forms.VisualStyles;
using System.Runtime.CompilerServices;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Message = Bid501_Shared.Message;

namespace Bid501_Client
{
    public class ClientCommCtrl : WebSocketBehavior
    {
        // Websocket for ClientComm instance
        private WebSocket ws;

        // Session credentials [ username, password ]
        public string[] Credentials = { "", "" };
        public bool IsConnect = false;
        public BidCtrl BidController { get; set; }

        // Constructor
        public ClientCommCtrl()
        {
            // Build Websocket connection and connect
            ws = new WebSocket($"ws://10.130.160.107:8001/server");


            ws.OnMessage += OnMessageHandler;
            ws.Connect();

            IsConnect = ws.IsAlive;
        }

        public void Close()
        {
            ws.Close();
            Console.WriteLine("Close: Controller");
        }

        // Redirects messages from the server
        public void OnMessageHandler(object sender, MessageEventArgs e)
        {
            base.OnMessage(e);

            JObject jObj = JObject.Parse(e.Data);
            Message.Type msgType = (Message.Type) Enum.Parse(typeof(Message.Type), (string)jObj["MsgType"]);

            switch (msgType)
            {
                case Message.Type.LoginResponse:
                    LoginResponse resp = JsonConvert.DeserializeObject<LoginResponse>(e.Data);
                    BidController.HandleLoginResponse(resp.Success);
                    break;

                case Message.Type.ProductList:
                    ProductListMsg prodMsg = JsonConvert.DeserializeObject<ProductListMsg>(e.Data);
                    BidController.UpdateList(prodMsg.Products);
                    break;

                case Message.Type.NewProduct:
                    NewProductMsg newProdMsg = JsonConvert.DeserializeObject<NewProductMsg>(e.Data);
                    BidController.UpdateList(newProdMsg.Prod);
                    break;

                case Message.Type.NewBid:
                    NewBidMsg newBidMsg = JsonConvert.DeserializeObject<NewBidMsg>(e.Data);
                    BidController.AddNewBid(newBidMsg.ProductId, newBidMsg.BidInfo);
                    break;
            }
        }

        protected override void OnError(ErrorEventArgs e)
        {
            base.OnError(e);
            Console.WriteLine($"Error in Controller: {e.Message}");
        }

        #region LOGIN {Stuff}

        public void sendLogin(string username, string password)
        {
            Credentials[0] = username;
            Credentials[1] = password;

            LoginRequest req = new LoginRequest(username, password);
            string msg = JsonConvert.SerializeObject(req);

            ws.Send(msg);

        }
        #endregion

        #region BID Stuff
        /// <summary>
        /// Gets a bid from BidCtrl "Attemptbid", Sends that bid to the server to verify that bid is good
        /// </summary>
        /// <returns>A bool for if the bid was verified</returns>
        public void SendBid(int productId, Bid bid) //Called from BidControl "Attemptbid"
        {
            NewBidMsg bidMsg = new NewBidMsg(productId, bid);
            string msg = JsonConvert.SerializeObject(bidMsg);
            ws.Send(msg);
        }

        #endregion
    }
}
