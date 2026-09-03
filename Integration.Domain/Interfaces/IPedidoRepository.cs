
using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> SelecionarTodos();
        Task<Pedido?> SelecionarPorInfo(int empresa, int local, string serie, int data, int doc);
    }
}