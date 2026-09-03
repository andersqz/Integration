

namespace Integration.Application.Dtos
{
    public class PedidoItemDto
    {
                public string ProdutoId { get; set; }
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