using System.Data;
using Npgsql;

namespace HomesEngland.Gateway.Sql.Postgres
{
    public class PostgresDatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly IDatabaseConnectionStringFormatter _databaseConnectionStringFormatter;

        public PostgresDatabaseConnectionFactory(IDatabaseConnectionStringFormatter databaseConnectionStringFormatter)
        {
            _databaseConnectionStringFormatter = databaseConnectionStringFormatter;
        }

        /// <summary>
        /// Takes a //postgres://circleci:super-secret@localhost:5432/asset_register_api databaseUrl
        /// </summary>
        /// <param name="databaseUrl"></param>
        /// <returns></returns>
        public IDbConnection Create(string databaseUrl)
        {
            var ngpsqlConnectionString = _databaseConnectionStringFormatter.BuildConnectionStringFromUrl(databaseUrl);

            return new NpgsqlConnection(ngpsqlConnectionString);
        }
    }
}
