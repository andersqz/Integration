
using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface IOperacaoFiscalRepository
    {
        Task<IEnumerable<OperacaoFiscal>> SelecionarTodos();
        Task<OperacaoFiscal?> SelecionarPorId(int id);
    }
}