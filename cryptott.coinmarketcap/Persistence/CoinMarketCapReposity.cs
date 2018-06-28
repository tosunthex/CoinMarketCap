using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using cryptott.coinmarketcap.Core;
using cryptott.coinmarketcap.Model;
using cryptott.coinmarketcap.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace cryptott.coinmarketcap.Persistence
{
    public class CoinMarketCapReposity:ICoinMarketCap
    {
        private readonly RestApiOptions _restApiOptions;

        public CoinMarketCapReposity(IOptions<RestApiOptions> restApiOptions)
        {
            _restApiOptions = restApiOptions.Value;
        }

        public async Task<CryptoData> GetTopCrypto()
        {
            var restClient = new HttpClient
            {
                BaseAddress = new Uri(_restApiOptions.CoinMarketCapUrl)
            };
            var limitParam = "limit=2";
            
            var response =  await restClient.GetAsync($"?{limitParam}");
            if (!response.IsSuccessStatusCode)
                return null;
            
            var responceContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CryptoData>(responceContent);
            return result;
        }
    }
}