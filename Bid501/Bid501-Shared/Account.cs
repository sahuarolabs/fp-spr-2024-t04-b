using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public class Account
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public List<Permission> Permissions { get; set; }

        public Account()
        {
        }

        public string Serialize()
        {
            //FIXME
            return "";
        }
    }
}
