using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501_Shared;

namespace Bid501_Server
{
    public class ServerController
    {
        private AccountController acctCtrl;
        private Model model;
        private ServerCommCtrl serverComm;
        private RefreshViewDel refreshView;

        public ServerController(AccountController acctCtrl /*, RefreshViewDel refreshViewDel */)
        {
            this.acctCtrl = acctCtrl;
            // this.refreshView = refreshViewDel;
        }

        public bool AfterLoginAction(bool success)
        {
            if (success)
            {
                acctCtrl.SaveAccounts();
                ServerView serverView = new ServerView();
                serverView.Show();
            }
            else
                MessageBox.Show("Invalid credentials!", "Login Error");

            return success;
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
