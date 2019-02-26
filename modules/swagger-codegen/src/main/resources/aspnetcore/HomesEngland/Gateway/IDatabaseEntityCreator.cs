using System.Threading.Tasks;
using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public interface IDatabaseEntityCreator<T, TIndex> where T : IDatabaseEntity<TIndex>
    {
        Task<T> CreateAsync(T entity);
    }
}
