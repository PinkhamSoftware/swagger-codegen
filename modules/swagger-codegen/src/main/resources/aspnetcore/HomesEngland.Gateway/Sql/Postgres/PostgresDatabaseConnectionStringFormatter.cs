using System;
using System.Linq;

namespace HomesEngland.Gateway.Sql.Postgres
{
    public class PostgresDatabaseConnectionStringFormatter: IDatabaseConnectionStringFormatter
    {
        public string BuildConnectionStringFromUrl(string databaseUrl)
        {
            var uri = new Uri(databaseUrl);
            var splitUserInfo = uri.UserInfo.Split(':');
            var server = uri.Host;
            var port = uri.Port;
            var userId = splitUserInfo.ElementAtOrDefault(0);
            var password = splitUserInfo.ElementAtOrDefault(1);
            var database = uri.LocalPath.Substring(1);
            string ngpsqlConnectionString = $"Server={server};Port={port};User Id={userId};Password={password};Database={database};SSL Mode=Prefer;";
            return ngpsqlConnectionString;
        }
    }
}
