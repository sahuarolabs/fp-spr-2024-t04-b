
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using Bid501_Shared;
using System.ComponentModel;

namespace Bid501_Server
{
    public delegate bool AddBidDel(Bid b, Product p);
    public delegate void RefreshViewDel();
    public delegate void AddProductDel(Product p);
    public delegate void EndAuctionDel(Product p);
    public delegate bool LoginDel(string username, string password, bool client);
    public delegate bool AfterLoginActionDel(bool success);
    public delegate void SaveModelDel();
    public delegate BindingList<string> GetClientsDel();

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
            ServerController serverCtrl = new ServerController(acctCtrl, "model.json");
            ServerCommCtrl servCommCtrl = new ServerCommCtrl(serverCtrl, serverCtrl.AddBid, acctCtrl);
            LoginView loginView = new LoginView(acctCtrl, serverCtrl);
            loginView.SetLoginDelegates(acctCtrl.Login, serverCtrl.AfterLoginAction);

            serverCtrl.ServerComm = servCommCtrl;
            serverCtrl.setGetClientsDel(servCommCtrl.GiveConnectedClients);
            //WebSocketServer wss = new WebSocketServer($"ws://{Bid501_Shared.Program.GetLocalIPAddress()}:8001");
            WebSocketServer wss = new WebSocketServer("ws://10.130.160.107:8001");
            wss.AddWebSocketService<ServerCommCtrl>("/server", () => servCommCtrl);\
            wss.ReuseAddress = true;
            wss.Start(); 

            Application.Run(loginView);
            wss.Stop();
            
        } 

    }
}