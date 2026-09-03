
namespace Integration.Application.Dtos
{
    public class ProdutoDto
    {
        public string IdProduto { get; set; } = string.Empty;
        public string CodigoEAN { get; set; }
        public int TipoProduto { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public bool ForaDeLinha { get; set; }
        public DateOnly DataAlteracao { get; set; }
    }
}