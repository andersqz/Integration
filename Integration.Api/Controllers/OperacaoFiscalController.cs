
using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Integration.Domain.Exceptions;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/operacaofiscal")]
    public class OperacaoFiscalController : ControllerBase
    {   
        private readonly ILogger<OperacaoFiscalController> _logger;
        private readonly IOperacaoFiscalService _service;
        public OperacaoFiscalController(IOperacaoFiscalService service, ILogger<OperacaoFiscalController> logger)
        {
            _service = service;
            _logger = logger;
        } 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Buscando todas as operações fiscais.");
            IEnumerable<OperacaoFiscalDto> op = await _service.BuscarTodos();
            return Ok(op);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Buscando a Operaão Fiscal ID {id}", id);
            
            OperacaoFiscalDto? op = await _service.BuscarPorId(id);
            
            if (op is null)
                return NotFound();

            return Ok(op);
        }
    }
}