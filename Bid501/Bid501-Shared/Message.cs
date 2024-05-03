using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public class Message
    {
        public enum Type
        {
            LoginRequest, LoginResponse, ProductList, NewProduct, NewBid
        }

        public Type MessType { get; set; }

        public Message(Type messType)
        {
            MessType = messType;
        }
    }
}
