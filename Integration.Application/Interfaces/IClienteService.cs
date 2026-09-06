

using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface IClienteService
    {
        Task<PaginacaoDto<ClienteDto>> BuscarTodos(int pagina, int tamanhoPagina);
        Task<ClienteDetalhesDto> BuscarPorId(int id);
    }
}