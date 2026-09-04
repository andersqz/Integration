

using Integration.Application.Dtos;
using Integration.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Integration.Domain.Exceptions;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/empresa")]
    public class EmpresaController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IEmpresaService _service;
        public EmpresaController(IEmpresaService service, ILogger<ClienteController> logger)
        {
            _service = service;
            _logger = logger;
        }
            

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Buscando todas as empresas");
            IEnumerable<EmpresaDto> empresas = await _service.BuscarTodos();
            return Ok(empresas);
            
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {       
            _logger.LogInformation("Buscando a empresa ID {id}", id);
            
            EmpresaDto empresa = await _service.BuscarPorId(id);

            if (empresa is null)
                return NotFound();

            return Ok(empresa); 
        }
    }
}