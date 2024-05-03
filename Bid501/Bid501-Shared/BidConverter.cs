using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public class BidConverter : JsonConverter<Bid>
    {
        public override Bid ReadJson(JsonReader reader, Type objectType, Bid existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            Account bidder = jObject["Bidder"].ToObject<Account>();
            double amount = jObject["Amount"].ToObject<double>();
            Product product = jObject["GetProduct"].ToObject<Product>();

            return new Bid(bidder, amount, product);
        }

        public override void WriteJson(JsonWriter writer, Bid value, JsonSerializer serializer)
        {
            JObject jObject = new JObject
        {
            { "Bidder", JToken.FromObject(value.Bidder) },
            { "Amount", JToken.FromObject(value.Amount) },
            { "GetProduct", JToken.FromObject(value.GetProduct) }
        };
            jObject.WriteTo(writer);
        }
    }
}
