using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public class Admin : Account
    {
        public static readonly List<Permission> PERMISSIONS = new List<Permission>
            { Permission.LoginServer, Permission.AddProduct, Permission.EndAuction };

        public Admin(string username, string password) : base(username, password, PERMISSIONS)
        {
        }
    }
}
