using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface IFornecedorService
    {
        Task<PaginacaoDto<FornecedorDto>> BuscarTodos(int pagina, int tamanhoPagina);
        Task<FornecedorDto> BuscarPorId(int id);
    }
}