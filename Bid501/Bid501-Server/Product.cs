using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class Product : IProduct
    {
        public int Id { get; }

        public string Name { get; }

        public double StartingPrice { get; }

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
    }
}
