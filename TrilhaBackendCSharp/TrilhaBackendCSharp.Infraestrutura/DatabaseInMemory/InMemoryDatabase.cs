using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System.Data;

namespace TrilhaBackendCSharp.Infraestrutura.DatabaseInMemory
{
    internal class InMemoryDatabase
    {
        private readonly OrmLiteConnectionFactory _dbFactory =
           new OrmLiteConnectionFactory(":memory:", SqliteOrmLiteDialectProvider.Instance);

        public IDbConnection Connection { get; }

        public InMemoryDatabase()
        {
            Connection = _dbFactory.OpenDbConnection();
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            using (var connection = this.Connection)
            {
                Connection.ExecuteSql(Create.CREATE_DATABASE_IN_MEMORY);
            }
        }
    }
}
