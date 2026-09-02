

namespace Integration.Api.Dtos
{
    public class PedidoDetalhesDto
    {
        public int EmpresaId { get; set; }
        public int LocalId { get; set; }
        public string Serie { get; set; } = string.Empty;
        public int DataEmissao { get; set; }
        public int Documento { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public int OperacaoFiscal { get; set; }
        public int UltimaAlteracao { get; set; }
        public string NomeCliente { get; set; }
        public string EnderecoCliente { get; set; }
        public string CepCliente { get; set; }
        public string CidadeCliente { get; set; }
        public string UF { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public char TipoPessoa { get; set; }
        public string Telefone { get; set; }
        public int TransportadoraId { get; set; }


        // itens
        public int ProdutoId { get; set; }
        public int NumeroSequencia { get; set; }
        public int TipoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public double PercDesconto { get; set; }
        public decimal ValorDesconto { get; set; }
        public double PercAcrescimo { get; set; }
        public decimal ValorAcrescimo { get; set; }
    }
}