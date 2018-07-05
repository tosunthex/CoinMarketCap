using System;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoTT.Coinmarketcap.Core;
using CryptoTT.Coinmarketcap.Model;
using CryptoTT.Coinmarketcap.Parameters;

namespace CryptoTT.Coinmarketcap.Persistence
{
    public class TickerReposity:ITickerReposity
    {
        private readonly HttpClient _restClient;
        
        public TickerReposity()
        {
            
            _restClient = new HttpClient {BaseAddress = new Uri(Endpoints.CoinMarketCapApiUrl)};
        }

        public Task<TickerData> GetTopCrypto()
        {
            const int start = Start.StartId;
            const int limit = Limit.Max;
            const string sort = SortBy.Rank;
            const string convert = Currency.USD;  
            return GetTopCrypto(start,limit,sort,convert);
        }

        public async Task<TickerData> GetTopCrypto(int start,int limit,string sort,string convert)
        {
            var queryStringService = new QueryStringService();
            var jsonParserService = new JsonParserService();
            
            var startParam = start >= 1 ? $"start={start}" : null;
            var limitParam = limit >= 1 ? $"limit={limit}" : null;
            var sortParam = !string.IsNullOrWhiteSpace(sort) ? $"sort={sort}" : null;
            var convertParam = !string.IsNullOrWhiteSpace(convert) ? $"convert={convert}" : null;
            
            
            var url = queryStringService.AppendQueryString(Endpoints.Ticker,startParam,limitParam,sortParam,convertParam);
            var response =  await _restClient.GetAsync(url);
            return await jsonParserService.ParseResponse<TickerData>(response);
        }

        
    }
}