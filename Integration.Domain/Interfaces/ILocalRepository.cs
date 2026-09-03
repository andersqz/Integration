using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface ILocalRepository
    {
        Task<IEnumerable<Local>> SelecionarTodos();
        Task<Local?> SelecionarPorId(int id);

    }
}