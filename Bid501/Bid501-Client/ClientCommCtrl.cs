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
        public WebSocket ws;

        public ClientCommCtrl()
        {
            #region WebSocket Initialization
            ws = new WebSocket("ws://10.130.160.35:8001/Test");
            ws.Connect();

            #region Check WebSocket Connection
            bool conn = false;
            if (ws.IsAlive)
            {
                conn = true;
            }
            MessageBox.Show("Connection: " + conn);
            #endregion
            #endregion
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
