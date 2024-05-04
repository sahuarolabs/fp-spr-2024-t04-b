using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501_Shared;
using Newtonsoft.Json;

namespace Bid501_Server
{
    public delegate Dictionary<string, Account> GetClientsDel();

    public class ServerController
    {
        private AccountController accountController;
        private string modelFileName;

        private Model model;
        private List<RefreshViewDel> observers;
        private ServerView serverView;

        public ServerController(AccountController acctCtrl, string modelFileName)
        {
            this.accountController = acctCtrl;
            this.modelFileName = modelFileName;
            model = LoadModelFromFile(modelFileName);
            observers = new List<RefreshViewDel>();
        }

        public bool AfterLoginAction(bool success)
        {
            if (success)
            {
                serverView = new ServerView(model, AddProduct, SaveModel, EndAuction, GetClients);
                AddObserver(serverView.RefreshView);
                serverView.Show();
            }
            else
                MessageBox.Show("Invalid credentials!", "Login Error");

            return success;
        }

        public static Model LoadModelFromFile(string fileName)
        {
            List<Product> initProds = new List<Product> {
                new Product(1, "PS4", 100.0),
                new Product(2, "iPhone 7", 50.0),
                new Product(3, "Bose SoundSpot", 30.0)
            };

            // if the file dosn't exist, return default 3 products
            if (!File.Exists(fileName))
                return new Model(initProds);

            // load the products from the file
            string content = File.ReadAllText(fileName);
            Model model = JsonConvert.DeserializeObject<Model>(content);
            return model;
        }

        public void SaveModel()
        {
            string serialized = JsonConvert.SerializeObject(model);
            File.WriteAllText(modelFileName, serialized);
        }

        public void RefreshViews()
        {
            foreach (RefreshViewDel refresh in observers)
                refresh();
        }

        public void AddProduct(Product product)
        {
            model.Products.Add(product);
            RefreshViews();

            // notify clients
            ServerCommCtrl.NotifyNewProduct(product);
        }

        public void AddObserver(RefreshViewDel observer)
        {
            observers.Add(observer);
        }

        public bool AddBid(int productId, Bid bid)
        {
            // if there is not a product with that ID, do nothing
            Product product = model.Products.Find(prod => prod.Id == productId);
            if (product == null)
                return false;

            /*
            ignore the bid if:
              - the auction has already ended
              - the bidder is an admin
              - the amount is below the current price
            */
            if (product.Expired || bid.Bidder.IsAdmin ||  bid.Amount < product.Price)
                return false;

            product.Bids.Add(bid);

            // refresh view
            foreach (RefreshViewDel refresh in observers)
                refresh();

            return true;
        }

        public static void EndAuction(Product product)
        {
            // if the product doesn't have any bids, do nothing
            if (product.Bids.Count == 0)
                return;

            product.Expired = true;

            // go through the list to find the highest bid
            Bid highestBid = product.Bids.First();
            foreach (Bid bid in product.Bids)
            {
                if (bid.Amount > highestBid.Amount)
                    highestBid = bid;
            }

            // notify the clients
            ServerCommCtrl.NotifyAuctionEnd(product.Id, highestBid);
        }

        public List<Product> GetProducts()
        {
            return model.Products;
        }

        public Dictionary<string, Account> GetClients()
        {
            return accountController.activeAccounts;
        }
    }
}
