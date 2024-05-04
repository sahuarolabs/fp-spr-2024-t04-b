using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Server
{
    public partial class ServerView : Form
    {
        private Model model;
        private AddProductDel addProduct;
        private SaveModelDel saveModel;
        private EndAuctionDel endAuction;
        private GetClientsDel getClientsDel;

        public ServerView(Model model, AddProductDel addProduct, SaveModelDel saveModel, EndAuctionDel endAuction, GetClientsDel gcDel)
        {
            this.model = model;
            this.addProduct = addProduct;
            this.saveModel = saveModel;
            this.endAuction = endAuction;
            this.getClientsDel = gcDel;

            InitializeComponent();
            UpdateProducts();
        }

        private void ServerView_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveModel();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // predefined products that can be added
            int id = model.GenId();
            Account defCons = new Account("Account", "Account",true);
            List<Product> prodsToAdd = new List<Product>
            {
                new Product(id, "Nintendo Switch", 35.0, defCons),
                new Product(id + 1, "Renaissance Artwork", 200.0, defCons),
                new Product(id + 2, "Antique Knife", 50.0, defCons),
                new Product(id + 3, "Racing Horse", 1000.0, defCons)
            };

            // display a dialog to add one of the products
            AddProductView dialog = new AddProductView(prodsToAdd);
            if (dialog.ShowDialog() == DialogResult.OK)
                addProduct(dialog.SelectedProd);
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            Product selProd = (Product) uxListBoxProducts.SelectedItem;

            if (selProd != null)
            {
                endAuction(selProd);
                UpdateButtonEnabled();
            }
        }

        private void uxListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonEnabled();
        }

        private void UpdateProducts()
        {
            // reload the products in the list
            uxListBoxProducts.DataSource = null;
            uxListBoxProducts.DataSource = model.Products;
        }

        private void UpdateClients()
        {
            Dictionary<string, Account> activeClients = getClientsDel();
            if (activeClients != null)
            {
                uxListBoxClients.Items.Clear();
                foreach (Account client in activeClients.Values)
                {
                    uxListBoxClients.Items.Add(client.Username);
                }
            }
        }

        private void UpdateButtonEnabled()
        {
            // disable the end button if auction cannot be ended on the selected product
            Product selProd = (Product)uxListBoxProducts.SelectedItem;
            buttonEnd.Enabled = selProd != null && model.CanEndAuctionOn(selProd);
        }

        public void RefreshView()
        {
            Invoke(new Action(() => {
                UpdateProducts();
                UpdateClients();
                UpdateButtonEnabled();
            }));
        }
    }
}
