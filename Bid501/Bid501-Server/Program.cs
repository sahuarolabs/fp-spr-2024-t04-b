
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
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Still looking to get this working on multiple computers :)
            
            //Console.OpenStandardInput();
            //Console.ReadKey(true);
            Application.Run(new ServerView());
        }

    }
}