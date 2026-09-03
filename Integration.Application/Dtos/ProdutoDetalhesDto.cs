namespace Integration.Application.Dtos
{
    public class ProdutoDetalhesDto
    {
        public int IdEmpresa { get; set; }
        public string IdProduto { get; set; } = string.Empty;
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
        public DateOnly? DataAlteracao { get; set; }
        public DateOnly? DataCadastro { get; set; }
        public bool DisponivelInternet { get; set; }


        // fiscal
        public bool IcmsSubstituicaoCompra { get; set; }  // PRD013
        public bool IcmsSubstituicaoVenda { get; set; }   // PRD014
        public decimal PercentualIcmsSubstituicao { get; set; } // PRD015
        public string ClassificacaoFiscalIcms { get; set; } = string.Empty; // PRD028
        public string Ncm { get; set; } = string.Empty;                    // PRD029
        public string Cst { get; set; } = string.Empty;                     // PRD047
        public string CodigoClassificacaoCofins { get; set; } = string.Empty; // PRD119
        public string CodigoClassificacaoPis { get; set; } = string.Empty;    // PRD136
        public int OrigemMercadoria { get; set; }          // PRD145 - 0-Nacional 1/2-Estrangeira
        public string Cest { get; set; } = string.Empty;                    // PRD178
        public decimal PrecoPauta { get; set; }
    }
}