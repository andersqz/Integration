
namespace Integration.Application.Dtos
{
    public class OperacaoFiscalDto
    {
        public int EmpresaId { get; set; }
        public int OperacaoId { get; set; }
        public string Descricao { get; set; } = string.Empty;


        public OperacaoFiscalDto(int empresa, int op, string desc)
        {
            EmpresaId = empresa;
            OperacaoId = op;
            Descricao = desc;
        }
    }
}