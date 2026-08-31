using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Integration.Api.Models;

namespace Integration.Api.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repository;
        public FornecedorService(IFornecedorRepository repository)
            => _repository = repository;

        public async Task<FornecedorDto> BuscarPorId(int id)
        {
            Fornecedor? f = await _repository.SelecionarPorId(id);

            if (f is null)
                throw new NotFoundException("Fornecedor nao encontrado.");

            return MapToResponse(f);
        }

        public async Task<IEnumerable<FornecedorDto>> BuscarTodos()
        {
            IEnumerable<Fornecedor> fornecedores = await _repository.SelecionarTodos();
            List<FornecedorDto> responses = new();

            foreach (Fornecedor f in fornecedores)
            {
                responses.Add(MapToResponse(f));
            }

            return responses;
        }


        public FornecedorDto MapToResponse(Fornecedor f)
        {
            FornecedorDto response = new()
            {
                EmpresaId = f.EmpresaId,
                FornecedorId = f.FornecedorId,
                Nome = f.Nome,
                CpfCnpj = f.CpfCnpj,
                InscricaoEstadual = f.InscricaoEstadual,
                Telefone = f.Telefone,
                Email = f.Email
            };

            return response;
        }
    }



}