using Dapper;
using Integration.Api.Data;
using Integration.Api.Interfaces;
using Integration.Api.Models;

namespace Integration.Api.Repositories
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
                                EMPRESA AS IdEmpresa,
                                CLI001 AS IdCliente,
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

        public async Task<IEnumerable<Cliente>> SelecionarTodos()
        {

            string query = @"
                SET ROWCOUNT 100;

                SELECT
                    EMPRESA AS IdEmpresa,
                    CLI001 AS IdCliente,
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
            return await connection.QueryAsync<Cliente>(query);
        }
    }
}