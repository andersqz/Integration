namespace IntegrationClient.WinForms.Models;

// Na sua API, EmpresaService.BuscarTodos() e BuscarPorId() devolvem o MESMO
// tipo (EmpresaDto) - diferente de Cliente/Produto/Vendedor, que têm um Dto
// "resumido" pra lista e um "*DetalhesDto" mais completo pra tela de detalhe.
public class EmpresaDto
{
    public int CodigoEmpresa { get; set; }
    public string NomeEmpresa { get; set; } = string.Empty;
    public string TipoEmpresa { get; set; } = string.Empty;
    public string NomeFantasia { get; set; } = string.Empty;
}
