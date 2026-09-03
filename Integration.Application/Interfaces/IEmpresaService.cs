
using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaDto>> BuscarTodos();
        Task<EmpresaDto> BuscarPorId(int id);
    }
}