using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    //If admin permisions {1,2,4}
    //If user permissions {0,3}
    public enum Permission
    {
        LoginClient,
        LoginServer,
        AddProduct,
        MakeBid,
        EndAuction
    }
}
