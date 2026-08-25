
using Integration.Api.Dtos;

namespace Integration.Api.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaDto>> BuscarTodos();
        Task<EmpresaDto> BuscarPorId(int id);
    }
}