using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IOperacaoFiscalRepository
    {
        Task<IEnumerable<OperacaoFiscal>> SelecionarTodos();
        Task<OperacaoFiscal?> SelecionarPorId(int id);
    }
}