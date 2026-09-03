
using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IProdutoFiscalRepository
    {
        Task<ProdutoFiscal?> SelecionarPorId(int id);
    }
}