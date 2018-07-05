using Newtonsoft.Json;

namespace CryptoTT.Coinmarketcap.Model
{
    public class GlobalQuotes
    {
        [JsonProperty("total_market_cap")]
        public double TotalMarketCap { get; set; }
        [JsonProperty("total_volume_24h")]
        public double TotalVolume24H { get; set; }
    }
}