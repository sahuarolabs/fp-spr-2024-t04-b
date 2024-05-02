using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501_Shared;
using static Bid501_Client.BidCtrl;

namespace Bid501_Client
{
    public partial class BidView : Form
    {
        private MakeBid makeBid;

        private Account UserAccount;
        
        //Automatically assuming accounts are users and not admins, BEWARE
        //When Server is fully connected delete         V from this brace to the ;
        public List<Product> List = new List<Product>() { new Product(1, "Hotdog", 999.00, new Account("a", "b", false)), new Product(1, "Hamdog", 0.10, new Account("a", "b", false))};

        public BidView(Account account, MakeBid make, List<Product> products)
        {
            makeBid = make;
            UserAccount = account;
            InitializeComponent();
            List = products;
            UxProductListBox.DataSource = List;
        }

        public void UpdateProductList(List<Product> productList)
        {
            List = productList;
            UxProductListBox.DataSource = List;
        }

        /// <summary>
        /// Checks to see if the text box has a vaild number and sends it to the delegate makeBid to BidCtrl "AttemptBid"
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">the Event Args</param>
        private void UxPlaceBid_Click(object sender, EventArgs e)
        {
            if (UxNewBidTextBox.Text == "") MessageBox.Show("Please enter a value!");
            else
            {
                try
                {
                    double suggested = Math.Round(Convert.ToDouble(UxNewBidTextBox.Text), 2);
                    makeBid(new Bid(UserAccount, suggested), List[UxProductListBox.SelectedIndex]); //Delegate to BidCtrl AttemptBid
                }
                catch { MessageBox.Show("Please enter a valid number (0.00)"); }
            }
            
        }

        /// <summary>
        /// When a different product is selected in the list update everything
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void UxProductListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = UxProductListBox.SelectedIndex;
            UxProductName.Text = List[index].Name;
            if (List[index].Expired) UxStatusLabel.Text = "Bid is closed.";
            else UxStatusLabel.Text = "Open Bid";
            UxCurrentPriceTextBox.Text = String.Format("Current Price: {0:C}", List[index].Price);
            UxBidCount.Text = $"Currently: {List[index].Bids.Count.ToString()} Bids";
        }

        /// <summary>
        /// Logs out of the account
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void UxLogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
