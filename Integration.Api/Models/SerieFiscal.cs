using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*GES_063 - Cad. Series Fiscais
--
EmpresaId = EmpresaId
SER001 - LocalId
SER002 - SerieId - nome
SER004 - UltimoDocEmitido*/

namespace Integration.Api.Models
{
    public class SerieFiscal
    {
        public int EmpresaId { get; set; } // empresa
        public int LocalId { get; set; } //ser001
        public string Serie { get; set; } = string.Empty; // ser002
        public int UltimoDocEmitido { get; set; } // ser004 int date time
    }
}