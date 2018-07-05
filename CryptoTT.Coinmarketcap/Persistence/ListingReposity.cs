using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoTT.Coinmarketcap.Core;
using CryptoTT.Coinmarketcap.Model;
using CryptoTT.Coinmarketcap.Parameters;

namespace CryptoTT.Coinmarketcap.Persistence
{
    public class ListingReposity:IListingsReposity
    {
        private readonly HttpClient _restClient;
        public ListingReposity()
        {
            _restClient = new HttpClient{BaseAddress = new Uri(Endpoints.CoinMarketCapApiUrl)};
        }
        public async Task<ListingsData> Get()
        {
            var querystringService = new QueryStringService();
            var jsonParserService = new JsonParserService();

            var url = querystringService.AppendQueryString(Endpoints.Listings,"");
            var response = await _restClient.GetAsync(url);
            return await jsonParserService.ParseResponse<ListingsData>(response);
        }
    }
}