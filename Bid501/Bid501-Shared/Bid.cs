using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public class Bid
    {

        /// <summary>
        /// The person who just placed the bid.
        /// </summary>
        public Account Bidder { get; private set; }

        /// <summary>
        /// The ammount the user wants to bid.
        /// </summary>
        public double Ammount { get; private set; }
         
        /// <summary>
        /// Constructor for the Bid.
        /// </summary>
        /// <param name="bidder">The person who just placed the bid.</param>
        /// <param name="ammount">The ammount the user wants to bid.</param>
        public Bid(Account bidder, double ammount)
        {
            Bidder = bidder;
            Ammount = ammount;
        }
    }
}
