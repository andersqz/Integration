using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface ITransportadoraService
    {
        Task<IEnumerable<TransportadoraDto>> BuscarTodos();
        Task<TransportadoraDto> BuscarPorId(int id);
    }
}