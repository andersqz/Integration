namespace IntegrationClient.WinForms.Models;

// Este DTO precisa ter EXATAMENTE os mesmos nomes de propriedade que a Integration.Api
// devolve no JSON de GET /api/cliente, porque o desserializador (System.Text.Json)
// casa por nome de propriedade. Se um nome aqui não bater com o da API, o campo
// simplesmente chega nulo/zero, sem erro nenhum — fica atento nisso ao debugar.
//
// Hoje isso é uma classe duplicada entre API e WinForms. Se o projeto crescer,
// vale extrair Cliente*Dto para um projeto "Integration.Contracts" (class library)
// referenciado pelos dois lados, e essa duplicação desaparece.
public class ClienteDto
{
    public int IdCliente { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
