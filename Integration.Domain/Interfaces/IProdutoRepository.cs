
using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> SelecionarTodos();
        Task<Produto?> SelecionarPorId(string id);
    }
}