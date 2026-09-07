using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<PaginacaoDto<PedidoDetalhesDto>> BuscarTodosComItens(int pagina, int tamanhoPagina, bool incluirItens);
        Task<PaginacaoDto<PedidoCabecalhoDto>> BuscarTodosSemItens(int pagina, int tamanhoPagina);
        Task<PedidoDetalhesDto> BuscarPorInfo(int empresa, int local, string serie, DateOnly data, int doc); 
    }
}