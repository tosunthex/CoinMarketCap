using Newtonsoft.Json;

namespace CryptoTT.Coinmarketcap.Model
{
    public class GlobalData
    {
        [JsonProperty("data")]
        public Global Data { get; set; }
        [JsonProperty("metadata")]
        public GlobalMetadata Metadata { get; set; }
    }
}