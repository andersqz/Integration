using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Integration.Api.Models
{
    /*GES_068 - VENDEDORES
--
EMPRESA = EmpresaId
VEN001 - VendedorId
VEN002 - Nome
VEN003 - Tipo (V, C, R)
VEN004 - CalculaComissao?
VEN005 - PercentualComissao
VEN011 - VendedorAtivo?
VEN013 - Endereco
VEN014 - CEP
VEN015 - PF OU PJ
VEN016 - CPNJ/CPF
VEN018 - TELEFONE
VEN020 - EMAIL
VEN025 - PERC MAXIMO COMISSAO
VEN026 - PERC MAXIMO DESC*/
    public class Vendedor
    {
        public int EmpresaId { get; set; }
        public int VendedorId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public char Tipo { get; set; }
        public bool CalculaComissao { get; set; }
        public double PercentualComissao { get; set; }
        public bool VendedorAtivo { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public char TipoPessoa { get; set; }
        public string CpfCnpj { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double PercMaximoComissao { get; set; }
        public double PercMaximoDesc { get; set; }

        public Vendedor()
        {
            
        }
    }
}