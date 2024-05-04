using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class Model
    {
        public List<Product> Products { get; }

        public Model()
        {
            Products = new List<Product>();
        }

        public Model(List<Product> products)
        {
            Products = products;
        }

        public int GenId()
        {
            return (Products.Count == 0) ? 1 : Products.Select(prod => prod.Id).Max() + 1;
        }

        public bool CanEndAuctionOn(Product product)
        {
            // enable auction end only on available products with at least one bid
            return !product.Expired && product.Bids.Count > 0;
        }
    }
}
