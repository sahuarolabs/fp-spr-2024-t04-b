using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    // Make this a bool val? i.e. isAdmin, then check if(isAdmin) before allowing them to change these things rather than an enum that overcomplicates the process.
    public enum Permission
    {
        LoginClient,
        LoginServer,
        AddProduct,
        EditProduct,
        MakeBid,
        EndAuction
    }
}
