using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _service;
        public ClienteController(IClienteService service, ILogger<ClienteController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ParametrosPaginacaoDto parametros)
        {
            _logger.LogInformation("Buscando Clientes - página {Pagina}, tamanho {Tamanho}", 
                parametros.Pagina, parametros.TamanhoPagina);

            var clientes = await _service.BuscarTodos(parametros.Pagina, parametros.TamanhoPagina);
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Buscando cliente com ID {id}", id);

            ClienteDetalhesDto? cliente = await _service.BuscarPorId(id);

            if (cliente is null) 
                return NotFound();

            return Ok(cliente);
        }
    }
}