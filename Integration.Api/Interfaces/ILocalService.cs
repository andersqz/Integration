using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;

namespace Integration.Api.Interfaces
{
    public interface ILocalService
    {
        Task<IEnumerable<LocalDto>> BuscarTodos();
        Task<LocalDto> BuscarPorId(int id);
    }
}