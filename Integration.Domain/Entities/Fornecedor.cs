
namespace Integration.Domain.Entities
{/*GES_042 - Cad. Fornecedor
-- 
Empresa - EmpresaId
FOR001 - FornecedorId
FOR002 - NomeFornecedor
FOR007 - CNPJ/CPF]
FOR008 - IE
FOR009 - TELEFONE
FOR011 - EMAIL
*/
    public class Fornecedor
    {
        public int EmpresaId { get; set; }
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Telefone { get; set; }    
        public string Email { get; set; }
    }
}