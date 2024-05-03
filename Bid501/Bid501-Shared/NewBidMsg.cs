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
        public int ProductId { get; set; }
        public Bid BidInfo { get; set; }

        public NewBidMsg(int productId, Bid bid) : base(Message.Type.NewBid)
        {
            ProductId = productId;
            BidInfo = bid;
        }
    }
}
