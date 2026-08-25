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
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ProdutoDto> produtos = await _service.BuscarTodos();
                return Ok(produtos);
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
                ProdutoDetalhesDto produto = await _service.BuscarPorId(id);
                return Ok(produto);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }
    }
}