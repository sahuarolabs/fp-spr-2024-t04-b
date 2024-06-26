﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501_Shared;
using static Bid501_Client.BidCtrl;

namespace Bid501_Client
{
    public partial class BidView : Form
    {
        private PlaceBidDel placeBid;

        public BidView(PlaceBidDel placeBid)
        {
            this.placeBid = placeBid;

            InitializeComponent();
        }

        public void UpdateProductList(List<Product> productList)
        {
            UxProductListBox.BeginInvoke(new Action(() =>
            {
                UxProductListBox.Items.Clear();
                foreach (Product p in productList)
                {
                    UxProductListBox.Items.Add(p);
                }
                UpdateBids();
            }));
        }

        public void UpdateProductList(Product product)
        {
            UxProductListBox.BeginInvoke(new Action(() =>
            {
                UxProductListBox.Items.Add(product);
            }));
        }

        /// Checks to see if the text box has a vaild number and sends it to the delegate makeBid to BidCtrl "AttemptBid"
        private void UxPlaceBid_Click(object sender, EventArgs e)
        {
            if (UxNewBidTextBox.Text == "")
                UxMessageBox.Text = "Please enter a value!";
            else
            {
                try
                {
                    // round to 1/100's
                    double suggested = Math.Round(Convert.ToDouble(UxNewBidTextBox.Text), 2);
                    Product selProd = (Product) UxProductListBox.SelectedItem;

                    if (placeBid(selProd, suggested)) //Delegate to BidCtrl AttemptBid
                    {
                        UxMessageBox.Text = "";
                    }
                    else UxMessageBox.Text = $"Did not send the bid {suggested}";

                }
                catch
                {
                    UxMessageBox.Text = "Please enter a valid number (0.00)";
                }
            }
        }

        /// When a different product is selected in the list update everything
        private void UxProductListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = UxProductListBox.SelectedIndex;
            if (index >= 0 && index < UxProductListBox.Items.Count)
            {
                Product selectedProduct = UxProductListBox.Items[index] as Product;
                if (selectedProduct != null)
                {
                    UxProductName.Text = selectedProduct.Name;
                    if (selectedProduct.Expired)
                        UxStatusLabel.Text = "Bid is closed.";
                    else
                        UxStatusLabel.Text = "Open Bid";
                    UxCurrentPriceTextBox.Text = String.Format("Current Price: {0:C}", selectedProduct.Price);
                    UxBidCount.Text = $"Currently: {selectedProduct.Bids.Count.ToString()} Bids";
                }
            }
        }

        /// Logs out of the account
        private void UxLogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //refresh everything that is not UxProductListBox
        public void UpdateBids()
        {
            Invoke(new Action(() =>
            {
                if (UxProductListBox.SelectedIndex == -1) UxProductListBox.SelectedIndex = 0;
                Product selectedProduct = UxProductListBox.Items[UxProductListBox.SelectedIndex] as Product;
                if (selectedProduct.Expired)
                    UxStatusLabel.Text = "Bid is closed.";
                else
                    UxStatusLabel.Text = "Open Bid";
                UxCurrentPriceTextBox.Text = String.Format("Current Price: {0:C}", selectedProduct.Price);
                UxBidCount.Text = $"Currently: {selectedProduct.Bids.Count.ToString()} Bids";
            }));
        }
    }
}
