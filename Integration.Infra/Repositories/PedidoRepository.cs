using Dapper;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Infra.Data;

namespace Integration.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDbConnectionFactory _connection;
        public PedidoRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public async Task<Pedido?> SelecionarPorInfo(int empresa, int local, string serie, int data, int doc)
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
                                Trim(NPC081) AS EnderecoCliente,
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
                                EMPRESA = ?
                            AND
                                NPC002 = ?
                            AND 
                                NPC003 = ?
                            AND 
                                NPC004 = ?";

            var connection = await _connection.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Pedido>(query,
                new { NPC001 = local, EMPRESA = empresa, NPC002 = serie, NPC003 = data, NPC004 = doc });
        }

        public async Task<IEnumerable<Pedido>> SelecionarTodos(int pagina, int tamanhoPagina)
        {
            int startAt = ((pagina - 1) * tamanhoPagina) + 1;

            string query = @"
                            
                            SELECT TOP ? START AT ?
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
                            ORDER BY
                                EMPRESA, NPC001, NPC002, NPC003, NPC004";

            var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<Pedido>(query, new { Top = tamanhoPagina, StartAt = startAt });
        }

        public async Task<int> ContarTodos()
        {
            string query = "SELECT COUNT(*) FROM GES_230";

            var connection = await _connection.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(query);
        }
    }
}