using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bid501_Client.ClientCommCtrl;

namespace Bid501_Client
{
    public class BidCtrl
    {
        private ClientCommCtrl cCtrl;
        private BidView bidView;
        private List<Product> products;
        private LoginView loginView;

        public Account LoggedUser { get; set; }

        /// <summary>
        /// Constructor for bidcontrol
        /// </summary>
        /// <param name="account">The successfully logged in account</param>
        public BidCtrl(ClientCommCtrl cCtrl, LoginView loginView)
        {
            this.cCtrl = cCtrl;
            this.loginView = loginView;
            products = new List<Product>();
        }

        public void HandleLoginResponse(bool success)
        {
            loginView.Invoke(new Action(() =>
            {
                if (success)
                {
                    LoggedUser = new Account(cCtrl.Credentials[0], cCtrl.Credentials[1], false);
                    bidView = new BidView(PlaceBid);
                    bidView.Show();
                }
                else
                    MessageBox.Show("Invalid credentials!", "Login Error");
            }));
        }

        public void PlaceBid(Product product, double amount)
        {
            Bid bid = new Bid(LoggedUser, amount);

            if (amount > product.Price)
                cCtrl.SendBid(product.Id, bid);
            else
                MessageBox.Show($"Did not send {bid.Amount}");
        }

        public void UpdateList(List<Product> products)
        {
            this.products = products;
            if (bidView != null) bidView.UpdateProductList(this.products);
        }

        public void UpdateList(Product product)
        {
            products.Add(product);
            bidView.UpdateProductList(products);
        }

        public void AddNewBid(int productId, Bid bid)
        {
            Product product = products.Find(prod => prod.Id == productId);
            if (product != null)
            {
                product.Bids.Add(bid);
                bidView.UpdateBids();
            }
        }

        public void HandleAuctionEnd(int productId, string winner, double finalPrice)
        {
            Product product = products.Find(prod => prod.Id == productId);
            if (product == null)
                return;

            // set the product as expired
            product.Expired = true;
            bidView.UpdateBids();

            // alert the user if he won
            if (LoggedUser.Username == winner)
            {
                bidView.Invoke(new Action(() =>
                {
                    MessageBox.Show($"You've won the auction for {product.Name} for {finalPrice:0.00} $");
                }));
            }
        }
    }
}
