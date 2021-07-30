using Dominio.Entidades;
using Dominio.Interfaces;
using E_commerce.Request;
using Microsoft.AspNetCore.Mvc;
using System;

using System.Collections.Generic;

using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoRepositorio _carrinhoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;

        public CarrinhoController(ICarrinhoRepositorio carrinho, IClienteRepositorio cliente)
        {
            _carrinhoRepositorio = carrinho;
            _clienteRepositorio = cliente;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(_carrinhoRepositorio.ObterTodos());
        }

        //[POST] carrinho -> cria o carrinho com 1 produto -> retorna Id do carrinho
        [HttpPost("/adicionarProduto")]
        public async Task<IActionResult> Post([FromBody] CarrinhoRequest carrinho)
        {
            try
            {
                Carrinho carrinh = new Carrinho();

                carrinh.ClienteId = carrinho.ClienteId;
                carrinh.Cliente = _clienteRepositorio.ObterPorId(carrinho.ClienteId);
                carrinh.Itens = carrinho.ItemCarrinho;
 
                _carrinhoRepositorio.Adicionar(carrinh);
                return Ok(carrinh);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        //[POST] carrinho/{id}/item -> enviar produto que esta sendo adcionado
        [HttpPost("{id}/item")]
        public async Task<IActionResult> AdicionarProduto(int id, [FromBody] ItemCarrinho item)
        {
            try
            {
                Carrinho carrinho = new Carrinho();

                if (carrinho.Id == id)
                    carrinho.Itens.Add(item);

                return BadRequest("NAO");
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