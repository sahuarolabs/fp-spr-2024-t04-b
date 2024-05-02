using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class ProductListMsg : Message
    {
        public List<Product> Products { get; set; }

        public ProductListMsg(List<Product> products) : base(Message.Type.ProductList)
        {
            Products = products;
        }
    }
}
