using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Models;

namespace Integration.Api.Interfaces
{
    public interface ISerieFiscalRepository
    {
        Task<IEnumerable<SerieFiscal>> SelecionarTodos();
        Task<SerieFiscal?> SelecionarPorSerie(string serie);
    }
}