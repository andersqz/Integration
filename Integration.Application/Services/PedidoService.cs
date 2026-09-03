
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

        public async Task<PedidoDetalhesDto> BuscarPorInfo(int local, string serie, DateOnly data, int doc)
        {
            int dataConvert = Util.ConverterDataParaInt(data);
            Pedido? p1 = await _repository.SelecionarPorInfo(local, serie, dataConvert, doc);
            IEnumerable<PedidoItem> p2 = await _itemRepository.SelecionarPorInfo(local, serie, dataConvert, doc);

            if (p1 is null)
                throw new NotFoundException("Pedido não localizado.");

            return MapToResponseDetalhes(p1, p2);
        }

        public async Task<IEnumerable<PedidoCabecalhoDto>> BuscarTodos()
        {
            IEnumerable<Pedido> pedidos = await _repository.SelecionarTodos();
            List<PedidoCabecalhoDto> responses = new();

            foreach (Pedido p in pedidos)
            {
                responses.Add(MapToResponseCabecalho(p));
            }

            return responses;
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
                Itens = p2.Select(MapToItem).ToList()
            };
        }

        public PedidoItemDto MapToItem(PedidoItem item)
        {
            return new PedidoItemDto() {
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