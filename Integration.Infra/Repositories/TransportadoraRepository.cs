
using Dapper;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Infra.Data;

namespace Integration.Infra.Repositories
{
    public class TransportadoraRepository : ITransportadoraRepository
    {
        private readonly IDbConnectionFactory _connection;
        public TransportadoraRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public async Task<Transportadora> SelecionarPorId(int id)
        {
            string query = @"SELECT
                                EMPRESA AS EmpresaId,
                                TRN001 AS TransportadoraId,
                                TRN002 AS Descricao,
                                TRN003 AS Endereco,
                                TRN004 AS CEP,
                                TRN005 AS TipoPessoa,
                                TRN006 AS CpfCnpj,
                                TRN007 AS InscricaoEstadual,
                                TRN008 AS Telefone,
                                TRN010 AS Email
                            FROM
                                GES_074
                            WHERE 
                                TRN001 = ?";
            using var connection = await _connection.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Transportadora>(query, new {Id = id});
        }

        public async Task<IEnumerable<Transportadora>> SelecionarTodos()
        {
            string query = @"SELECT
                                EMPRESA AS EmpresaId,
                                TRN001 AS TransportadoraId,
                                TRN002 AS Descricao,
                                TRN003 AS Endereco,
                                TRN004 AS CEP,
                                TRN005 AS TipoPessoa,
                                TRN006 AS CpfCnpj,
                                TRN007 AS InscricaoEstadual,
                                TRN008 AS Telefone,
                                TRN010 AS Email
                            FROM
                                GES_074";
            
            using var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<Transportadora>(query);
        }
    }
}