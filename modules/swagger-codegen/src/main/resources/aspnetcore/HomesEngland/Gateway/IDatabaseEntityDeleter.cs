using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public interface IDatabaseEntityDeleter<T, TIndex> where T : IDatabaseEntity<TIndex>
    {
        Task<bool> DeleteAsync(TIndex index);
    }
}