using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Integration.Api.Data;
using Integration.Api.Interfaces;
using Integration.Api.Models;

namespace Integration.Api.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly IDbConnectionFactory _connection;
        public VendedorRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public async Task<Vendedor?> SelecionarPorId(int id)
        {
            string query = @"
                        SELECT 
                            EMPRESA AS EmpresaId, 
                            VEN001 AS VendedorId, 
                            VEN002 AS Nome, 
                            VEN003 AS Tipo, 
                            VEN004 AS CalculaComissao, 
                            VEN005 AS PercentualComissao, 
                            VEN011 AS VendedorAtivo, 
                            VEN013 AS Endereco, 
                            VEN014 as CEP, 
                            VEN015 AS TipoPessoa, 
                            VEN016 AS CpfCnpj, 
                            VEN018 AS Telefone, 
                            VEN020 AS Email, 
                            VEN025 AS PercMaximoComissao, 
                            VEN026 AS PercMaximoDesc 
                        FROM 
                            GES_068 
                        WHERE 
                            VEN001 = ?
                        ORDER BY 
                            VendedorId";

            using var connection = await _connection.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Vendedor>(query, new { VendedorId = id });
        }

        public async Task<IEnumerable<Vendedor>> SelecionarTodos()
        {
            string query = @"
                        SELECT 
                            EMPRESA AS EmpresaId, 
                            VEN001 AS VendedorId, 
                            VEN002 AS Nome, 
                            VEN003 AS Tipo, 
                            VEN004 AS CalculaComissao, 
                            VEN005 AS PercentualComissao, 
                            VEN011 AS VendedorAtivo, 
                            VEN013 AS Endereco, 
                            VEN014 as CEP, 
                            VEN015 AS TipoPessoa, 
                            VEN016 AS CpfCnpj, 
                            VEN018 AS Telefone, 
                            VEN020 AS Email, 
                            VEN025 AS PercMaximoComissao, 
                            VEN026 AS PercMaximoDesc 
                        FROM 
                            GES_068 
                        ORDER BY 
                            VendedorId";

            using var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<Vendedor>(query);
        }
    }
}