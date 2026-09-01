using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Integration.Api.Models;
using Integration.Api.Utils;

namespace Integration.Api.Services
{
    public class SerieFiscalService : ISerieFiscalService
    {
        private readonly ISerieFiscalRepository _repository;
        public SerieFiscalService(ISerieFiscalRepository repository)
            => _repository = repository;
        public async Task<SerieFiscalDto> BuscarPorSerie(string serie)
        {
            SerieFiscal? sf = await _repository.SelecionarPorSerie(serie);

            if (sf is null)
                throw new NotFoundException("Serie fiscal não encontrada.");

            return MapToResponse(sf);
        }

        public async Task<IEnumerable<SerieFiscalDto>> BuscarTodos()
        {
            IEnumerable<SerieFiscal> series = await _repository.SelecionarTodos();
            List<SerieFiscalDto> responses = new();

            foreach (SerieFiscal serie in series)
            {
                responses.Add(MapToResponse(serie));
            }

            return responses;
        }

        public SerieFiscalDto MapToResponse(SerieFiscal serie)
        {
            return new SerieFiscalDto()
            {
              EmpresaId = serie.EmpresaId,
              LocalId = serie.LocalId,
              Serie = serie.Serie,
              UltimoDocEmitido = Util.ConverterData(serie.UltimoDocEmitido)  
            };
        }
    }
}