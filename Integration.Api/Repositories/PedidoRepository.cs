using Dapper;
using Integration.Api.Data;
using Integration.Api.Interfaces;
using Integration.Api.Models;

namespace Integration.Api.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDbConnectionFactory _connection;
        public PedidoRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public async Task<Pedido?> SelecionarPorInfo(int local, string serie, int data, int doc)
        {
            string query = @"SELECT
                                EMPRESA AS EmpresaId,
                                NPC001 AS LocalId,
                                NPC002 AS Serie,
                                NPC003 AS DataEmissao,
                                NPC004 AS Documento,
                                NPC005 AS ClienteId,
                                NPC006 AS VendedorId,
                                NPC007 AS OperacaoFiscal,
                                NPC011 AS UltimaAlteracao,
                                NPC080 AS NomeCliente,
                                NPC081 AS EnderecoCliente,
                                NPC082 AS CepCliente,
                                NPC083 AS CidadeCliente,
                                NPC084 AS UF,
                                NPC085 AS CpfCnpj,
                                NPC086 AS InscricaoEstadual,
                                NPC087 AS TipoPessoa,
                                NPC089 AS Telefone,
                                NPC050 AS TransportadoraId
                            FROM
                                GES_230
                            WHERE
                                NPC001 = ?
                            AND
                                NPC002 = ?
                            AND 
                                NPC003 = ?
                            AND 
                                NPC004 = ?";
            
            using var connection = await _connection.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Pedido>(query, new {NPC001 = local, NPC002 = serie, NPC003 = data, NPC004 = doc});
        }

        public async Task<IEnumerable<Pedido>> SelecionarTodos()
        {
            string query = @"
                            SET ROWCOUNT 10;
                            SELECT
                                EMPRESA AS EmpresaId,
                                NPC001 AS LocalId,
                                NPC002 AS Serie,
                                NPC003 AS DataEmissao,
                                NPC004 AS Documento,
                                NPC005 AS ClienteId,
                                NPC006 AS VendedorId,
                                NPC007 AS OperacaoFiscal,
                                NPC011 AS UltimaAlteracao,
                                NPC080 AS NomeCliente,
                                NPC081 AS EnderecoCliente,
                                NPC082 AS CepCliente,
                                NPC083 AS CidadeCliente,
                                NPC084 AS UfCliente,
                                NPC085 AS CpfCnpj,
                                NPC086 AS InscricaoEstadual,
                                NPC087 AS TipoPessoa,
                                NPC089 AS Telefone,
                                NPC050 AS TransportadoraId
                            FROM
                                GES_230";

            using var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<Pedido>(query);
        }
    }
}