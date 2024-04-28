using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using Bid501_Shared;
using System.IO;
using Newtonsoft.Json;

namespace Bid501_Server
{
    public class ServerCommCtrl : WebSocketBehavior
    {

        /// <summary>
        /// List of all of the accounts Admin and Users
        /// </summary>
        private List<Account> Accounts = new List<Account>();

        private Model model;

        /// <summary>
        /// Add Bid Delegate
        /// </summary>
        private AddBidDel AddBid;

        private Dictionary<User, WebSocket> clients;

        /// <summary>
        /// Login Delegate
        /// </summary>
        private logInDel LogIn;

        public ServerCommCtrl(AddBidDel addBidDel, logInDel logInDel)
        {
            ReadTxtFile();
            AddBid = addBidDel;
            LogIn = logInDel;
        }

        /// <summary>
        /// Reads the Account text file using Newtonsoft Json
        /// </summary>
        private void ReadTxtFile()
        {
            string json = File.ReadAllText("Accounts.txt");
            Accounts = JsonConvert.DeserializeObject<List<Account>>(json);
        }

        /// <summary>
        /// Adds a Account Admin or User to the Account textfile.
        /// </summary>
        /// <param name="newAccount">The Account to add</param>
        private void AppendToTxtFile(Account newAccount)
        {
            string json = JsonConvert.SerializeObject(newAccount);
            File.AppendAllText("Accounts.txt", json + Environment.NewLine);
        }

        /// <summary>
        /// Login for the Server side
        /// </summary>
        /// <param name="username">The username entered</param>
        /// <param name="password">The password entered</param>
        /// <returns>A bool whether or not the login was successful</returns>
        private bool ServerLogin(string username, string password)
        {
            Account a = Accounts.Find(x => x.Username == username); //This will find the account with the associated username
            if (a.Username == null) // Checks if a Username was found in the list if not create the new user and adds it to the list and txt file
            {
                a.Username = username;
                a.Password = password;
                a.Isadmin = true;
                Accounts.Add(a);
                AppendToTxtFile(a);
                MessageBox.Show("User Successfully Created");
                return true;
            }
            else if(a.Password == password) //Checks the password if it's not the right password send false
            {
                return a.Isadmin; //Returns Isadmin should be true because only admins can login to Server
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Login for the Client side
        /// </summary>
        /// <param name="username">The username entered</param>
        /// <param name="password">The password entered</param>
        /// <returns>A bool whether or not the login was successful</returns>
        public bool ClientLogin(string username, string password)
        {
            Account a = Accounts.Find(x => x.Username == username); //This will find the account with the associated username
            if (a.Username == null) // Checks if a Username was found in the list if not create the new user and adds it to the list and txt file
            {
                a.Username = username;
                a.Password = password;
                a.Isadmin = false;
                Accounts.Add(a);
                AppendToTxtFile(a);
                MessageBox.Show("User Successfully Created");
                return true;
            }
            else if (a.Password == password) //Checks the password if it's not the right password send false
            {
                return !a.Isadmin; //Returns Isadmin should be false because only users can login to Client
            }
            else
            {
                return false;
            }
        }


        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    MessageBox.Show(ip.ToString());
                    return ip.ToString();
                }
            }
            MessageBox.Show("No network adapters with an IPv4 address in the system!");
            return "";
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            string inJSON = e.Data;
            string[] inputs = e.Data.Split(':');
            string id = inputs[0];
            switch(id)
            {
                case "login":

                    break;
                case "logout":

                    break;
                case "newbid":

                    break;
                default:
                    Console.WriteLine("Fuck yourself");
                    break;
            }
        }

        protected override void OnOpen()
        {

        }

        public void NotifyNewProduct()
        {

        }

        public void NotfyNewBid()
        {

        }

        public void EndAuction()
        {

        }

        public Dictionary<User, WebSocket> GetClients()
        {
            return clients;
        }  
        
    }
}
