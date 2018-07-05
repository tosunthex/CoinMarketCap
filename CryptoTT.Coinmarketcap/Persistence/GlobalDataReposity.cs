using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CryptoTT.Coinmarketcap.Core;
using CryptoTT.Coinmarketcap.Model;
using CryptoTT.Coinmarketcap.Parameters;
using MongoDB.Driver.Core.Clusters.ServerSelectors;

namespace CryptoTT.Coinmarketcap.Persistence
{
    public class GlobalDataReposity:IGlobalDataReposity
    {
        private readonly HttpClient _restClient;
        public GlobalDataReposity()
        {
            _restClient = new HttpClient{BaseAddress = new Uri(Endpoints.ApiUrl)};
        }
        public async Task<GlobalData> Get(string convert)
        {
            var queryStringService = new QueryStringService();
            var jsonParserService = new JsonParserService();
            var convertParam = !string.IsNullOrWhiteSpace(convert) ? $"convert={convert}" : null;

            var url = queryStringService.AppendQueryString(Endpoints.GlobalData, convertParam);
            var response = await _restClient.GetAsync(url);
            return await jsonParserService.ParseResponse<GlobalData>(response);
        }
    }
}