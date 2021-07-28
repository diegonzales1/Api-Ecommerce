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
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoRepositorio _carrinhoRepositorio;

        public CarrinhoController(ICarrinhoRepositorio carrinho)
        {
            _carrinhoRepositorio = carrinho;
        }

        // POST api/<CarrinhoController>
        [HttpPost("/adicionarProduto")]
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

        //[POST] carrinho -> cria o carrinho com 1 produto -> retorna Id do carrinho
        //[POST] carrinho/{id}/item -> enviar produto que esta sendo adcionado
        //[POST] carrinho/{id}/confirmar


        //SE DER TEMPO:
        //[DELETE] carrinho/{id}/item/{idItem}
        //[PUT] carrinho/{id}/item/{idItem} -> atualizar qtd do produto

        // PUT api/<CarrinhoController>/5
        [HttpPut("/confirmar/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Carrinho carrinho)
        {
            try
            {
                Produto produto = new Produto();

                if (id != carrinho.Id)
                    throw new Exception("Id diferente do id do carrinho");



                return null;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}