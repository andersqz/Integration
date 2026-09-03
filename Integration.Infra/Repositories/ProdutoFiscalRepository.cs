

using Dapper;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Infra.Data;

namespace Integration.Infra.Repositories
{
    public class ProdutoFiscalRepository : IProdutoFiscalRepository
    {
        private readonly IDbConnectionFactory _connection;
        public ProdutoFiscalRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public async Task<ProdutoFiscal?> SelecionarPorId(string id)
        {
            string query = @"
                SELECT 
                    CAST(PRD001 AS VARCHAR(50)) AS ProdutoId,
                    PRD013 AS IcmsSubstituicaoCompra,
                    PRD014 AS IcmsSubstituicaoVenda,
                    PRD015 AS PercentualIcmsSubstituicao,
                    PRD028 AS ClassificacaoFiscalIcms,
                    PRD029 AS Ncm,
                    PRD047 AS Cst,
                    PRD119 AS CodigoClassificacaoCofins,
                    PRD136 AS CodigoClassificacaoPis,
                    PRD145 AS OrigemMercadoria,
                    PRD178 AS Cest,
                    PRD117 AS PrecoPauta
                FROM
                    GES_080
                WHERE 
                    CAST(PRD001 AS VARCHAR(50)) = ?";

            using var connection = await _connection.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<ProdutoFiscal>(query, new { Id = id.ToString() });
        }
    }
}