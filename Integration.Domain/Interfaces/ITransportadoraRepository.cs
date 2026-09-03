
using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface ITransportadoraRepository
    {
        Task<IEnumerable<Transportadora>> SelecionarTodos();
        Task<Transportadora> SelecionarPorId(int id);
    }
}