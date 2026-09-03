using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Application.Dtos
{
    public class EmpresaDto
    {
        public int CodigoEmpresa { get; set; }
        public string NomeEmpresa { get; set; } = string.Empty;
        public string TipoEmpresa { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
    }
}