using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> SelecionarTodos();
        Task<Empresa?> SelecionarPorId(int id);
    }
}