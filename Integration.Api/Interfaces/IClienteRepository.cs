using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> SelecionarTodos();
        Task<Cliente?> SelecionarPorId(int id);
    }
}