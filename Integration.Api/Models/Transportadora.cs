using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Integration.Api.Models
{/*
GES_074 - CAD. TRANSPORTADORES
--
Empresa - EmpresaId
TRN001 - CodigoTransportador
TRN002 - Descricao
TRN003 - Endereco
TRN004 - CEP
TRN005 - TipoPessoa
TRN006 - CPF/CNPJ
TRN007 - IE
TRN008 - FONE
TRN010 - EMAIL*/
    public class Transportadora
    {
        public int EmpresaId { get; set; }
        public int TransportadoraId { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public char TipoPessoa { get; set; }    
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}