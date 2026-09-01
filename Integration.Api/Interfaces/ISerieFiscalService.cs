using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;

namespace Integration.Api.Interfaces
{
    public interface ISerieFiscalService
    {
        Task<IEnumerable<SerieFiscalDto>> BuscarTodos();
        Task<SerieFiscalDto> BuscarPorSerie(string serie);
    }
}