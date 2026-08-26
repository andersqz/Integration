using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Dtos
{
    public class VendedorDetalhesDto
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
    }
}