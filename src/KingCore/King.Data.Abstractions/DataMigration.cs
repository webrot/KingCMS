using YesSql.Sql;

namespace King.Data.Migration
{
    public abstract class DataMigration : IDataMigration
    {
        public SchemaBuilder SchemaBuilder { get; set; }
    }
}
