﻿using System;
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
            WebSocket ws;
            string ip = "127.0.0.1";
            ws = new WebSocket($"ws://{ip}:8001/server");
            if (ws!=null)
            {
                ws.Close();
            }
            ClientCommCtrl cCtrl = new ClientCommCtrl(ws);
            cCtrl.ws.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginView(cCtrl));
            cCtrl.ws.Close();
        }


    }
}
