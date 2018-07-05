using System.Threading.Tasks;
using CryptoTT.Coinmarketcap.Model;

namespace CryptoTT.Coinmarketcap.Core
{
    public interface IGlobalDataReposity
    {
        Task<GlobalData> Get(string convert);
    }
}