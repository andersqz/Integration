
using Integration.Domain.Entities;

namespace Integration.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> SelecionarTodos(int pagina, int tamanhoPagina);
        Task<Pedido?> SelecionarPorInfo(int empresa, int local, string serie, int data, int doc);
        Task<int> ContarTodos();
    }
}