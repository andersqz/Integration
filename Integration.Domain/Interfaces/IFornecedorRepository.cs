using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> SelecionarTodos();
        Task<Fornecedor?> SelecionarPorId(int id);
    }
}