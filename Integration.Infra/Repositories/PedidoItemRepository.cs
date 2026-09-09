using Dapper;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Infra.Data;

namespace Integration.Infra.Repositories
{
    public class PedidoItemRepository : IPedidoItemRepository
    {
        private readonly IDbConnectionFactory _connection;
        public PedidoItemRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public async Task<IEnumerable<PedidoItem>> SelecionarPorInfo(int empresa, int local, string serie, int data, int doc)
        {
            string query = @"SELECT
                                EMPRESA AS EmpresaId,
                                IPC001 AS LocalId,
                                IPC002 AS Serie,
                                IPC003 AS DataEmissao,
                                IPC004 AS Documento,
                                IPC005 AS ProdutoId,
                                IPC006 AS SequenciaItem,
                                IPC007 AS TipoProduto,
                                IPC010 AS Quantidade,
                                IPC011 AS PrecoUnitario,
                                IPC013 AS PercDesconto,
                                IPC014 AS ValorDesconto,
                                IPC015 AS PercAcrescimo,
                                IPC016 AS ValorAcrescimo
                            FROM 
                                GES_235
                            WHERE IPC001 = ?
                            AND EMPRESA = ?
                            AND IPC002 = ?
                            AND IPC003 = ?
                            AND IPC004 = ?";

            var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<PedidoItem>(query,
                new { IPC001 = local, EMPRESA = empresa, IPC002 = serie, IPC003 = data, IPC004 = doc });
            //        1ª = 1º ?        2ª = 2º ?         3ª = 3º ?       4ª = 4º ?      5ª = 5º ?
        }
    }
}