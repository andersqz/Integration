

using System.Data;
using System.Data.Odbc;

namespace Integration.Infra.Data
{
    public class OdbcConnectionFactory : IDbConnectionFactory, IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection? _connection;

        public OdbcConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IDbConnection> CreateConnection()
        {
            if (_connection is null)
            {
                var connection = new OdbcConnection(_connectionString);
                await connection.OpenAsync();
                _connection = connection;
            }

            return _connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}