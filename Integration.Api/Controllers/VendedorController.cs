
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Integration.Domain.Exceptions;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/vendedor")]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorService _service;
        public VendedorController(IVendedorService service)
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<VendedorDto> vendedores = await _service.BuscarTodos();
                return Ok(vendedores);
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
                VendedorDetalhesDto vendedor = await _service.BuscarPorId(id);
                return Ok(vendedor);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}