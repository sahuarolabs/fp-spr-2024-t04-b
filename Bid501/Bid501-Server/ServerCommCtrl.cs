using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using static Bid501_Server.Program;

namespace Bid501_Server
{

    //make region for 'services'
    public class TestService : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Received from client: " + e.Data);

            Send("Data from server");
        }

        protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        {
            // do nothing
        }
    }

    public class ServerCommCtrl : WebSocketBehavior
    {

        //private model Model;

        //private addBidDel AddBid;

        //private Dictionary<user,websocket>

        //private logInDel LogIn;

        private WebsocketServer wss;

        public ServerCommCtrl()
        {

            wss = new WebSocketServer("ws://10.130.160.36:8001");
            wss.AddWebSocketService<TestService>("/Test");
            wss.Start();

        }

        protected void OnOpen()
        {

        }

        protected void OnMessage(MessageEventArgs e)
        {

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

        public void EndConnection()
        {
            wss.Stop();
        }

    }
}
