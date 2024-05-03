using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class BidRequest : Message
    {
        public Bid NewBid { get; set; }

        public BidRequest(Bid newbid) : base(Message.Type.NewBid)
        {
            NewBid = newbid;
        }
    }
}
