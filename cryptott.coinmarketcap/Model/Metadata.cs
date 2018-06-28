using Newtonsoft.Json;

namespace cryptott.coinmarketcap.Model
{
    public class Metadata
    {
        public int Timestamp { get; set; }
        
        [JsonProperty("num_cryptocurrencies")]
        public int NumCryptocurrencies { get; set; }
        
        public object Error { get; set; }
    }
}