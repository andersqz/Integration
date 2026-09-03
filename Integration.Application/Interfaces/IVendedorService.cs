using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface IVendedorService
    {
        Task<IEnumerable<VendedorDto>> BuscarTodos();
        Task<VendedorDetalhesDto> BuscarPorId(int id);
    }
}