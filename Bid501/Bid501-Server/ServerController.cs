﻿using System;
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
    public delegate List<string> GetActiveClientsDel();

    public class ServerController
    {
        public AccountController acctCtrl;

        private string modelFileName;
        private Model model;
        private List<RefreshViewDel> observers;
        private GetClientsDel getClients;
        private RefreshViewDel refreshView;

        public ServerCommCtrl ServerComm { get; set; }

        public ServerController(AccountController acctCtrl, string modelFileName)
        {
            this.acctCtrl = acctCtrl;
            this.modelFileName = modelFileName;
            model = LoadModelFromFile(modelFileName);
            observers = new List<RefreshViewDel>();
        }

        public bool AfterLoginAction(bool success)
        {
            if (success)
            {
                acctCtrl.SaveAccounts();
                ServerView serverView = new ServerView(model, AddProduct, SaveModel, GetActiveClients);
                AddObserver(serverView.RefreshView);
                serverView.Show();
            }
            else
                MessageBox.Show("Invalid credentials!", "Login Error");

            return success;
        }

        public static Model LoadModelFromFile(string fileName)
        {
            Account defCons = new Account("admin", "admin",true);
            List<Product> initProds = new List<Product> {
                new Product(1, "PS4", 100.0, defCons),
                new Product(2, "iPhone 7", 50.0, defCons),
                new Product(3, "Bose SoundSpot", 30.0, defCons)
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

        public void AddProduct(Product product)
        {
            model.Products.Add(product);

            // refresh view
            foreach (RefreshViewDel refresh in observers)
                refresh();

            // notify clients
            ServerComm.NotifyNewProduct(product);
        }

        public void AddObserver(RefreshViewDel observer)
        {
            observers.Add(observer);
        }
        

        public List<string> GetActiveClients()
        {
            return new List<string>(acctCtrl.activeAccounts.Keys);
        }

        public bool AddBid(Bid bid, Product product)
        {
            // ignore the bid if the amount is below the starting price
            if (bid.Amount < product.StartingPrice)
                return false;

            product.Bids.Add(bid);
            
            // FIXME: Notify new bid
            return true;
        }

        public List<Product> GetProducts()
        {
            return model.Products;
        }
    }
}
