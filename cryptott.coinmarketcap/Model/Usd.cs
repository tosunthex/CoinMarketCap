using Newtonsoft.Json;

namespace cryptott.coinmarketcap.Model
{
    public class Usd
    {
        public double Price { get; set; }
        
        [JsonProperty("volume_24h")]
        public double Volume24H { get; set; }
        
        [JsonProperty("market_cap")]
        public double MarketCap { get; set; }
        
        [JsonProperty("percent_change_1h")]
        public double PercentChange_1H { get; set; }
        
        [JsonProperty("percent_change_24h")]
        public double PercentChange24H { get; set; }
        
        [JsonProperty("percent_change_7d")]
        public double PercentChange_7D { get; set; }
    }
}