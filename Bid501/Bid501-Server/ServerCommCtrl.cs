using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    MessageBox.Show(ip.ToString());
                    return ip.ToString();
                }
            }
            MessageBox.Show("No network adapters with an IPv4 address in the system!");
            return "";
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            string inJSON = e.Data;
            string[] inputs = e.Data.Split(':');
            switch (inputs[0])
            {

            }
        }

        public void CloseServer()
        {
            wss.Stop();
        }

        protected void OnOpen()
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


    }

}
