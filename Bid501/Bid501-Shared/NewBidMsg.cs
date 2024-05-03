using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class NewBidMsg : Message
    {
        public bool Success { get; set; }
        public Bid BidInfo { get; set; }

        public NewBidMsg(bool succ, Bid bid) : base(Message.Type.NewBid)
        {
            Success = succ;
            BidInfo = bid;
        }
    }
}
