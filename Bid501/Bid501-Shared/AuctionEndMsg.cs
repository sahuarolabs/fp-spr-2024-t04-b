using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class AuctionEndMsg : Message
    {
        public int ProductId { get; set; }
        public string Winner{ get; set; }
        public double FinalPrice { get; set; }

        public AuctionEndMsg(int productId, string winner, double finalPrice) : base(Message.Type.AuctionEnd)
        {
            ProductId = productId;
            Winner = winner;
            FinalPrice = finalPrice;
        }
    }
}
