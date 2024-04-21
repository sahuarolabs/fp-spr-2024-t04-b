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
    }

    public class ServerCommCtrl : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            string inJSON = e.Data;
            string[] inputs = e.Data.Split(':');
            string id = inputs[0];
            switch(id)
            {
                case "login":

                    break;
                case "logout":

                    break;
                case "newbid":

                    break;
                default:
                    Console.WriteLine("Fuck yourself");
                    break;
            }
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
