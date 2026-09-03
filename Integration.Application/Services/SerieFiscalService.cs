using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Integration.Application.Utils;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Domain.Exceptions;

namespace Integration.Application.Services
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