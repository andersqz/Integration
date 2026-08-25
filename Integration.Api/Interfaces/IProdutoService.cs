using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;

namespace Integration.Api.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoDto>> BuscarTodos();
        Task<ProdutoDetalhesDto> BuscarPorId(int id);
    }
}