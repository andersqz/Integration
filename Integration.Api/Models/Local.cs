using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*-- 
EMPRESA = EmpresaId
LCL001 = LocalId
LCL002 = DescricaoLocal
LCL003 = CNPJ
LCL004 = IE
LCL005 = Endereco
LCL006 = NomeBairro
LCL007 - CEP
LCL008 - UF
LCL009 - TELEFONE
LCL011 - EMAIL
*/

namespace Integration.Api.Models
{
    public class Local
    {
       public int EmpresaId { get; set; }
       public int LocalId { get; set; }
       public string Descricao { get; set; } = string.Empty;
       public string CNPJ { get; set; } = string.Empty;
       public string InscricaoEstadual { get; set; } = string.Empty;
       public string Endereco { get; set; } = string.Empty;
       public string Bairro { get; set; } = string.Empty;
       public string CEP { get; set; } = string.Empty;
       public string UF { get; set; } = string.Empty;
       public string Telefone { get; set; } = string.Empty;
       public string Email { get; set; }  = string.Empty;

       public Local()
       {
        
       }
    }
}