
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