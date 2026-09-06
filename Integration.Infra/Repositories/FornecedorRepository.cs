

using Dapper;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Infra.Data;

namespace Integration.Infra.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly IDbConnectionFactory _connection;
        public FornecedorRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public async Task<Fornecedor?> SelecionarPorId(int id)
        {
            string query = @"SELECT 
                                EMPRESA AS EmpresaId,
                                FOR001 AS FornecedorId,
                                FOR002 AS Nome,
                                FOR007 AS CpfCnpj,
                                FOR008 AS InscricaoEstadual,
                                FOR009 AS Telefone,
                                FOR011 AS Email
                            FROM
                                GES_042
                            WHERE
                                FOR001 = ?";
            using var connection = await _connection.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Fornecedor>(query, new { Id = id });
        }

        public async Task<IEnumerable<Fornecedor>> SelecionarTodos(int pagina, int tamanhoPagina)
        {
            int startAt = ((pagina - 1) * tamanhoPagina) + 1;

            string query = @"
                            
                            SELECT TOP ? START AT ?
                                EMPRESA AS EmpresaId,
                                FOR001 AS FornecedorId,
                                FOR002 AS Nome,
                                FOR007 AS CpfCnpj,
                                FOR008 AS InscricaoEstadual,
                                FOR009 AS Telefone,
                                FOR011 AS Email
                            FROM
                                GES_042";
            using var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<Fornecedor>(query, new { Top = tamanhoPagina, StartAt = startAt });
        }


        public async Task<int> ContarTodos()
        {
            string query = "SELECT COUNT(*) FROM GES_040";

            using var connection = await _connection.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(query);
        }
    }
}