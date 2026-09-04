

using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Integration.Application.Utils;
using Integration.Domain.Entities;
using Integration.Domain.Interfaces;
using Integration.Domain.Exceptions;

namespace Integration.Application.Services
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

        public async Task<ProdutoDetalhesDto> BuscarPorId(string id)
        {
            Produto? p = await _produtoRepository.SelecionarPorId(id);
            ProdutoFiscal? f = await _produtoFiscalRepository.SelecionarPorId(id);

            if (p is null && f is null)
                throw new NotFoundException($"Produto ID {id} não encontrado.");

            return MapToResponseDetalhes(p, f);
        }


        public async Task<List<ProdutoDto>> BuscarTodos()
        {
            IEnumerable<Produto> produtos = await _produtoRepository.SelecionarTodos();
            List<ProdutoDto> responses = new();

            foreach (Produto p in produtos)
            {
                responses.Add(MapToResponse(p));
            }
            return responses;
        }



        public ProdutoDto MapToResponse(Produto p)
        {
            return new ProdutoDto()
            {
                ProdutoId = p.ProdutoId,
                CodigoEAN = p.CodigoEAN,
                TipoProduto = p.TipoProduto,
                Descricao = p.Descricao,
                ForaDeLinha = p.ForaDeLinha,
                DataAlteracao = Util.ConverterData(p.DataAlteracao)
            };
        }
        
        public ProdutoDetalhesDto MapToResponseDetalhes(Produto p, ProdutoFiscal f)
        {
            return new ProdutoDetalhesDto()
            {
                EmpresaId = p.EmpresaId,
                ProdutoId = p.ProdutoId,
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
        }
    }
}