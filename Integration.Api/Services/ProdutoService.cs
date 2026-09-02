using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Integration.Api.Models;
using Integration.Api.Utils;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Integration.Api.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoFiscalRepository _produtoFiscalRepository;

        public ProdutoService(IProdutoRepository produtoRepository, IProdutoFiscalRepository fiscalRepository)
        {
            _produtoRepository = produtoRepository;
            _produtoFiscalRepository = fiscalRepository;
        }

        public async Task<ProdutoDetalhesDto> BuscarPorId(int id)
        {
            Produto? p = await _produtoRepository.SelecionarPorId(id);
            ProdutoFiscal? f = await _produtoFiscalRepository.SelecionarPorId(id);

            if (p is null || f is null)
                throw new NotFoundException($"Produto ID {id} não encontrado.");

            ProdutoDetalhesDto dto = new()
            {
                IdEmpresa = p.EmpresaId,
                IdProduto = p.ProdutoId,
                CodigoEAN = p.CodigoEAN,
                TipoProduto = p.TipoProduto,
                Descricao = p.Descricao,
                DescricaoReduzida = p.DescricaoReduzida,
                CodigoGrupo = p.CodigoGrupo,
                CodigoSubgrupo = p.CodigoSubgrupo,
                CodigoMarca = p.CodigoMarca,
                CodigoPrincipalFornecedor = p.CodigoPrincipalFornecedor,
                UnidadeMedida = p.UnidadeMedida,
                QuantidadeUnidadeMedida = p.QuantidadeUnidadeMedida,
                PesoBruto = p.PesoBruto,
                PesoLiquido = p.PesoLiquido,
                ForaDeLinha = p.ForaDeLinha,
                ControlaEstoque = p.ControlaEstoque,
                DataAlteracao = Util.ConverterData(p.DataAlteracao),
                DataCadastro = Util.ConverterData(p.DataCadastro),
                DisponivelInternet = p.DisponivelInternet,

                IcmsSubstituicaoCompra = f.IcmsSubstituicaoCompra,
                IcmsSubstituicaoVenda = f.IcmsSubstituicaoVenda,
                PercentualIcmsSubstituicao = f.PercentualIcmsSubstituicao,
                ClassificacaoFiscalIcms = f.ClassificacaoFiscalIcms,
                Ncm = f.Ncm,
                Cst = f.Cst,
                CodigoClassificacaoCofins = f.CodigoClassificacaoCofins,
                CodigoClassificacaoPis = f.CodigoClassificacaoPis,
                OrigemMercadoria = f.OrigemMercadoria,
                Cest = f.Cest,
                PrecoPauta = f.PrecoPauta
            };

            return dto;
        }

        public async Task<List<ProdutoDto>> BuscarTodos()
        {
            IEnumerable<Produto> produtos = await _produtoRepository.SelecionarTodos();
            List<ProdutoDto> responses = new();

            foreach (Produto p in produtos)
            {
                ProdutoDto dto = new()
                {
                    IdProduto = p.ProdutoId,
                    CodigoEAN = p.CodigoEAN,
                    TipoProduto = p.TipoProduto,
                    Descricao = p.Descricao,
                    ForaDeLinha = p.ForaDeLinha,
                    DataAlteracao = Util.ConverterData(p.DataAlteracao)
                };

                responses.Add(dto);
            }
            return responses;
        }
    }
}