using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Models
{

    /*GES_235 - PEDIDOS / ITENS
--
Empresa - EmpresaId
IPC001 - LocalId
IPC002 - Serie
IPC003 - DataEmissao
IPC004 - NumeroPedido
IPC005 - ProdutoId
IPC006 - Numero Sequencia
IPC007 - TipoProduto
IPC010 - QuantidadeOriginal
IPC011 - PreçoUnitario
IPC013 - PercentualDesconto
IPC014 - ValorDesconto
IPC015 - PercAcrescimo
IPC016 - ValorAcresimo
*/
    public class PedidoItem
    {
        public int EmpresaId { get; set; }
        public int LocalId { get; set; }
        public string Serie { get; set; }
        public DateTime DataEmissao { get; set; }
        public int NumeroPedido { get; set; }
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