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
    public class EmpresaRepository : IEmpresaRepository
    {

        private readonly IDbConnectionFactory _connection;
        public EmpresaRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public async Task<Empresa?> SelecionarPorId(int id)
        {
            string query = @"SELECT 
                                CodigoEmpresa, NomeEmpresa, TipoEmpresa, NomeFantasia 
                            FROM 
                                EMPRESAS
                            WHERE
                                CodigoEmpresa = ?
                            ORDER BY 
                                CodigoEmpresa";

            using var connection = await _connection.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Empresa>(query, new { CodigoEmpresa = id });
        }

        public async Task<IEnumerable<Empresa>> SelecionarTodos()
        {
            string query = @"SELECT 
                                CodigoEmpresa, 
                                NomeEmpresa, 
                                TipoEmpresa, 
                                NomeFantasia 
                            FROM 
                                EMPRESAS
                            ORDER BY 
                                CodigoEmpresa";

            using var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<Empresa>(query);
        }
    }
}