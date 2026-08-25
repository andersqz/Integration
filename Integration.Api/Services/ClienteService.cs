using Integration.Api.Dtos;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Integration.Api.Models;

namespace Integration.Api.Services
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
                IdEmpresa = cliente.IdEmpresa,
                IdCliente = cliente.IdCliente,
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
                DataNascimento = ConverterData(cliente.DataNascimento),
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
                    IdCliente = c.IdCliente,
                    Nome = c.Nome,
                    CpfCnpj = c.CpfCnpj,
                    Telefone = c.Telefone,
                    Email = c.Email
                };

                responses.Add(dto);
            }
            return responses;
        }



        private static DateOnly ConverterData(int valor)
        {
            return DateOnly.FromDateTime(
                new DateTime(1800, 12, 28).AddDays(valor)
            );
        }
    }
}