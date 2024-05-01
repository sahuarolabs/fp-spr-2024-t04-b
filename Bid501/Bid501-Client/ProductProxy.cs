using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;

namespace Bid501_Client
{
    public class ProductProxy : IProduct
    {
        /// <summary>
        /// The number associated to said product.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The Name of the Product.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The starting Price of the Product.
        /// </summary>
        public double StartingPrice { get; private set; }

        /// <summary>
        /// Bool for if the Product is expired, true means expired, false mean not expired.
        /// </summary>
        public bool Expired { get; set; } = false;

        /// <summary>
        /// The Account that posted the product
        /// </summary>
        public Account Consigner { get; private set; }

        /// <summary>
        /// The List of all the bids
        /// </summary>
        public List<Bid> Bids { get; } = new List<Bid>();

        /// <summary>
        /// Gets the current price of the product
        /// </summary>
        public double Price 
        { 
            get
            {
                double x = StartingPrice;
                foreach (Bid bid in Bids)
                {
                    if(x < bid.Amount) x = bid.Amount;
                }
                return x;
            }
        }

        /// <summary>
        /// Constructor for ProductProxy
        /// </summary>
        /// <param name="id">The number associated to said product.</param>
        /// <param name="name">The Name of the Product.</param>
        /// <param name="startingPrice">The starting Price of the Product.</param>
        /// <param name="consigner">The Account that posted the product</param>
        public ProductProxy(int id, string name, double startingPrice, Account consigner)
        {
            Id = id;
            Name = name;
            StartingPrice = startingPrice;
            Consigner = consigner;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
