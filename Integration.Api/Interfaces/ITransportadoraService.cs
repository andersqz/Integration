using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;

namespace Integration.Api.Interfaces
{
    public interface ITransportadoraService
    {
        Task<IEnumerable<TransportadoraDto>> BuscarTodos();
        Task<TransportadoraDto> BuscarPorId(int id);
    }
}