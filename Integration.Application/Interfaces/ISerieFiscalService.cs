using Integration.Application.Dtos;

namespace Integration.Application.Interfaces
{
    public interface ISerieFiscalService
    {
        Task<IEnumerable<SerieFiscalDto>> BuscarTodos();
        Task<SerieFiscalDto> BuscarPorSerie(string serie);
    }
}