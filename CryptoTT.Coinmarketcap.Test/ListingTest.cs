using System;
using CryptoTT.Coinmarketcap.Persistence;
using Xunit;

namespace Cryptott.Coinmarketcap.Test
{
    public class ListingTest
    {
        private readonly ListingReposity _listingReposity;

        public ListingTest()
        {
            _listingReposity = new ListingReposity();
        }

        [Fact]
        public void Crypto_Listing_Count_Check()
        {
            var response = _listingReposity.Get();
            Console.WriteLine($"Data Count = {response.Result.Data.Count}  NumCryptocurrencies = {response.Result.Metadata.NumCryptocurrencies}");
            Assert.Equal(response.Result.Data.Count, response.Result.Metadata.NumCryptocurrencies);
        }
    }
}