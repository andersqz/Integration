using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoDto>> BuscarTodos();
        Task<ProdutoDetalhesDto> BuscarPorId(string id);
    }
}