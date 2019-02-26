using System.Data;

namespace HomesEngland.Gateway
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection Create(string databaseUrl);
    }
}