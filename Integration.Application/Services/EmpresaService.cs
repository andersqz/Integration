

using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using ntegration.Domain.Exceptions;

namespace Integration.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repository;
        public EmpresaService(IEmpresaRepository repository)
            => _repository = repository;

        public async Task<EmpresaDto> BuscarPorId(int id)
        {
            Empresa? e = await _repository.SelecionarPorId(id);

            if (e is null)
                throw new NotFoundException($"Empresa {id} não encontrada.");

            EmpresaDto dto = new EmpresaDto()
            {
                CodigoEmpresa = e.CodigoEmpresa,
                NomeEmpresa = e.NomeEmpresa,
                TipoEmpresa = e.TipoEmpresa,
                NomeFantasia = e.NomeFantasia
            };

            return dto;
        }

        public async Task<IEnumerable<EmpresaDto>> BuscarTodos()
        {
            IEnumerable<Empresa> empresas = await _repository.SelecionarTodos();
            List<EmpresaDto> responses = new();

            foreach (Empresa e in empresas)
            {
                responses.Add(new EmpresaDto()
                {
                    CodigoEmpresa = e.CodigoEmpresa,
                    NomeEmpresa = e.NomeEmpresa,
                    TipoEmpresa = e.TipoEmpresa,
                    NomeFantasia = e.NomeFantasia
                });
            }
            return responses;
        }
    }
}