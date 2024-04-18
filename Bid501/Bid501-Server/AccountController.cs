using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;

namespace Bid501_Server
{
    public class AccountController
    {
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
            /*
            if (File.Exists("AccountData.txt"))
            {
                StreamReader sr = new StreamReader("AccountData.txt");
                while (!sr.EndOfStream)
                {
                    string[] acctData = sr.ReadLine().Split(' ');
                }

            }*/

        }

        /// <summary>
        /// Method to add an account to the acctList.
        /// </summary>
        /// <param name="a">Account to be added.</param>
        public void AddAccount(Account a)
        {



        }


    }
}
