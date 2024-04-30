using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class Account
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsAdmin { get; private set; }

        public Account(string username, string password, bool isAdmin)
        {
            Username = username;
            Password = password;
            this.IsAdmin = isAdmin;
        }

        // serialize the object to JSON (allows special characters in password)
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
