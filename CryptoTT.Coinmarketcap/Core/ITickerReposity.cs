using System.Threading.Tasks;
using CryptoTT.Coinmarketcap.Model;

namespace CryptoTT.Coinmarketcap.Core
{
    public interface ITickerReposity
    {
        Task<TickersData> GetTopCrypto();
        Task<TickersData> GetTopCrypto(int start,int limit,string sort,string convert );
        Task<TickerData> GetById(int id,string convert);
    }
}