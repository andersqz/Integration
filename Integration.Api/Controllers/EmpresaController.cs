
using Integration.Api.Dtos;
using Integration.Api.Interfaces;

using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<EmpresaDto> empresas = await _service.BuscarTodos();
            return Ok(empresas);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            EmpresaDto empresa = await _service.BuscarPorId(id);
            return Ok(empresa);
        }
    }
}