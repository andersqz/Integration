
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Integration.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IPedidoService _service;
        public PedidoController(IPedidoService service, ILogger<PedidoController> logger)
        {
            _service = service;
            _logger = logger;
        } 

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ParametrosPaginacaoDto parametros)
        {
            _logger.LogInformation("Buscando Pedidos");
            var pedidos = await _service.BuscarTodos(parametros.Pagina, parametros.TamanhoPagina);
            return Ok(pedidos);
        }

        [HttpGet("{empresa}/{local}/{serie}/{data}/{doc}")]
        public async Task<ActionResult<PedidoDetalhesDto>> BuscarPorInfo(
                        int empresa, int local, string serie, DateOnly data, int doc)
        {
            _logger.LogInformation("Buscando o Pedido ID {id}", doc);

            var pedido = await _service.BuscarPorInfo(empresa, local, serie, data, doc);

            if (pedido is null)
                return NotFound();

            return Ok(pedido);
        }
    }
}