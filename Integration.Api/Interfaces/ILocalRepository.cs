using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface ILocalRepository
    {
        Task<IEnumerable<Local>> SelecionarTodos();
        Task<Local?> SelecionarPorId(int id);

    }
}