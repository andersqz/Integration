
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Domain.Exceptions;

namespace Integration.Application.Services
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

        public async Task<PaginacaoDto<FornecedorDto>> BuscarTodos(int pagina, int tamanhoPagina)
        {
            IEnumerable<Fornecedor> fornecedores = await _repository.SelecionarTodos(pagina, tamanhoPagina);
            int total = await _repository.ContarTodos();

            return new PaginacaoDto<FornecedorDto>()
            {
              Itens = fornecedores.Select(MapToResponse),
              PaginaAtual = pagina,
              TamanhoPagina = tamanhoPagina,
              TotalRegistros = total  
            };
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