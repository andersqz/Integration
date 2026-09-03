

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
        private readonly IEmpresaService _service;
        public EmpresaController(IEmpresaService service)
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<EmpresaDto> empresas = await _service.BuscarTodos();
                return Ok(empresas);
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
                EmpresaDto empresa = await _service.BuscarPorId(id);
                return Ok(empresa);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }
    }
}