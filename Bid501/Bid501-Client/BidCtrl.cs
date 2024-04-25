using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bid501_Client.ClientCommCtrl;

namespace Bid501_Client
{
    public class BidCtrl
    {
        public delegate bool MakeBid(Bid bid, ProductProxy product);

        private SendToServer send;

        BidView bidView;


        public bool Attemptbid(Bid bid, ProductProxy product)
        {

                if (bid.Ammount > product.Price)
                {
                    send(bid, product);
                }
                else
                {
                    MessageBox.Show($"Did not send {bid.Ammount}");
                }
            return false;
        }

        /// <summary>
        /// Constructor for bidcontrol
        /// </summary>
        /// <param name="account">The successfully logged in account</param>
        public BidCtrl(Account account, SendToServer toServer)
        {
            send = toServer;
            bidView = new BidView(Attemptbid);
            bidView.Show();
        }
    }
}
