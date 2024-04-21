using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using static Bid501_Server.Program;
using System.Windows.Forms;

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

        private string hostIP;

        private WebSocketServer wss;

        public ServerCommCtrl()
        {
            // this will need to change.
            hostIP = GetLocalIPAddress();
            wss = new WebSocketServer(hostIP);
            MessageBox.Show(hostIP);
            wss.AddWebSocketService<TestService>("/Test");
            wss.Start();

        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    hostIP = ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public void CloseServer()
        {
            wss.Stop();
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
