using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> SelecionarTodos();
        Task<Produto?> SelecionarPorId(int id);
    }
}