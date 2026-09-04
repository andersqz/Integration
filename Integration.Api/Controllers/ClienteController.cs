
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Integration.Domain.Exceptions;

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
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Buscando todos os clientes");

            List<ClienteDto> clientes = await _service.BuscarTodos();
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