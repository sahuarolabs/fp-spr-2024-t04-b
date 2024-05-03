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

        // View and Websocket for ClientComm instance
        private LoginView lView;
        private WebSocket ws;

        // Websocket State -- Alive or Dead
        public bool IsConnect;

        // Session credentials [ username, password ]
        private string[] clientLoginInfo = { "", "" };

        // Delegate post-login -> returns to instance of LoginView
        public delegate void LoginResponseHandler(bool success, string[] info);
        private LoginResponseHandler loginCallback;
        
        // Constructor
        public ClientCommCtrl()
        {          
            // Build Websocket connection and connect
            ws = new WebSocket($"ws://10.130.160.109:8001/server");

            ws.OnMessage += OnMessageHandler;
            ws.Connect();

            // Update field to show current websocket connection
            IsConnect = ws.IsAlive;
            Console.WriteLine($"Client Connection: {IsConnect}");
        }

        public void SetView(LoginView lv)
        {
            lView = lv;
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
                    loginCallback?.Invoke(resp.Success, clientLoginInfo);
                    break;

                case Message.Type.ProductList:
                    ProductListMsg prodMsg = JsonConvert.DeserializeObject<ProductListMsg>(e.Data);
                    UpdateBidViewList(prodMsg.Products);
                    break;

                case Message.Type.NewProduct:
                    NewProductMsg newProdMsg = JsonConvert.DeserializeObject<NewProductMsg>(e.Data);
                    // TODO: add the product to the client's list
                    break;
            }
        }

        protected override void OnError(ErrorEventArgs e)
        {
            base.OnError(e);
            Console.WriteLine($"Error in Controller: {e.Message}");
        }
        
        private void UpdateBidViewList(List<Product> products)
        {
            lView.bCtrl.UpdateList(products);
        }

        #region LOGIN {Stuff}

        public void sendLogin(string username, string password, LoginResponseHandler callback)
        {
            clientLoginInfo[0] = username;
            clientLoginInfo[1] = password;

            LoginRequest req = new LoginRequest(username, password);
            string msg = JsonConvert.SerializeObject(req);

            ws.Send(msg);

            this.loginCallback = callback;

        }
        #endregion

        #region BID Stuff
        /// <summary>
        /// Gets a bid from BidCtrl "Attemptbid", Sends that bid to the server to verify that bid is good
        /// </summary>
        /// <param name="bid">The bid added from bidctrl</param>
        /// <returns>A bool for if the bid was verified</returns>
        public bool SendBid(Bid bid, Product product) //Called from BidControl "Attemptbid"
        {
            MessageBox.Show($"Sent to Server {bid.Amount}");
            return true;
        }

        #endregion
    }
}
