
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
        private readonly ILogger<VendedorController> _logger;
        private readonly IVendedorService _service;
        public VendedorController(IVendedorService service, ILogger<VendedorController> logger)
        {
            _service = service;
            _logger = logger;
        } 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Busca todos os Vendedores.");
            IEnumerable<VendedorDto> vendedores = await _service.BuscarTodos();
            return Ok(vendedores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Busca o Vendedor ID {id}", id);

            VendedorDetalhesDto vendedor = await _service.BuscarPorId(id);

            if (vendedor is null)
                return NotFound();
                
            return Ok(vendedor);
        }
    }
}