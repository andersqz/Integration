
namespace Integration.Application.Dtos
{
    public class TransportadoraDto
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