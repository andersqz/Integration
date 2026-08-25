using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface IVendedorRepository
    {
        Task<IEnumerable<Vendedor>> SelecionarTodos();
        Task<Vendedor?> SelecionarPorId(int id);
    }
}