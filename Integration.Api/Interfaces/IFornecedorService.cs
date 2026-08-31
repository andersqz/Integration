using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;

namespace Integration.Api.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorDto>> BuscarTodos();
        Task<FornecedorDto> BuscarPorId(int id);
    }
}