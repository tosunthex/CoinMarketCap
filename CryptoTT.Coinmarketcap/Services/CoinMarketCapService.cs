using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoTT.Coinmarketcap.Core;
using CryptoTT.Coinmarketcap.Parameters;
using Microsoft.Extensions.Hosting;

namespace CryptoTT.Coinmarketcap.Services
{
    public class CoinMarketCapService : BackgroundService
    {
        private readonly ITickerReposity _coinMarketCap;
        private readonly IGlobalReposity _globalDataReposity;

        public CoinMarketCapService(ITickerReposity coinMarketCap,IGlobalReposity globalDataReposity)
        {
            _coinMarketCap = coinMarketCap;
            _globalDataReposity = globalDataReposity;
        }

        protected override async Task ExecuteAsync(CancellationToken cToken)
        {
            while (!cToken.IsCancellationRequested)
            {
                var cryptoDetail = await _coinMarketCap.GetTopCrypto();
//                
                //foreach (var crypto in cryptoDetail.Data.Values)
                //{
                //    Console.WriteLine(crypto.Name);
                //}
                var globalData = await _globalDataReposity.Get(Currency.USD);
                Console.WriteLine(globalData.Data.BitcoinPercentageOfMarketCap);
                //Work in every 3 minutes
                await Task.Delay(TimeSpan.FromSeconds(30), cToken);
            }
        }
    }
}