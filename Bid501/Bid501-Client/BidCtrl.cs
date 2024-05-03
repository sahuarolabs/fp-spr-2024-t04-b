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
        public delegate bool MakeBid(Bid bid, Product product);

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
        /// <param name="product">The Product being bid on</param>
        /// <returns>a bool whether the bid was valid</returns>
        public bool Attemptbid(Bid bid, Product product) //Called from delegate in Bid View "UxPlaceBid_Click"
        {

            if (bid.Amount > product.Price)
            {
                return cCtrl.SendBid(bid, product); //Send to ClientCommCtrl Send Bid
            }
            else
            {
                MessageBox.Show($"Did not send {bid.Amount}");
            }
            return false;
        }
    }
}
