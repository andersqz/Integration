using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;

namespace Integration.Api.Interfaces
{
    public interface IVendedorService
    {
        Task<IEnumerable<VendedorDto>> SelecionarTodos();
        Task<VendedorDetalhesDto> SelecionarPorId(int id);
    }
}