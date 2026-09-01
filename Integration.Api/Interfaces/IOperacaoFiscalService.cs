using Integration.Api.Dtos;
using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface IOperacaoFiscalService
    {
        Task<OperacaoFiscalDto?> BuscarPorId(int id);
        Task<IEnumerable<OperacaoFiscalDto>> BuscarTodos();
    }
}