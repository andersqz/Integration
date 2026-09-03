namespace Integration.Application.Dtos
{
    public class ClienteDetalhesDto
    {
        public int EmpresaId { get; set; }
        public int ClienteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public char TipoPessoa { get; set; }
        public string CpfCnpj { get; set; } = string.Empty;
        public string InscricaoEstadual { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly? DataNascimento { get; set; }
        public string? Sexo { get; set; }
        public string Cidade { get; set; } = string.Empty;
    }
}