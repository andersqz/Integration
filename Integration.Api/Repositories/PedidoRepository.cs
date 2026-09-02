using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Data;
using Integration.Api.Interfaces;
using Integration.Api.Models;

namespace Integration.Api.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDbConnectionFactory _connection;
        public PedidoRepository(IDbConnectionFactory connection)
            => _connection = connection;

        public Task<Pedido> SelecionarPorInfo(int local, string serie, DateOnly data, int doc)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pedido>> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}