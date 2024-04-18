using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public interface IProduct
    {
        /// <summary>
        /// The number associated to said product.
        /// </summary>
        int Id{ get; }

        /// <summary>
        /// The Name of the Product.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The starting Price of the Product.
        /// </summary>
        double StartingPrice { get; }

        /// <summary>
        /// Bool for if the Product is expired, true means expired, false mean not expired.
        /// </summary>
        bool Expired { get; }

        /// <summary>
        /// The Account that posted the 
        /// </summary>
        Account Consigner { get; }

        /// <summary>
        /// The List of all the bids
        /// </summary>
        List<Bid> Bids { get; }
    }
}
