using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;
using Newtonsoft.Json;

namespace Bid501_Server
{
    public class AccountController
    {
        public readonly string ACCOUNTS_FILE = "accounts.json";

        /// <summary>
        /// List of all accounts
        /// </summary>
        private List<Account> acctList;

        /// <summary>
        /// should only be an admin account as this is server-side.
        /// </summary>
        private Account loggedIn;

        public AccountController()
        {
            acctList = LoadAccounts(ACCOUNTS_FILE);
        }

        private List<Account> LoadAccounts(string fileName)
        {
            // if the file doesn't exist, return en empty list
            if (!File.Exists(fileName))
                return new List<Account>();

            // load the accounts from the file in JSON format
            string content = File.ReadAllText(fileName);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(content);
            return accounts;
        }

        public void SaveAccounts(string fileName)
        {
            // convert the account list to JSON and overwrite the file
            string serializedAccounts = JsonConvert.SerializeObject(acctList);
            File.WriteAllText(fileName, serializedAccounts);
        }

        public bool Login(string username, string password, bool client)
        {
            // find the user by username
            Account account = acctList.Find(acct => acct.Username == username);

            // if the username doesn't exist, create a new account
            if (account == null)
            {
                Account newAccount = client ? (Account) new User(username, password)
                    : (Account) new Admin(username, password);
                acctList.Add(newAccount);
                return true;
            }

            // if the username exists, it has to be either a user trying to log into the client
            // or an admin trying to log in onto the server
            return (client && account.Permissions.Contains(Permission.LoginClient))
                || (!client && account.Permissions.Contains(Permission.LoginServer));
        }

        public void UpdateAccountData()
        {
            foreach(Account a in acctList)
            {

            }
        }

    }
}
