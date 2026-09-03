

using Dapper;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Infra.Data;

namespace Integration.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnectionFactory _connection;
        public ProdutoRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public async Task<Produto?> SelecionarPorId(string id)
        {
            string query = @"
                SELECT 
                    EMPRESA AS EmpresaId,
                    CAST(PRD001 AS VARCHAR(50)) AS ProdutoId,
                    PRD005 AS CodigoEAN,
                    PRD007 AS TipoProduto,
                    PRD008 AS Descricao,
                    PRD009 AS DescricaoReduzida,
                    PRD010 AS CodigoGrupo,
                    PRD011 AS CodigoSubgrupo,
                    PRD030 AS CodigoMarca,
                    PRD031 AS CodigoPrincipalFornecedor,
                    PRD032 AS UnidadeMedida,
                    PRD033 AS QuantidadeUnidadeMedida,
                    PRD037 AS PesoBruto,
                    PRD038 AS PesoLiquido,
                    PRD048 AS ForaDeLinha,
                    PRD049 AS ControlaEstoque,
                    PRD059 AS DataAlteracao,
                    PRD077 AS DataCadastro
                FROM
                    GES_080
                WHERE 
                    CAST(PRD001 AS VARCHAR(50)) = ?";

            using var connection = await _connection.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Produto>(query, new {Id = id.ToString()});
        }
        public async Task<IEnumerable<Produto>> SelecionarTodos()
        {
            string query = @"
                SET ROWCOUNT 100;

                SELECT 
                    EMPRESA AS EmpresaId,
                    CAST(PRD001 AS VARCHAR(50)) AS ProdutoId,
                    PRD005 AS CodigoEAN,
                    PRD007 AS TipoProduto,
                    PRD008 AS Descricao,
                    PRD009 AS DescricaoReduzida,
                    PRD010 AS CodigoGrupo,
                    PRD011 AS CodigoSubgrupo,
                    PRD030 AS CodigoMarca,
                    PRD031 AS CodigoPrincipalFornecedor,
                    PRD032 AS UnidadeMedida,
                    PRD033 AS QuantidadeUnidadeMedida,
                    PRD037 AS PesoBruto,
                    PRD038 AS PesoLiquido,
                    PRD048 AS ForaDeLinha,
                    PRD049 AS ControlaEstoque,
                    PRD059 AS DataAlteracao,
                    PRD077 AS DataCadastro
                FROM
                    GES_080
                ORDER BY
                    PRD001;";

            using var connection = await _connection.CreateConnection();
            return await connection.QueryAsync<Produto>(query);
        }
    }
}