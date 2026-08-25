namespace Integration.Api.Models
{
    public class Empresa
    {
        public int CodigoEmpresa { get; set; }
        public string NomeEmpresa { get; set; } = string.Empty;
        public string TipoEmpresa { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
    }
}