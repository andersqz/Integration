
using Integration.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Integration.Domain.Exceptions;
using Integration.Application.Dtos;
using System.Data.Odbc;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/seriefiscal")]
    public class SerieFiscalController : ControllerBase
    {
        private readonly ILogger<SerieFiscalController> _logger;
        private readonly ISerieFiscalService _service;  
        public SerieFiscalController(ISerieFiscalService service, ILogger<SerieFiscalController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Buscando todas as Séries Fiscais.");
            IEnumerable<SerieFiscalDto> serie = await _service.BuscarTodos();
            return Ok();
        }

        [HttpGet("{serie}")]
        public async Task<IActionResult> GetBySerie(string serie)
        {
            _logger.LogInformation("Buscando a Série Fiscal ID {id}", serie);

            SerieFiscalDto serieFiscal = await _service.BuscarPorSerie(serie);

            if (serieFiscal is null)    
                return NotFound();

            return Ok();
        }
    }
}