using Integration.Api.Dtos;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Integration.Api.Models;

namespace Integration.Api.Services
{
    public class LocalService : ILocalService
    {
        private readonly ILocalRepository _repository;
        public LocalService(ILocalRepository repository)
            => _repository = repository;

        public async Task<LocalDto> BuscarPorId(int id)
        {
            Local? l = await _repository.SelecionarPorId(id);

            if (l is null)
                throw new NotFoundException($"Local de id {id} não encontrado.");

            return new LocalDto()
            {
                EmpresaId = l.EmpresaId,
                LocalId = l.LocalId,
                Descricao = l.Descricao,
                CNPJ = l.CNPJ,
                InscricaoEstadual = l.InscricaoEstadual,
                Endereco = l.Endereco,
                Bairro = l.Bairro,
                CEP = l.CEP,
                UF = l.UF,
                Telefone = l.Telefone,
                Email = l.Email
            };
        }

        public async Task<IEnumerable<LocalDto>> BuscarTodos()
        {
            IEnumerable<Local> locais = await _repository.SelecionarTodos();
            List<LocalDto> responses = new();

            foreach (Local l in locais)
            {
                responses.Add(new LocalDto()
                {
                    EmpresaId = l.EmpresaId,
                    LocalId = l.LocalId,
                    Descricao = l.Descricao,
                    CNPJ = l.CNPJ,
                    InscricaoEstadual = l.InscricaoEstadual,
                    Endereco = l.Endereco,
                    Bairro = l.Bairro,
                    CEP = l.CEP,
                    UF = l.UF,
                    Telefone = l.Telefone,
                    Email = l.Email
                });
            }

            return responses;
        }
    }
}