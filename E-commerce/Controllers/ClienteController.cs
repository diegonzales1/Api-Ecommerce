using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int id = 0)
        {
            try
            {
                if (id != 0)
                {
                    return Ok(_clienteRepositorio.ObterPorId((int)id));
                }
                else
                {
                    return Ok(_clienteRepositorio.ObterTodos());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                _clienteRepositorio.Adicionar(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                if (id != cliente.Id) return BadRequest("O id é diferente do id cliente");
                _clienteRepositorio.Atualizar(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cliente = _clienteRepositorio.ObterPorId(id);

                if (id != cliente.Id)
                    return NotFound("Id não encontrado!!");

                _clienteRepositorio.Remover(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}