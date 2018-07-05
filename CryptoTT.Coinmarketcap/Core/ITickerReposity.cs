using System.Threading.Tasks;
using CryptoTT.Coinmarketcap.Model;

namespace CryptoTT.Coinmarketcap.Core
{
    public interface ITickerReposity
    {
        Task<TickerData> GetTopCrypto();
        Task<TickerData> GetTopCrypto(int start,int limit,string sort,string convert );
    }
}