
namespace Integration.Domain.Entities
{
    /*GES_230 - PEDIDOS / CABEÇALHO
--
Empresa - EmpresaId
NPC001 - LocalId
NPC002 - Serie
NPC003 - DataEmissao
NPC004 - NumeroPedido
NPC005 - ClienteId
NPC006 - VendedorId
NPC007 - OperacaoFiscal
NPC011 - UltimaAlteracao
NPC080 - NomeCliente
NPC081 - EnderecoCliente
NPC082 - CEPcliente
NPC083 - CidadeCliente
NPC084 - UF CLIENTE
NPC085 - CpfCnpjCliente
NPC086 - IE
NPC087 - TipoPessoa
NPC089 - FoneCliente*/
    public class Pedido
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
    }
}