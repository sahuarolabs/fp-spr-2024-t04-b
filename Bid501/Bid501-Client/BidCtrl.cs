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
        public delegate void MakeBid(Bid bid);

        private BidView bidView;
        ClientCommCtrl cCtrl;
      
        /// <summary>
        /// Constructor for bidcontrol
        /// </summary>
        /// <param name="account">The successfully logged in account</param>
        public BidCtrl(Account account, ClientCommCtrl cCtrl)
        {
            this.cCtrl = cCtrl;
            bidView = new BidView(account, Attemptbid);
            bidView.Show();
        }

        public void UpdateList(List<Product> products)
        {
            bidView.UpdateProductList(products);
        }

        public void UpdateList(Product product)
        {
            bidView.UpdateProductList(product);
        }

        /// <summary>
        /// Comming from Bid View "UxPlaceBid_Click", Checks to see if the Bid is vaild by checking the Product if so it goes to ClientCommCtrl
        /// </summary>
        /// <param name="bid">The Bid being checked</param>
        /// <returns>a bool whether the bid was valid</returns>
        public void Attemptbid(Bid bid) //Called from delegate in Bid View "UxPlaceBid_Click"
        {

            if (bid.Amount > bid.GetProduct.Price)
            {
                cCtrl.SendBid(bid, HandleBidResponse); //Send to ClientCommCtrl Send Bid
            }
            else
            {
                MessageBox.Show($"Did not send {bid.Amount}");
            }
        }

        private void HandleBidResponse(bool isSuccess, Bid bidinfo)
        {
            if (isSuccess)
            {
                //assuming user no admin perms
                bidinfo.GetProduct.Bids.Add(bidinfo);
                bidView.UpdateBids();
            }
        }
    }
}
