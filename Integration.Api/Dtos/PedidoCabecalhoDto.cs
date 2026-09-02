using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Api.Dtos
{
    public class PedidoCabecalhoDto
    {
                public int EmpresaId { get; set; }
        public int LocalId { get; set; }
        public string Serie { get; set; } = string.Empty;
        public int DataEmissao { get; set; }
        public int Documento { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public int UltimaAlteracao { get; set; }
        public string NomeCliente { get; set; }
    }
}