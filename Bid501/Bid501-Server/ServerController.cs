using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;

namespace Bid501_Server
{
    public class ServerController
    {

        private Model model;

        private ServerCommCtrl serverComm;

        private RefreshViewDel refreshView;


        public ServerController(RefreshViewDel refreshViewDel)
        {
            refreshView = refreshViewDel;
        }


        public void AddBid(Bid b, Product p)
        {

        }

        public bool LogIn(string user, string pass)
        {
            return true;
        }
    }
}
