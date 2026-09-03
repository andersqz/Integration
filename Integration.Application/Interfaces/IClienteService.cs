

using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> BuscarTodos();
        Task<ClienteDetalhesDto> BuscarPorId(int id);
    }
}