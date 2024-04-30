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
    public class ServerController
    {
        private AccountController acctCtrl;
        private string modelFileName;
        private Model model;
        private List<RefreshViewDel> observers;
        private ServerCommCtrl serverComm;
        private RefreshViewDel refreshView;

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
                ServerView serverView = new ServerView(model, AddProduct, SaveModel);
                AddObserver(serverView.RefreshView);
                serverView.Show();
            }
            else
                MessageBox.Show("Invalid credentials!", "Login Error");

            return success;
        }

        public static Model LoadModelFromFile(string fileName)
        {
            Account defCons = new Admin("admin", "admin");
            List<IProduct> initProds = new List<IProduct> {
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

        public void AddProduct(IProduct product)
        {
            model.Products.Add(product);

            // TODO: refresh view and notify clients
            foreach (RefreshViewDel refresh in observers)
                refresh();
        }

        public void AddObserver(RefreshViewDel observer)
        {
            observers.Add(observer);
        }

        public void AddBid(Bid b, Product p)
        {

        }

        public bool LogIn(string user, string pass)
        {
            return true;
        }
    }
}
