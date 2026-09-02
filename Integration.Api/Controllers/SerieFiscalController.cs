using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/seriefiscal")]
    public class SerieFiscalController : ControllerBase
    {
        private readonly ISerieFiscalService _service;  
        public SerieFiscalController(ISerieFiscalService service)
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.BuscarTodos());
        }

        [HttpGet("{serie}")]
        public async Task<IActionResult> GetBySerie(string serie)
        {
            try
            {
                return Ok(await _service.BuscarPorSerie(serie));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}