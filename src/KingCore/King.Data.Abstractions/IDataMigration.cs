using YesSql.Sql;

namespace King.Data.Migration
{
    public interface IDataMigration
    {
        SchemaBuilder SchemaBuilder { get; set; }
    }
}