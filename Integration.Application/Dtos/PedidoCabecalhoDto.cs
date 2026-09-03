

namespace Integration.Application.Dtos
{
    public class PedidoCabecalhoDto
    {
                public int EmpresaId { get; set; }
        public int LocalId { get; set; }
        public string Serie { get; set; } = string.Empty;
        public DateOnly DataEmissao { get; set; }
        public int Documento { get; set; }
         public string NomeCliente { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public DateOnly UltimaAlteracao { get; set; }
  
    }
}