using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Integration.Api.Models;
using Integration.Api.Utils;

namespace Integration.Api.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        public PedidoService(IPedidoRepository repository) 
            => _repository = repository;

        public async Task<PedidoDetalhesDto> BuscarPorInfo(int local, string serie, DateOnly data, int doc)
        {
            throw new NotImplementedException();
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
    }
}