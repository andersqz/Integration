using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Data
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