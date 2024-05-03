using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class NewProductMsg : Message
    {
        public Product Prod { get; set; }

        public NewProductMsg(Product product) : base(Message.Type.NewProduct)
        {
            Prod = product;
        }
    }
}
