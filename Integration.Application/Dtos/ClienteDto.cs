using System;

namespace Integration.Application.Dtos
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CpfCnpj { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

}

