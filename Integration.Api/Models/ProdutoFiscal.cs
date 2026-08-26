using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Models
{
    public class ProdutoFiscal
    {
        public string ProdutoId { get; set; } = string.Empty;     // PRD001 - FK
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
        public decimal PrecoPauta { get; set; }             // PRD117 - ICMS ST
    }
}