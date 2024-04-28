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

        public List<ProductProxy> List = new List<ProductProxy>() { new ProductProxy(1,"Hotdog",999.00,new Account("a","b",false)), new ProductProxy(1, "Hamdog", 0.10, new Account("a", "b", false))};

        public BidView(MakeBid make)
        {
            makeBid = make;
            InitializeComponent();
            //UxProductListBox.DataSource = List;
        }

        private void UxPlaceBid_Click(object sender, EventArgs e)
        {
            if (UxNewBidTextBox.Text == "") MessageBox.Show("Please enter a value!");
            else
            {
                try
                {
                    double suggested = Math.Round(Convert.ToDouble(UxNewBidTextBox.Text), 2);
                    makeBid(new Bid(new Account("a", "b", false), suggested), List[UxProductListBox.SelectedIndex]);
                }
                catch { MessageBox.Show("Please enter a valid number (0.00)"); }
            }
            
        }

        private void UxProductListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = UxProductListBox.SelectedIndex;
            UxProductName.Text = List[index].Name;
            if (List[index].Expired) UxStatusLabel.Text = "Bid is closed.";
            else UxStatusLabel.Text = "Open Bid";
            UxCurrentPriceTextBox.Text = String.Format("Current Price: {0:C}", List[index].Price);
            UxBidCount.Text = $"Currently: {List[index].Bids.Count.ToString()} Bids";
        }

        private void UxLogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
