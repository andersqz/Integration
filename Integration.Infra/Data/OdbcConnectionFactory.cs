

using System.Data;
using System.Data.Odbc;

namespace Integration.Infra.Data
{
    public class OdbcConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public OdbcConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IDbConnection> CreateConnection()
        {
            var connection = new OdbcConnection(_connectionString);

            await connection.OpenAsync();

            return connection;
        }
    }
}