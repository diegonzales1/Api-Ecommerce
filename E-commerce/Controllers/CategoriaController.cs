using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoria)
        {
            _categoriaRepositorio = categoria;
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int id = 0)
        {
            try
            {
                if (id != 0)
                {
                    return Ok(_categoriaRepositorio.ObterPorId((int)id));
                }
                else
                {
                    return Ok(_categoriaRepositorio.ObterTodos());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            try
            {
                _categoriaRepositorio.Adicionar(categoria);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            try
            {
                if (id != categoria.Id) return BadRequest("O id é diferente do id cliente");
                _categoriaRepositorio.Atualizar(categoria);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id = 0)
        {
            try
            {
                var categoria = _categoriaRepositorio.ObterPorId(id);
                _categoriaRepositorio.Remover(categoria);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}