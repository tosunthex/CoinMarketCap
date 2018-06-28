using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using cryptott.coinmarketcap.Core;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace cryptott.coinmarketcap.Services
{
    public class CoinMarketCapService : HostedService
    {
        private readonly ICoinMarketCap _coinMarketCap;
        private readonly RestApiOptions _restApiOptions;
        HttpClient restClient;
        

        public CoinMarketCapService(ICoinMarketCap coinMarketCap,IOptions<RestApiOptions> restApiOptions)
        {
            _coinMarketCap = coinMarketCap;
            _restApiOptions = restApiOptions.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken cToken)
        {
            while (!cToken.IsCancellationRequested)
            {
                var coinDetail = await _coinMarketCap.GetTopCrypto();
                
                /*foreach (var coin in coinDetail.Data.Values)
                {
                    Console.WriteLine(coin.Id);
                }*/
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