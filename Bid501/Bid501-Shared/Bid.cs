using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class Bid
    {
        /// <summary>
        /// The person who just placed the bid.
        /// </summary>
        public Account Bidder { get; private set; }

        /// <summary>
        /// The ammount the user wants to bid.
        /// </summary>
        public double Amount { get; private set; }

        /// Bid Constructor
        public Bid(Account bidder, double amount)

        {
            Bidder = bidder;
            Amount = amount;
        }

        /// serialize the object to JSON 
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
