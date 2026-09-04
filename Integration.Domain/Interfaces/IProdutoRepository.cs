
using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> SelecionarTodos(int pagina, int tamanhoPagina);
        Task<Produto?> SelecionarPorId(string id);
        Task<int> ContarTodos();
    }
}