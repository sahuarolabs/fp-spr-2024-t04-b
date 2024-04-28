using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public class User : Account
    {
        public static readonly List<Permission> PERMISSIONS = new List<Permission>
            { Permission.LoginClient, Permission.MakeBid };

        public User(string username, string password) : base(username, password, false)
        {
        }
    };
}
