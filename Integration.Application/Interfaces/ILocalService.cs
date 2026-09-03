using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface ILocalService
    {
        Task<IEnumerable<LocalDto>> BuscarTodos();
        Task<LocalDto> BuscarPorId(int id);
    }
}