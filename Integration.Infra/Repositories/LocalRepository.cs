
using Dapper;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Infra.Data;

namespace Integration.Infra.Repositories
{
    public class LocalRepository : ILocalRepository
    {
        private readonly IDbConnectionFactory _connection;
        public LocalRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public async Task<Local?> SelecionarPorId(int id)
        {
            string query = @"
                            SELECT 
                                EMPRESA AS EmpresaId, 
                                LCL001 AS LocalId, 
                                LCL002 AS Descricao, 
                                LCL003 AS CNPJ, 
                                LCL004 AS InscricaoEstadual, 
                                LCL005 AS Endereco, 
                                LCL006 AS Bairro, 
                                LCL007 AS CEP, 
                                LCL008 AS UF, 
                                LCL009 AS Telefone, 
                                LCL011 AS Email 
                            FROM 
                                GES_008 
                            WHERE
                                LCL001 = ?
                            ORDER BY
                                LocalId";

            var connection = await _connection.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Local>(query, new { LocalId = id });
        }

        public async Task<IEnumerable<Local>> SelecionarTodos()
        {
            string query = @"
                            SELECT 
                                EMPRESA AS EmpresaId, 
                                LCL001 AS LocalId, 
                                LCL002 AS Descricao, 
                                LCL003 AS CNPJ, 
                                LCL004 AS InscricaoEstadual, 
                                LCL005 AS Endereco, 
                                LCL006 AS Bairro, 
                                LCL007 AS CEP, 
                                LCL008 AS UF, 
                                LCL009 AS Telefone, 
                                LCL011 AS Email 
                            FROM 
                                GES_008 
                            ORDER BY 
                                LocalId";
            var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<Local>(query);
        }
    }
}