using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Integration.Api.Data;
using Integration.Api.Interfaces;
using Integration.Api.Models;

namespace Integration.Api.Repositories
{
    public class PedidoItemRepository : IPedidoItemRepository
    {
        private readonly IDbConnectionFactory _connection;
        public PedidoItemRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public async Task<IEnumerable<PedidoItem>> SelecionarPorInfo(int local, string serie, int data, int doc)
        {
            string query = @"SELECT
                                EMPRESA AS EmpresaId,
                                IPC001 AS LocalId,
                                IPC002 AS Serie,
                                IPC003 AS DataEmissao,
                                IPC004 AS Documento,
                                IPC005 AS ProdutoId,
                                IPC006 AS SequenciaItem,
                                IPC007 AS TipoItem,
                                IPC010 AS Quantidade,
                                IPC011 AS PrecoUnitario,
                                IPC013 AS PercDesconto,
                                IPC014 AS ValorDesconto,
                                IPC015 AS PercAcrescimo,
                                IPC016 AS ValorAcrescimo
                            FROM 
                                GES_235
                            WHERE IPC001 = ?
                            AND IPC002 = ?
                            AND IPC003 = ?
                            AND IPC004 = ?";
            
            using var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<PedidoItem>(query, new { IPC001 = local, IPC002 = serie, IPC003 = data, IPC004 = doc });
        }
    }
}