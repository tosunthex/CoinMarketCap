using System.Collections.Generic;
using Newtonsoft.Json;

namespace cryptott.coinmarketcap.Model
{
    public class CryptoData
    {
        [JsonProperty("data")]
        public Dictionary<string,CryptoDetail> Data { get; set; }
        
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }
}