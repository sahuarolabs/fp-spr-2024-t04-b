
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using Bid501_Shared;

namespace Bid501_Server
{

    //public delegate void AddBidDel(Bid, Product);
    public delegate void RefreshViewDel();
    //public delegate void AddProductDel(Product);
    //public delegate void EndAuctionDel(Product);

    public class Program
    {
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WebSocketServer wss = new WebSocketServer(ServerCommCtrl.GetLocalIPAddress());
            wss.AddWebSocketService("/server", () => new ServerCommCtrl());
            wss.Start();
            Application.Run(new ServerView());
            wss.Stop();
        } 

    }
}