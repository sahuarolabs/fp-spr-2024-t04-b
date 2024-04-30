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
        private string acctFile;

        /// <summary>
        /// List of all accounts
        /// </summary>
        private List<Account> acctList;

        /// <summary>
        /// should only be an Account account as this is server-side.
        /// </summary>
        private Account loggedIn;

        public AccountController(string acctFile)
        {
            this.acctFile = acctFile;
            this.acctList = LoadAccounts(acctFile);
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

        public void SaveAccounts()
        {
            // convert the account list to JSON and overwrite the file
            string serializedAccounts = JsonConvert.SerializeObject(acctList);
            File.WriteAllText(acctFile, serializedAccounts);
        }

        public bool Login(string Accountname, string password, bool client)
        {
            // find the Account by Accountname
            Account account = acctList.Find(acct => acct.Username == Accountname);

            // if the Accountname doesn't exist, create a new account
            if (account == null)
            {
                Account newAccount = client ? (Account) new Account(Accountname, password, true)
                    : (Account) new Account(Accountname, password, true);
                acctList.Add(newAccount);
                return true;
            }

            //FIXME: Returns all client
            return false;
            // if the Accountname exists, it has to be either a Account trying to log into the client
            // or an Account trying to log in onto the server

        }

        public void UpdateAccountData()
        {
            foreach(Account a in acctList)
            {

            }
        }

    }
}
