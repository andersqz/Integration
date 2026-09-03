using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> SelecionarTodos();
        Task<Cliente?> SelecionarPorId(int id);
    }
}