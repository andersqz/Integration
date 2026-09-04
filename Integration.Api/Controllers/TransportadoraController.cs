
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Integration.Domain.Exceptions;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/transportadora")]
    public class TransportadoraController : ControllerBase
    {
        private readonly ILogger<TransportadoraController> _logger;
        private readonly ITransportadoraService _service;
        public TransportadoraController(ITransportadoraService service, ILogger<TransportadoraController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Buscando todas as Transportadoras.");
            IEnumerable<TransportadoraDto> tr = await _service.BuscarTodos();
            return Ok(tr);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Buscando a Transportadora ID {id}", id);

            TransportadoraDto tr = await _service.BuscarPorId(id);

            if (tr is null)
                return NotFound();
                
            return Ok(tr);
        }
    }
}