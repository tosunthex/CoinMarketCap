using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoTT.Coinmarketcap.Model
{
    public class ListingsMetadata
    {
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
        [JsonProperty("num_cryptocurrencies")]
        public int NumCryptocurrencies { get; set; }
        [JsonProperty("error")]
        public object Error { get; set; }
    }
}