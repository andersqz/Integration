
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        public PedidoController(IPedidoService service)
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<PedidoCabecalhoDto> pedidos = await _service.BuscarTodos();
            return Ok(pedidos);
        }

        [HttpGet("{local}/{serie}/{data}/{doc}")]
        public async Task<ActionResult<PedidoDetalhesDto>> BuscarPorInfo(
            int local,
            string serie,
            DateOnly data,
            int doc)
        {
            var pedido = await _service.BuscarPorInfo(local, serie, data, doc);
            return Ok(pedido);
        }
    }
}