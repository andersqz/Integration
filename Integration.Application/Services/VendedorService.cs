using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using ntegration.Domain.Exceptions;

namespace Integration.Application.Services
{
    public class VendedorService : IVendedorService
    {
        private readonly IVendedorRepository _repository;
        public VendedorService(IVendedorRepository repository)
            => _repository = repository;

        public async Task<VendedorDetalhesDto> BuscarPorId(int id)
        {
            Vendedor? v = await _repository.SelecionarPorId(id);

            if (v is null)
                throw new NotFoundException($"Vendedor de id {id} não encontrado");
            
            return new VendedorDetalhesDto()
            {
                EmpresaId = v.EmpresaId,
                VendedorId = v.VendedorId,
                Nome = v.Nome,
                Tipo = v.Tipo,
                CalculaComissao = v.CalculaComissao,
                PercentualComissao = v.PercentualComissao,
                VendedorAtivo = v.VendedorAtivo,
                Endereco = v.Endereco,
                CEP = v.CEP,
                TipoPessoa = v.TipoPessoa,
                CpfCnpj = v.CpfCnpj,
                Telefone = v.Telefone,
                Email = v.Email,
                PercMaximoComissao = v.PercMaximoComissao,
                PercMaximoDesc = v.PercMaximoDesc
            };
        }

        public async Task<IEnumerable<VendedorDto>> BuscarTodos()
        {
            IEnumerable<Vendedor> vendedores = await _repository.SelecionarTodos();
            List<VendedorDto> responses = new();

            foreach (Vendedor v in vendedores)
            {
                responses.Add(new VendedorDto()
                {
                    VendedorId = v.VendedorId,
                    Nome = v.Nome,
                    Tipo = v.Tipo,
                    VendedorAtivo = v.VendedorAtivo,
                    CpfCnpj = v.CpfCnpj,
                    Telefone = v.Telefone
                });
            }

            return responses;
        }
    }
}