
using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface ISerieFiscalRepository
    {
        Task<IEnumerable<SerieFiscal>> SelecionarTodos();
        Task<SerieFiscal?> SelecionarPorSerie(string serie);
    }
}