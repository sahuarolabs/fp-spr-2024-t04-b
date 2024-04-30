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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginView view = new LoginView();
            ClientCommCtrl cCtrl = new ClientCommCtrl(view);
            view.SetController(cCtrl);
            Application.Run(view);
            cCtrl.Close();
            Console.WriteLine("Close: Program");
        }


    }
}
