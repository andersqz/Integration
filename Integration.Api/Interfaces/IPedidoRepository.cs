using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> SelecionarTodos();
        Task<Pedido> SelecionarPorInfo(int local, string serie, DateOnly data, int doc);
    }
}