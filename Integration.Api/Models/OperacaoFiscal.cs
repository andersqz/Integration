using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Models
{
    /*
    GES_064 - Cad. Operações Fiscais
--
Empresa - EmpresaId
TOP001 - CodigoOperacao
TOP002 - DescricaoOperacao*/
    public class OperacaoFiscal
    {
        public int EmpresaId { get; set; }
        public int OperacaoId { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}