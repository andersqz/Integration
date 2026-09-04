
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Integration.Domain.Exceptions;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/local")]
    public class LocalController : ControllerBase
    {
        private readonly ILogger<LocalController> _logger;
        private readonly ILocalService _service;
        public LocalController(ILocalService service, ILogger<LocalController> logger)
        {
             _service = service;
             _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {   
            _logger.LogInformation("Buscando todos os locais.");
            IEnumerable<LocalDto> locais = await _service.BuscarTodos();
            return Ok(locais);    
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Buscando o local ID {id}", id);

            LocalDto local = await _service.BuscarPorId(id);

            if (local is null)
                return NotFound();
                
            return Ok(local);
        }
    }
}