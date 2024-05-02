using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace Bid501_Client
{
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

            cCtrl.SetView(loginView);

            // Run view and close when application's done running view
            Application.Run(loginView);
            cCtrl.Close();
        }
    }
}
