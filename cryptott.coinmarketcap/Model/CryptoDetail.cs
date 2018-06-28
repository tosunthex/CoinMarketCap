using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace cryptott.coinmarketcap.Model
{
    public class CryptoDetail
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        
        [BsonRequired]
        public int Id { get; set; }
        
        [BsonRequired]
        public string Name { get; set; }
        
        [BsonRequired]
        public string Symbol { get; set; }
        
        [JsonProperty("website_slug")]
        public string WebsiteSlug { get; set; }
        
        public int Rank { get; set; }
        
        [JsonProperty("circulating_supply")]
        public double CirculatingSupply { get; set; }
        
        [JsonProperty("total_supply")]
        public double TotalSupply { get; set; }
        
        [JsonProperty("max_supply")]
        public double MaxSupply { get; set; }
        
        [JsonProperty("quotes")]
        public Dictionary<string,Usd> Quotes{ get; set; }
        
        [JsonProperty("last_updated")]
        public int LastUpdated { get; set; }
    }
}