using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;

namespace Integration.Api.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoCabecalhoDto>> BuscarTodos();
        Task<PedidoDetalhesDto> BuscarPorInfo(int local, string serie, DateOnly data, int doc); 
    }
}