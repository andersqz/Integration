

namespace Integration.Application.Dtos
{
    public class PedidoDetalhesDto
    {
        public int EmpresaId { get; set; }
        public int LocalId { get; set; }
        public string Serie { get; set; } = string.Empty;
        public DateOnly? DataEmissao { get; set; }
        public int Documento { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public int OperacaoFiscal { get; set; }
        public DateOnly? UltimaAlteracao { get; set; }
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

        public List<PedidoItemDto> Itens {get;set;} = new();
        
    }
}