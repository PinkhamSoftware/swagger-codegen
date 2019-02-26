using PeregrineDb.Schema;

namespace HomesEngland.Gateway.Sql.Postgres
{
    public class PascalCaseColumnNameFactory : IColumnNameFactory
    {
        public string GetColumnName(PropertySchema property)
        {
            return property.Name;
        }
    }
}
