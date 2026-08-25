namespace IntegrationClient.WinForms.Models;

public class ProdutoDto
{
    // Atenção: IdProduto é STRING aqui (a API faz CAST(PRD001 AS VARCHAR) no banco),
    // mas o endpoint GetById(int id) espera um número. Ou seja: o valor exibido
    // é texto, mas pra buscar detalhes você converte de volta pra int.
    public string IdProduto { get; set; } = string.Empty;
    public string CodigoEAN { get; set; } = string.Empty;
    public int TipoProduto { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public bool ForaDeLinha { get; set; }
    public DateOnly DataAlteracao { get; set; }
}
