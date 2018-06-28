using System.Collections.Generic;
using System.Threading.Tasks;
using cryptott.coinmarketcap.Model;

namespace cryptott.coinmarketcap.Core
{
    public interface ICoinMarketCap
    {
        Task<CryptoData> GetTopCrypto();
    }
}