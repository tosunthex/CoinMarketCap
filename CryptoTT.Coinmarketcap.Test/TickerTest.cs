using System.Linq;
using CryptoTT.Coinmarketcap.Parameters;
using CryptoTT.Coinmarketcap.Persistence;
using Xunit;

namespace Cryptott.Coinmarketcap.Test
{
    public class TickerTest
    {
        private readonly TickerReposity _tickerReposity;
        private const int CryptoReturnLimit = 10;
        
        public TickerTest()
        {
            _tickerReposity = new TickerReposity();
        }

        [Fact]
        public void Ticker_Without_Parameter_Must_Return_Hundred_Crypto()
        {
            var response = _tickerReposity.GetTopCrypto();
            Assert.NotNull(response);
            Assert.Equal(100, response.Result.Data.Count);
        }

        [Fact]
        public void Ticker_With_Start_Parameter()
        {
            const int startId = 3;
            var response = _tickerReposity.GetTopCrypto(startId, CryptoReturnLimit, SortBy.Id, Currency.USD);
            Assert.Equal(response.Result.Data.Values.First().Id, startId);
        }

        [Fact]
        public void Ticker_With_Limit_Must_Return_Two_Currency()
        {
            const int cryptoLimit = 2;
            var response = _tickerReposity.GetTopCrypto(Start.StartId, cryptoLimit, SortBy.Rank, Currency.USD);
            Assert.Equal(2,response.Result.Data.Count);
        }

        [Fact]
        public void Ticker_Sort_By_Id()
        {
            var response = _tickerReposity.GetTopCrypto(Start.StartId, CryptoReturnLimit, SortBy.Id, Currency.USD);
            var responseArray = response.Result.Data.Values.ToArray();
            for (var i = 1; i < responseArray.Length - 1; i++)
            {
                var prevCrypto = responseArray[i - 1].Id;
                var currentCrypto = responseArray[i].Id;
                Assert.True(prevCrypto <= currentCrypto,
                    $"Sort By Id Error Crypto Id {responseArray[i - 1].Name} {prevCrypto} <  {responseArray[i].Name} {currentCrypto}");
            }
        }

        [Fact]
        public void Ticker_Sort_By_Rank()
        {
            var response = _tickerReposity.GetTopCrypto(Start.StartId, CryptoReturnLimit, SortBy.Rank, Currency.USD);
            var responseArray = response.Result.Data.Values.ToArray();
            for (var i = 1; i < responseArray.Length - 1; i++)
            {
                var prevCrypto = responseArray[i - 1].Rank;
                var currentCrypto = responseArray[i].Rank;
                Assert.True(prevCrypto <= currentCrypto,
                    $"Sort By Rank Error Crypto Rank {responseArray[i - 1].Name} {prevCrypto} <  {responseArray[i].Name} {currentCrypto}");
            }
        }

        [Fact]
        public void Ticker_Sort_By_PercentChange24H()
        {
            var response = _tickerReposity.GetTopCrypto(Start.StartId, CryptoReturnLimit, SortBy.PercentChange24H, Currency.USD);
            var responseArray = response.Result.Data.Values.ToArray();
            for (var i = 1; i < responseArray.Length - 1; i++)
            {
                var prevCrypto = responseArray[i - 1].Quotes.Values.First().PercentChange24H;
                var currentCrypto = responseArray[i].Quotes.Values.First().PercentChange24H;
                Assert.True(prevCrypto >= currentCrypto,
                    $"Sort By Percent 24 Hour Error Crypto {responseArray[i - 1].Name} {prevCrypto} <  {responseArray[i].Name} {currentCrypto}");
            }
        }

        [Fact]
        public void Ticker_Sort_By_Volume24H()
        {
            var response = _tickerReposity.GetTopCrypto(Start.StartId, CryptoReturnLimit, SortBy.Volume24H, Currency.USD);
            var responseArray = response.Result.Data.Values.ToArray();
            for (var i = 1; i < responseArray.Length - 1; i++)
            {
                var prevCrypto = responseArray[i - 1].Quotes.Values.First().Volume24H;
                var currentCrypto = responseArray[i].Quotes.Values.First().Volume24H;
                Assert.True(prevCrypto >= currentCrypto,
                    $"Sort By Volume 24 Hour Error Crypto {responseArray[i - 1].Name} {prevCrypto} <  {responseArray[i].Name} {currentCrypto}");
            }
        }
        
        [Fact]
        public void Ticker_With_Currency_Parameter()
        {
            var response = _tickerReposity.GetTopCrypto(Start.StartId, CryptoReturnLimit, SortBy.Id, Currency.EUR);
            Assert.Equal(Currency.EUR,response.Result.Data.Values.First().Quotes.Keys.Last());
        }

        [Fact]
        public void Ticker_With_Id()
        {
            const int XrpId = 52;
            var response = _tickerReposity.GetById(XrpId, Currency.BTC);
            Assert.Equal(XrpId,response.Result.Data.Id);
            Assert.Equal(Currency.BTC,response.Result.Data.Quotes.Keys.Last());
        }

    }
}