
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Integration.Domain.Exceptions;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/fornecedor")]
    public class FornecedorController : ControllerBase
    {
        private readonly ILogger<FornecedorController> _logger;
        private readonly IFornecedorService _service;
        public FornecedorController(IFornecedorService service, ILogger<FornecedorController> logger)
        {
             _service = service;
             _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Buscando todos os fornecedores");
            IEnumerable<FornecedorDto> fornecedores = await _service.BuscarTodos();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Buscando o fornecedor ID {id}", id);

            FornecedorDto fornecedor = await _service.BuscarPorId(id);
            
            if (fornecedor is null)
                return NotFound();

            return Ok(fornecedor);
        }
    }
}