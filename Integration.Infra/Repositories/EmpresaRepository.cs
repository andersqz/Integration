
using Dapper;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Infra.Data;

namespace Integration.Infra.Repositories
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