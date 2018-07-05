using System.Threading.Tasks;
using CryptoTT.Coinmarketcap.Model;

namespace CryptoTT.Coinmarketcap.Core
{
    public interface IGlobalReposity
    {
        Task<GlobalData> Get(string convert);
    }
}