namespace Integration.Domain.Entities
{
    public class Produto
    {
        public int EmpresaId { get; set;}
        public string ProdutoId { get; set; } = string.Empty;
        public string CodigoEAN { get; set; } = string.Empty;
        public int TipoProduto { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string DescricaoReduzida { get; set; } = string.Empty;
        public int CodigoGrupo { get; set; }
        public int CodigoSubgrupo { get; set; }
        public int CodigoMarca { get; set; }
        public int CodigoPrincipalFornecedor { get; set; }
        public string UnidadeMedida { get; set; } = string.Empty;
        public int QuantidadeUnidadeMedida { get; set; }
        public double PesoBruto { get; set; }
        public double PesoLiquido { get; set; }
        public bool ForaDeLinha { get; set; }
        public bool ControlaEstoque { get; set; }
        public int DataAlteracao { get; set; }
        public int DataCadastro { get; set; }
        public bool DisponivelInternet { get; set; }


        public Produto()
        {
            
        }
    }
}