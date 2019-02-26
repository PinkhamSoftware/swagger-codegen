using HomesEngland.Domain;

namespace HomesEngland.Gateway
{
    public interface IGateway<T, TIndex>: 
        IDatabaseEntityCreator<T, TIndex>, 
        IDatabaseEntityReader<T, TIndex>
        where T : class, IDatabaseEntity<TIndex>
    {

    }
}
