using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> SelecionarTodos(int pagina, int tamanhoPagina);
        Task<Cliente?> SelecionarPorId(int id);
        Task<int> ContarTodos();
    }
}