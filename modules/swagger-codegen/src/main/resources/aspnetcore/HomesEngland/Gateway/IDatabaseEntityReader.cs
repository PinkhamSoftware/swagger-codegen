using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public interface IDatabaseEntityReader<T, TIndex> where T : IDatabaseEntity<TIndex>
    {
        Task<T> ReadAsync(TIndex index);
    }
}
