using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Dapper;
using Integration.Api.Data;
using Integration.Api.Interfaces;
using Integration.Api.Models;

namespace Integration.Api.Repositories
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
            return await connection.QuerySingleOrDefaultAsync<Fornecedor>(query, new {Id = id});
        }

        public async Task<IEnumerable<Fornecedor>> SelecionarTodos()
        {
            string query = @"
                            SET ROWCOUNT 100;
                            
                            SELECT 
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
            return await connection.QueryAsync<Fornecedor>(query);
        }
    }
}