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
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoRepositorio _carrinhoRepositorio;

        public CarrinhoController(ICarrinhoRepositorio carrinho)
        {
            _carrinhoRepositorio = carrinho;
        }

        // POST api/<CarrinhoController>
        [HttpPost ("/adicionarProduto")]
        public async Task<IActionResult> Post([FromBody] Carrinho carrinho)
        {
            try
            {
                _carrinhoRepositorio.Adicionar(carrinho);
                return Ok(carrinho);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());                
            }
        }

        // PUT api/<CarrinhoController>/5
        [HttpPut("/confirmar/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Carrinho carrinho)
        {
            try
            {
                Produto produto = new Produto();

                if (id != carrinho.Id)
                    throw new Exception("Id diferente do id do carrinho");

                if (carrinho.ProdutoId == produto.Id)
                    produto -= carrinho.Produto.

                var quant = carrinho.Produto.

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }        
    }
}
