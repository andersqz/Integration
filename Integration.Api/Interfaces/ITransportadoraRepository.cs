using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface ITransportadoraRepository
    {
        Task<IEnumerable<Transportadora>> SelecionarTodos();
        Task<Transportadora> SelecionarPorId(int id);
    }
}