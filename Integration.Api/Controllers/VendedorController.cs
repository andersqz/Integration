using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;
using Integration.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<VendedorDto> vendedores = await _service.BuscarTodos();
            return Ok(vendedores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            VendedorDetalhesDto vendedor = await _service.BuscarPorId(id);
            return Ok(vendedor);
        }
    }
}