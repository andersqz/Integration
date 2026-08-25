using Integration.Api.Dtos;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ClienteDto> clientes = await _service.BuscarTodos();
                return Ok(clientes);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ClienteDetalhesDto? cliente = await _service.BuscarPorId(id);
                return Ok(cliente);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }
    }
}