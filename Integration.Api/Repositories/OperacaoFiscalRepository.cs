using Dapper;
using Integration.Api.Data;
using Integration.Api.Interfaces;
using Integration.Api.Models;

namespace Integration.Api.Repositories
{
    public class OperacaoFiscalRepository : IOperacaoFiscalRepository
    {
        private readonly IDbConnectionFactory _connection;
        public OperacaoFiscalRepository(IDbConnectionFactory connection)
            => _connection = connection;
        public async Task<OperacaoFiscal?> SelecionarPorId(int id)
        {
            string query = @"SELECT
                                Empresa as EmpresaId,
                                TOP001 AS OperacaoId,
                                TOP002 AS Descricao
                            FROM 
                                GES_064
                            WHERE
                                TOP001 = ?";
            using var connection = await _connection.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<OperacaoFiscal>(query, new {Id = id});
        }

        public async Task<IEnumerable<OperacaoFiscal>> SelecionarTodos()
        {
            string query = @"SELECT
                                Empresa as EmpresaId,
                                TOP001 AS OperacaoId,
                                TOP002 AS Descricao
                            FROM 
                                GES_064";
            using var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<OperacaoFiscal>(query);
        }
    }
}