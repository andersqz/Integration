
using Integration.Application.Utils;
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using ntegration.Domain.Exceptions;

namespace Integration.Application.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClienteDetalhesDto> BuscarPorId(int id)
        {
            Cliente? cliente = await _repository.SelecionarPorId(id);

            if (cliente is null)
                throw new NotFoundException($"Cliente ID {id} não encontrado.");

            ClienteDetalhesDto dto = new()
            {
                IdEmpresa = cliente.EmpresaId,
                IdCliente = cliente.ClienteId,
                Nome = cliente.Nome,
                NomeFantasia = cliente.NomeFantasia,
                Endereco = cliente.Endereco,
                Bairro = cliente.Bairro,
                CEP = cliente.CEP,
                TipoPessoa = cliente.TipoPessoa,
                CpfCnpj = cliente.CpfCnpj,
                InscricaoEstadual = cliente.InscricaoEstadual,
                Telefone = cliente.Telefone,
                Email = cliente.Email,
                DataNascimento = Util.ConverterData(cliente.DataNascimento),
                Sexo = cliente.Sexo,
                Cidade = cliente.Cidade
            };

            return dto;
        }

        public async Task<List<ClienteDto>> BuscarTodos()
        {
            IEnumerable<Cliente> clientes = await _repository.SelecionarTodos();
            List<ClienteDto> responses = new();

            foreach (Cliente c in clientes)
            {
                ClienteDto dto = new()
                {
                    IdCliente = c.ClienteId,
                    Nome = c.Nome,
                    CpfCnpj = c.CpfCnpj,
                    Telefone = c.Telefone,
                    Email = c.Email
                };

                responses.Add(dto);
            }
            return responses;
        }
    }
}