using CryptoTT.Coinmarketcap.Parameters;
using CryptoTT.Coinmarketcap.Persistence;
using Xunit;

namespace Cryptott.Coinmarketcap.Test
{
    public class GlobalTest
    {
        private readonly GlobalReposity _globalReposity;
        public GlobalTest()
        {
            _globalReposity = new GlobalReposity();
        }

        [Fact]
        public void Global_Return_Success()
        {
            var response = _globalReposity.Get(Currency.USD);
            Assert.NotNull(response);
        }
    }
}