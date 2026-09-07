
using Integration.Application.Utils;
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Domain.Exceptions;

namespace Integration.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly IPedidoItemRepository _itemRepository;
        public PedidoService(IPedidoRepository repository, IPedidoItemRepository itemRepository)
        {
            _repository = repository;
            _itemRepository = itemRepository;
        }

        public async Task<PedidoDetalhesDto> BuscarPorInfo(int empresa, int local, string serie, DateOnly data, int doc)
        {
            int dataConvert = Util.ConverterDataParaInt(data);

            Pedido? p1 = await _repository.SelecionarPorInfo(empresa, local, serie, dataConvert, doc);

            if (p1 is null)
                throw new NotFoundException("Pedido não localizado.");

            IEnumerable<PedidoItem> p2 = await _itemRepository.SelecionarPorInfo(empresa, local, serie, dataConvert, doc);

            return MapToResponseDetalhes(p1, p2);
        }

        public async Task<PaginacaoDto<PedidoDetalhesDto>> BuscarTodosComItens(int pagina, int tamanhoPagina, bool incluirItens)
        {

            IEnumerable<Pedido> pedidos = await _repository.SelecionarTodos(pagina, tamanhoPagina);
            int total = await _repository.ContarTodos();

            List<PedidoDetalhesDto> detalhes = new();
            IEnumerable<PedidoItem> itens;

            foreach (Pedido p in pedidos)
            {
                if (incluirItens)
                    itens = await _itemRepository.SelecionarPorInfo(p.EmpresaId, p.LocalId, p.Serie, p.DataEmissao, p.Documento);
                else
                    itens = Enumerable.Empty<PedidoItem>();

                detalhes.Add(MapToResponseDetalhes(p, itens));
            }

            return new PaginacaoDto<PedidoDetalhesDto>
            {
                Itens = detalhes,
                PaginaAtual = pagina,
                TamanhoPagina = tamanhoPagina,
                TotalRegistros = total
            };
        }

        public async Task<PaginacaoDto<PedidoCabecalhoDto>> BuscarTodosSemItens(int pagina, int tamanhoPagina)
        {
            IEnumerable<Pedido> pedidos = await _repository.SelecionarTodos(pagina, tamanhoPagina);
            int total = await _repository.ContarTodos();

            return new PaginacaoDto<PedidoCabecalhoDto>()
            {
                Itens = pedidos.Select(MapToResponseCabecalho),
                PaginaAtual = pagina,
                TamanhoPagina = tamanhoPagina,
                TotalRegistros = total
            };
        }


        public PedidoCabecalhoDto MapToResponseCabecalho(Pedido p)
        {
            return new PedidoCabecalhoDto()
            {
                EmpresaId = p.EmpresaId,
                LocalId = p.LocalId,
                Serie = p.Serie,
                DataEmissao = Util.ConverterData(p.DataEmissao),
                Documento = p.Documento,
                NomeCliente = p.NomeCliente,
                ClienteId = p.ClienteId,
                VendedorId = p.VendedorId,
                UltimaAlteracao = Util.ConverterData(p.UltimaAlteracao)
            };
        }



        public PedidoDetalhesDto MapToResponseDetalhes(Pedido p, IEnumerable<PedidoItem> p2)
        {
            List<PedidoItemDto> itensDto = new();

            foreach (PedidoItem item in p2)
            {
                itensDto.Add(MapToItem(item));
            }

            return new PedidoDetalhesDto()
            {
                EmpresaId = p.EmpresaId,
                LocalId = p.LocalId,
                Serie = p.Serie,
                DataEmissao = Util.ConverterData(p.DataEmissao),
                Documento = p.Documento,
                NomeCliente = p.NomeCliente,
                ClienteId = p.ClienteId,
                VendedorId = p.VendedorId,
                UltimaAlteracao = Util.ConverterData(p.UltimaAlteracao),
                OperacaoFiscal = p.OperacaoFiscal,
                EnderecoCliente = p.EnderecoCliente,
                CepCliente = p.CepCliente,
                CidadeCliente = p.CidadeCliente,
                UF = p.UF,
                CpfCnpj = p.CpfCnpj,
                InscricaoEstadual = p.InscricaoEstadual,
                TipoPessoa = p.TipoPessoa,
                Telefone = p.Telefone,
                TransportadoraId = p.TransportadoraId,
                Itens = itensDto
            };
        }

        public PedidoItemDto MapToItem(PedidoItem item)
        {
            return new PedidoItemDto()
            {
                ProdutoId = item.ProdutoId,
                NumeroSequencia = item.SequenciaItem,
                TipoProduto = item.TipoProduto,
                Quantidade = item.Quantidade,
                PrecoUnitario = item.PrecoUnitario,
                PercDesconto = item.PercDesconto,
                ValorDesconto = item.ValorDesconto,
                PercAcrescimo = item.PercAcrescimo,
                ValorAcrescimo = item.ValorAcrescimo
            };
        }
    }
}