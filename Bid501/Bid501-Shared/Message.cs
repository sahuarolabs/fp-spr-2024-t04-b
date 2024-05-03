using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public class Message
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Type
        {
            LoginRequest, LoginResponse, ProductList, NewProduct, NewBid
        }

        public Type MsgType { get; set; }

        public Message(Type msgType)
        {
            MsgType = msgType;
        }
    }
}
