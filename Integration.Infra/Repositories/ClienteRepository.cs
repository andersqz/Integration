using Dapper;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Infra.Data;

namespace Integration.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnectionFactory _connection;
        public ClienteRepository(IDbConnectionFactory connection)
        {
            _connection = connection;
        }

        public async Task<Cliente?> SelecionarPorId(int id)
        {
            string query = @"SELECT
                                EMPRESA AS EmpresaId,
                                CLI001 AS ClienteId,
                                CLI002 AS Nome,
                                CLI003 AS NomeFantasia,
                                CLI004 AS Endereco,
                                CLI005 AS Bairro,
                                CLI006 AS CEP,
                                CLI007 AS TipoPessoa,
                                CLI008 AS CpfCnpj,
                                CLI009 AS InscricaoEstadual,
                                CLI010 AS Telefone,
                                CLI012 AS Email,
                                CLI013 AS DataNascimento,
                                CLI014 AS Sexo,
                                CLI095 AS Cidade
                            FROM
                                GES_040
                            WHERE 
                                CLI001 = ?";

            using var connection = await _connection.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Cliente>(query, new { Id = id });
        }

        public async Task<IEnumerable<Cliente>> SelecionarTodos(int pagina, int tamanhoPagina)
        {
            int startAt = ((pagina - 1) * tamanhoPagina) + 1;

            string query = @"

                SELECT TOP ? START AT ?
                    EMPRESA AS EmpresaId,
                    CLI001 AS ClienteId,
                    CLI002 AS Nome,
                    CLI003 AS NomeFantasia,
                    CLI004 AS Endereco,
                    CLI005 AS Bairro,
                    CLI006 AS CEP,
                    CLI007 AS TipoPessoa,
                    CLI008 AS CpfCnpj,
                    CLI009 AS InscricaoEstadual,
                    CLI010 AS Telefone,
                    CLI012 AS Email,
                    CLI013 AS DataNascimento,
                    CLI014 AS Sexo,
                    CLI095 AS Cidade
                FROM
                    GES_040
                ORDER BY 
                    CLI001;
            ";

            using var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<Cliente>(query, new {Top = tamanhoPagina, StartAt = startAt});
        }


        public async Task<int> ContarTodos()
        {
            string query = "SELECT COUNT(*) FROM GES_040";

            using var connection = await _connection.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(query);
        }
    }
}