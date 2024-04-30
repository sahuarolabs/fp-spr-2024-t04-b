using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class Model
    {
        public List<IProduct> Products { get; }

        public Model()
        {
            Products = new List<IProduct>();
        }

        public Model(List<IProduct> products)
        {
            Products = products;
        }
    }
}
