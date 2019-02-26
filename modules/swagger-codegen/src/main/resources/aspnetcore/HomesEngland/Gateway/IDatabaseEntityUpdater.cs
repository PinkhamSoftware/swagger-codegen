using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public interface IDatabaseEntityUpdater<T, TIndex> where T : IDatabaseEntity<TIndex>
    {
        Task<T> UpdateAsync(T entity);
    }
}