using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorDto>> BuscarTodos();
        Task<FornecedorDto> BuscarPorId(int id);
    }
}