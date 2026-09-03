
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
        private readonly IOperacaoFiscalService _service;
        public OperacaoFiscalController(IOperacaoFiscalService service) 
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<OperacaoFiscalDto> op = await _service.BuscarTodos();
            return Ok(op);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _service.BuscarPorId(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}