
using Dapper;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Infra.Data;

namespace Integration.Infra.Repositories
{
    public class SerieFiscalRepository : ISerieFiscalRepository
    {
        private readonly IDbConnectionFactory _connection;
        public SerieFiscalRepository(IDbConnectionFactory connection)
            => _connection = connection;
        public async Task<SerieFiscal?> SelecionarPorSerie(string serie)
        {
            string query = @"SELECT
                                EMPRESA AS EmpresaId,
                                SER001 AS LocalId,
                                SER002 AS Serie,
                                SER004 AS UltimoDocEmitido
                            FROM
                                GES_063
                            WHERE 
                                UPPER(SER002) = UPPER(?)";

            using var connection = await _connection.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<SerieFiscal>(query, new {Serie = serie});
        }

        public async Task<IEnumerable<SerieFiscal>> SelecionarTodos()
        {
            string query = @"SELECT
                                EMPRESA AS EmpresaId,
                                SER001 AS LocalId,
                                SER002 AS Serie,
                                SER004 AS UltimoDocEmitido
                            FROM
                                GES_063";

            using var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<SerieFiscal>(query);
        }
    }
}