using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace Bid501_Client
{
    public class ClientCommCtrl
    {
        public WebSocketSharp.WebSocket ws;

        public ClientCommCtrl()
        {
            ws = new WebSocketSharp.WebSocket("ws://10.130.160.35:8001/Test");
            ws.Connect();

            //Check Alive
            bool conn = false;
            if (ws.IsAlive)
            {
                conn = true;
            }
            MessageBox.Show("Connection: " + conn);
        }

        public void SendMessage(string message)
        {
            if (ws.IsAlive)
            {
                MessageBox.Show("1");
                ws.Send(message);
                Console.WriteLine("Sent Message");
            }
            else
            {
                MessageBox.Show("0");
                Console.WriteLine("WebSocket is not connected.");
            }
        }
    }
        
    }
}
