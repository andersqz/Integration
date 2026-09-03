
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
        private readonly IFornecedorService _service;
        public FornecedorController(IFornecedorService service)
            => _service = service;


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<FornecedorDto> fornecedores = await _service.BuscarTodos();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                FornecedorDto fornecedor = await _service.BuscarPorId(id);
                return Ok(fornecedor);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}