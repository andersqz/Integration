using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> SelecionarTodos(int pagina, int tamanhoPagina);
        Task<Fornecedor?> SelecionarPorId(int id);
        Task<int> ContarTodos();
    }
}