using Integration.Application.Dtos;
namespace Integration.Application.Interfaces
{
    public interface IOperacaoFiscalService
    {
        Task<OperacaoFiscalDto?> BuscarPorId(int id);
        Task<IEnumerable<OperacaoFiscalDto>> BuscarTodos();
    }
}