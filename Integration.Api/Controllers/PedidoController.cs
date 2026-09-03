
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
        private readonly IPedidoService _service;
        public PedidoController(IPedidoService service)
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<PedidoCabecalhoDto> pedidos = await _service.BuscarTodos();
            return Ok(pedidos);
        }

        [HttpGet("{empresa}/{local}/{serie}/{data}/{doc}")]
        public async Task<ActionResult<PedidoDetalhesDto>> BuscarPorInfo(
            int empresa,
            int local,
            string serie,
            DateOnly data,
            int doc)
        {

            try
            {
                var pedido = await _service.BuscarPorInfo(empresa, local, serie, data, doc);
                return Ok(pedido);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }
    }
}