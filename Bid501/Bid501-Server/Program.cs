
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
    public delegate bool LoginDel(string username, string password, bool client);
    public delegate bool AfterLoginActionDel(bool success);
    public delegate Dictionary<User, WebSocket> GetClientsDel();

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

            AccountController acctCtrl = new AccountController("accounts.json");
            Model model = ServerController.LoadModelFromFile("model.json");
            ServerController servCtrl = new ServerController(acctCtrl, model);
            LoginView loginView = new LoginView(acctCtrl.Login, servCtrl.AfterLoginAction);

            Application.Run(loginView);

            /*
            WebSocketServer wss = new WebSocketServer("ws://" + ServerCommCtrl.GetLocalIPAddress() + ":8001");
            ServerController serverCtrl = new ServerController(ServerView.RefreshView);
            ServerCommCtrl scc = new ServerCommCtrl(serverCtrl.AddBid, serverCtrl.LogIn);
            wss.AddWebSocketService("/server", () => scc);
            wss.Start();
            Application.Run(new ServerView(scc.GetClients));
            wss.Stop();
            */
        } 

    }
}