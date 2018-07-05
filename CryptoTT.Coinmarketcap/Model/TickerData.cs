using System.Collections.Generic;
using Newtonsoft.Json;

namespace CryptoTT.Coinmarketcap.Model
{
    public class TickerData
    {
        [JsonProperty("data")]
        public Dictionary<string, Ticker> Data { get; set; }

        [JsonProperty("metadata")]
        public TickerMetadata TickerMetadata { get; set; }
    }
}