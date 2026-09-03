using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface IPedidoItemRepository
    {
        Task<IEnumerable<PedidoItem>> SelecionarPorInfo(int local, string serie, int data, int doc);
    }
}