using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<PaginacaoDto<PedidoDetalhesDto>> BuscarTodos(int pagina, int tamanhoPagina, bool incluirItens);
        Task<PedidoDetalhesDto> BuscarPorInfo(int empresa, int local, string serie, DateOnly data, int doc); 
    }
}