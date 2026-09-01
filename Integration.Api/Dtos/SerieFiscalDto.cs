using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Dtos
{
    public class SerieFiscalDto
    {
                public int EmpresaId { get; set; } // empresa
        public int LocalId { get; set; } //ser001
        public string Serie { get; set; } = string.Empty; // ser002
        public DateOnly UltimoDocEmitido { get; set; } // ser004 int date time
    }
}