using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Bid501_Server
{
    internal static class Program
    {
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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Still looking to get this working on multiple computers :)
            WebSocketServer wss = new WebSocketServer("ws://10.130.160.36:8001");
            wss.AddWebSocketService<TestService>("/Test");
            wss.Start();
            //Console.OpenStandardInput();
            //Console.ReadKey(true);
            Application.Run(new ServerView());
            wss.Stop();
        }

    }
}