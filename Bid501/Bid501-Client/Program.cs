using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace Bid501_Client
{
    public delegate void HandleLoginResponseDel(bool success);
    public delegate bool PlaceBidDel(Product product, double amount);

    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize: LoginView, ClientCommCtrl and set 
            // initialized controller to the instance of the loginView
            ClientCommCtrl cCtrl = new ClientCommCtrl();
            LoginView loginView = new LoginView(cCtrl);
            BidCtrl bCtrl = new BidCtrl(cCtrl, loginView);
            cCtrl.BidController = bCtrl;

            // Run view and close when application's done running view
            Application.Run(loginView);
            cCtrl.Close();
        }
    }
}
