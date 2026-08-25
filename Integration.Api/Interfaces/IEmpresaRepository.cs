using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> SelecionarTodos();
        Task<Empresa?> SelecionarPorId(int id);
    }
}