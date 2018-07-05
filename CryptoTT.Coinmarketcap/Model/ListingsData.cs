using System.Collections.Generic;
using Newtonsoft.Json;

namespace CryptoTT.Coinmarketcap.Model
{
    public class ListingsData
    {
        [JsonProperty("data")]
        public List<Listings> Data { get; set; }
        [JsonProperty("metadata")]
        public ListingsMetadata Metadata { get; set; }
    }
}