
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
        public async Task<IActionResult> Get([FromQuery] ParametrosPaginacaoDto parametros)
        {
            _logger.LogInformation("Buscando Fornecedores - página {Pagina}, tamanho {Tamanho}", 
                parametros.Pagina, parametros.TamanhoPagina);
                
            var fornecedores = await _service.BuscarTodos(parametros.Pagina, parametros.TamanhoPagina);
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