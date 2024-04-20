using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Channels;
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

        public ServerCommCtrl()
        {

            WebSocketServer wss = new WebSocketServer("ws://127.0.0.1:8001");
            wss.AddWebSocketService<TestService>("/Test");
            wss.Start();
            wss.OnMessage += OnMessageHandler();

        }

        protected override void OnOpen()
        {

        }

        protected void OnMessageHandler(MessageEventArgs e)
        {
            Console.WriteLine("" + e);
            Send("True");
        }

        public void NotifyNewProduct()
        {

        }

        public void NotifyNewBid()
        {

        }

        public void EndAuction()
        {

        }

    }
}
