using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Integration.Api.Models;
using Microsoft.Extensions.FileProviders;

namespace Integration.Api.Services
{
    public class OperacaoFiscalService : IOperacaoFiscalService
    {
        private readonly IOperacaoFiscalRepository _repository;
        public OperacaoFiscalService(IOperacaoFiscalRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperacaoFiscalDto?> BuscarPorId(int id)
        {
            OperacaoFiscal? op = await _repository.SelecionarPorId(id);

            if (op is null)
                throw new NotFoundException("Operação não encontrada.");

            return MapToResponse(op);
        }

        public async Task<IEnumerable<OperacaoFiscalDto>> BuscarTodos()
        {
            IEnumerable<OperacaoFiscal> op = await _repository.SelecionarTodos();
            List<OperacaoFiscalDto> responses = new();

            foreach (OperacaoFiscal top in op)
            {
                responses.Add(MapToResponse(top));
            }
            return responses;
        }

        public OperacaoFiscalDto MapToResponse(OperacaoFiscal op)
        {
            return new OperacaoFiscalDto(op.EmpresaId, op.OperacaoId, op.Descricao);
        }
    }
}