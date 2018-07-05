using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoTT.Coinmarketcap.Core;
using CryptoTT.Coinmarketcap.Parameters;
using Microsoft.Extensions.Hosting;

namespace CryptoTT.Coinmarketcap.Services
{
    public class CoinMarketCapService : HostedService
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
//                var cryptoDetail = await _coinMarketCap.GetTopCrypto();
//                
//                foreach (var crypto in cryptoDetail.Data.Values)
//                {
//                    Console.WriteLine(crypto.Name);
//                }
                var globalData = await _globalDataReposity.Get(Currency.USD);
                Console.WriteLine(globalData.Data.BitcoinPercentageOfMarketCap);
                await Task.Delay(TimeSpan.FromSeconds(10), cToken);
            }
        }
    }
    public class RequestCollectorService: HostedService
    {
        protected override async Task ExecuteAsync(CancellationToken cToken)
        {
            while (!cToken.IsCancellationRequested)
            {
                Console.WriteLine($"{DateTime.Now.ToString()} Çalışma zamanı taleplerini topluyorum.");
                await Task.Delay(TimeSpan.FromSeconds(30), cToken);
            }
        }
    }
    public abstract class HostedService : IHostedService, IDisposable
    {
        private Task currentTask;
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        protected abstract Task ExecuteAsync(CancellationToken cToken);

        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            currentTask = ExecuteAsync(cancellationTokenSource.Token);

            if (currentTask.IsCompleted)
                return currentTask;

            return Task.CompletedTask;
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            if (currentTask == null)
                return;

            try
            {
                cancellationTokenSource.Cancel();
            }
            finally
            {
                await Task.WhenAny(currentTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }

        public virtual void Dispose()
        {
            cancellationTokenSource.Cancel();
        }
    }
}