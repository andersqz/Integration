using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoCabecalhoDto>> BuscarTodos();
        Task<PedidoDetalhesDto> BuscarPorInfo(int local, string serie, DateOnly data, int doc); 
    }
}