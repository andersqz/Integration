using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Api.Dtos;
using Integration.Api.Exceptions;
using Integration.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integration.Api.Controllers
{
    [ApiController]
    [Route("api/local")]
    public class LocalController : ControllerBase
    {
        private readonly ILocalService _service;
        public LocalController(ILocalService service)
            => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<LocalDto> locais = await _service.BuscarTodos();
                return Ok(locais);
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
                LocalDto local = await _service.BuscarPorId(id);
                return Ok(local);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }
    }
}