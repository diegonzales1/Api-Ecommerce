using Dominio.Entidades;
using Dominio.Interfaces;
using E_commerce.Request;
using E_commerce.Response;
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
        private readonly IClienteRepositorio _clienteRepositorio;

        public CarrinhoController(ICarrinhoRepositorio carrinho, IClienteRepositorio cliente)
        {
            _carrinhoRepositorio = carrinho;
            _clienteRepositorio = cliente;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            List<CarrinhoResponse> carrinho = new List<CarrinhoResponse>();
            var itens = _carrinhoRepositorio.ObterTodos();

            foreach (var item in itens)
            {
                carrinho.Add(new CarrinhoResponse()
                {
                    NomeCliente = item.Cliente.Nome,
                    CPFCNPJCliente = item.Cliente.CPFCNPJ,
                    NomeProduto = item.Itens.Select(item => item.Produto.Nome).ToList(),
                    MarcaProduto = item.Itens.Select(item => item.Produto.Marca).ToList(),
                    CorProduto = item.Itens.Select(item => item.Produto.Cor).ToList(),
                    TamanhoProduto = item.Itens.Select(item => item.Produto.Tamanho).ToList(),
                    QuantidadeProduto = item.Itens.Select(item => item.Quantidade).ToList()
                });
            }
            
            return Ok(carrinho);
        }

        //[POST] carrinho -> cria o carrinho com 1 produto -> retorna Id do carrinho
        [HttpPost("/adicionarProduto")]
        public async Task<IActionResult> Post([FromBody] CarrinhoRequest item)
        {
            try
            {
                Carrinho carrinho = new Carrinho();
                List<ItemCarrinho> itemCarrinho = new List<ItemCarrinho>();

                carrinho.ClienteId = item.ClienteId;
                carrinho.Cliente = _clienteRepositorio.ObterPorId(item.ClienteId);

                foreach (var dado in item.ItemCarrinho)
                {
                    itemCarrinho.Add(new ItemCarrinho()
                    {
                        ProdutoId = dado.ProdutoId,
                        Quantidade = dado.Quantidade
                    });
                }

                carrinho.Itens = itemCarrinho;     
                _carrinhoRepositorio.Adicionar(carrinho);

                return Ok(carrinho.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<CarrinhoController>/5
        [HttpPut("/confirmar/{id}")]
        public async Task<IActionResult> Put(int id)
        {
            try
            {
                Carrinho carrinho = new Carrinho();

                if (_carrinhoRepositorio.ObterPorId(id) == null)
                    throw new Exception("Id de Carrinho não existe");

                return Ok("Compra Efetuada com Sucesso!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}