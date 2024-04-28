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

        BidView bidView;
        ClientCommCtrl cCtrl;


        public bool Attemptbid(Bid bid, ProductProxy product)
        {

                if (bid.Ammount > product.Price)
                {
                    cCtrl.SendBid(bid, product);
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
        public BidCtrl(Account account, ClientCommCtrl cCtrl)
        {
            this.cCtrl = cCtrl;
            bidView = new BidView(Attemptbid);
            bidView.Show();
        }
    }
}
