using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<PaginacaoDto<ProdutoDto>> BuscarTodos(int pagina, int tamanhoPagina);
        Task<ProdutoDetalhesDto> BuscarPorId(string id);
    }
}