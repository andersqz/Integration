
using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        Task<IEnumerable<Vendedor>> SelecionarTodos();
        Task<Vendedor?> SelecionarPorId(int id);
    }
}