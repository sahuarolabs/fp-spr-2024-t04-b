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
        public List<IProduct> Products { get; }

        public Model()
        {
            Products = new List<IProduct>();
        }

        public Model(List<IProduct> products)
        {
            Products = products;
        }

        public int GenId()
        {
            return (Products.Count == 0) ? 1 : Products.Select(prod => prod.Id).Max() + 1;
        }
    }
}
