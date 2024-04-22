﻿
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

    public delegate void AddBidDel(Bid b, Product p);
    public delegate void RefreshViewDel();
    public delegate void AddProductDel(Product p);
    public delegate void EndAuctionDel(Product p);
    public delegate bool logInDel(string name, string pass);

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
            WebSocketServer wss = new WebSocketServer("ws://" + ServerCommCtrl.GetLocalIPAddress() + ":8001");
            wss.AddWebSocketService("/server", () => new ServerCommCtrl(ServerController.AddBid , ServerController.LogIn));
            wss.Start();
            Application.Run(new ServerView());
            wss.Stop();
        } 

    }
}