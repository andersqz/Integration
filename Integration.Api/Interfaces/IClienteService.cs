using Integration.Api.Dtos;
using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> BuscarTodos();
        Task<ClienteDetalhesDto> BuscarPorId(int id);
    }
}