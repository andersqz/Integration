
using Integration.Application.Utils;
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Domain.Exceptions;

namespace Integration.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// busca um cliente pelo id atraves do repository e retorna ele com detalhes
        /// </summary>
        /// <param name="id"></param>
        /// <returns>um cliente especifico</returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<ClienteDetalhesDto> BuscarPorId(int id)
        {
            Cliente? cliente = await _repository.SelecionarPorId(id);

            if (cliente is null)
                throw new NotFoundException($"Cliente ID {id} não encontrado.");

            return MapToResponseDetalhes(cliente);
        }


        /// <summary>
        /// busca todos clientes do banco atraves do repository e retorna ele resumido
        /// </summary>
        /// <returns>lista de clientes</returns>
        public async Task<PaginacaoDto<ClienteDto>> BuscarTodos(int pagina, int tamanhoPagina)
        {
            IEnumerable<Cliente> clientes = await _repository.SelecionarTodos(pagina, tamanhoPagina);
            int total = await _repository.ContarTodos();

            return new PaginacaoDto<ClienteDto>()
            {
                Itens = clientes.Select(MapToResponse),
                PaginaAtual = pagina,
                TamanhoPagina = tamanhoPagina,
                TotalRegistros = total
            };
        }

        /// <summary>
        /// mapeia dados da entidade cliente para um dto de resposta com detalhes
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>dto de resposta com detalhes do cliente</returns>
        public ClienteDetalhesDto MapToResponseDetalhes(Cliente cliente)
        {
            return new ClienteDetalhesDto()
            {
                EmpresaId = cliente.EmpresaId,
                ClienteId = cliente.ClienteId,
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
        }

        /// <summary>
        /// mapeia a entidade cliente do banco para um dto de resposta resumido
        /// </summary>
        /// <param name="c">entidade cliente</param>
        /// <returns>dto resumido com info do cliente</returns>
        public ClienteDto MapToResponse(Cliente c)
        {
            return new ClienteDto()
            {
                ClienteId = c.ClienteId,
                Nome = c.Nome,
                CpfCnpj = c.CpfCnpj,
                Telefone = c.Telefone,
                Email = c.Email
            };
        }
    }
}