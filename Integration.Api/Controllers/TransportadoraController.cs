using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/transportadora")]
    public class TransportadoraController : ControllerBase
    {
        private readonly ITransportadoraService _service;
        public TransportadoraController(ITransportadoraService service)
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<TransportadoraDto> tr = await _service.BuscarTodos();
            return Ok(tr);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                TransportadoraDto tr = await _service.BuscarPorId(id);
                return Ok(tr);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}