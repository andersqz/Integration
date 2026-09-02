using Integration.Api.Dtos;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Integration.Api.Models;

namespace Integration.Api.Services
{
    public class TransportadoraService : ITransportadoraService
    {
        private readonly ITransportadoraRepository _repository;
        public TransportadoraService(ITransportadoraRepository repository)
            => _repository = repository;

        public async Task<TransportadoraDto> BuscarPorId(int id)
        {
            Transportadora tr = await _repository.SelecionarPorId(id);
            
            if (tr is null)
                throw new NotFoundException("Transportadora não encontrada");
                
            return MapToResponse(tr);
        }

        public async Task<IEnumerable<TransportadoraDto>> BuscarTodos()
        {
            IEnumerable<Transportadora> tr = await _repository.SelecionarTodos();
            List<TransportadoraDto> responses = new();

            foreach (Transportadora t in tr)
            {
                responses.Add(MapToResponse(t));
            }

            return responses;
        }


        public TransportadoraDto MapToResponse(Transportadora tr)
        {
            return new TransportadoraDto()
            {
                EmpresaId = tr.EmpresaId,
                TransportadoraId = tr.TransportadoraId,
                Descricao = tr.Descricao,
                Endereco = tr.Endereco,
                CEP = tr.CEP,
                TipoPessoa = tr.TipoPessoa,
                CpfCnpj = tr.CpfCnpj,
                InscricaoEstadual = tr.InscricaoEstadual,
                Telefone = tr.Telefone,
                Email = tr.Email
            };
        }
    }
}