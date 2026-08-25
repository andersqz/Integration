using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Dtos
{
    public class VendedorDto
    {
        public int VendedorId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public char Tipo { get; set; }
        public bool VendedorAtivo { get; set; }
        public string CpfCnpj { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }
}