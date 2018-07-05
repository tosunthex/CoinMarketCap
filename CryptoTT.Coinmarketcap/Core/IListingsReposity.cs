using System.Threading.Tasks;
using CryptoTT.Coinmarketcap.Model;

namespace CryptoTT.Coinmarketcap.Core
{
    public interface IListingsReposity
    {
        Task<ListingsData> Get();
    }
}