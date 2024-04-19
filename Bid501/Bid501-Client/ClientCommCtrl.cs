using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using Bid501_Shared;
using System.Runtime.Remoting.Messaging;

namespace Bid501_Client
{
    public class ClientCommCtrl
    {
        public WebSocket ws;

        public ClientCommCtrl(WebSocket ws)
        {
            this.ws = ws;
        }

        /// <summary>
        /// FIX:
        /// Working on 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool handleLogin(string username, string password)
        {
            bool i = false;
            ws.OnMessage += (sender, e) =>
                i = Convert.ToBoolean(e.Data);
            return i;
        }
    }
}
