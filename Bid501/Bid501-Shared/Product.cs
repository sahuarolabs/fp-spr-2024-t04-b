
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    [Serializable]
    public class Product
    {
        public int Id { get; }

        public string Name { get; }

        public double StartingPrice { get; }

        public double Price { get; }

        public bool Expired { get; }

        public Account Consigner { get; }

        public List<Bid> Bids { get; }

        public Product(int id, string name, double startingPrice, Account consigner)
        {
            Id = id;
            Name = name;
            StartingPrice = startingPrice;
            Expired = false;
            Consigner = consigner;
            Bids = new List<Bid>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
