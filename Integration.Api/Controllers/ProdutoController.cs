
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Integration.Domain.Exceptions;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoService _service;
        public ProdutoController(IProdutoService service, ILogger<ProdutoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ParametrosPaginacaoDto parametros)
        {
            _logger.LogInformation("Buscando Produtos - página {Pagina}, tamanho {Tamanho}",
                parametros.Pagina, parametros.TamanhoPagina);

            var resultado = await _service.BuscarTodos(parametros.Pagina, parametros.TamanhoPagina);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            _logger.LogInformation("Buscando o Produto ID {id}", id);

            ProdutoDetalhesDto produto = await _service.BuscarPorId(id);

            if (produto is null)
                return NotFound();

            return Ok(produto);
        }
    }
}