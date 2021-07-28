using Dominio.Entidades;
using Dominio.Interfaces;
using E_commerce.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public ProdutoController(IProdutoRepositorio produto)
        {
            _produtoRepositorio = produto;
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int id = 0)
        {
            try
            {
                if (id != 0)
                    return Ok(_produtoRepositorio.ObterPorId(id));

                return Ok(_produtoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoRequest produto)
        {
            try
            {
                Produto prod = new Produto();

                prod.Nome = produto.Nome;
                prod.Unidade = produto.Unidade;
                prod.Marca = produto.Marca;
                prod.Cor = produto.Cor;
                prod.Descricao = produto.Descricao;
                prod.Tamanho = produto.Tamanho;
                prod.Quantidade = produto.Quantidade;
                prod.Preco = produto.Preco;
                prod.CategoriaId = produto.CategoriaId;

                _produtoRepositorio.Adicionar(prod);
                return Ok(prod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Produto produto)
        {
            try
            {
                if (id != produto.Id)
                    return NotFound("Id diferente do id do cliente!");

                _produtoRepositorio.Atualizar(produto);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var produto = _produtoRepositorio.ObterPorId(id);

                if (id != produto.Id)
                    return NotFound("Id não encontrado!!");

                _produtoRepositorio.Remover(produto);
                return Ok("Excluído com sucesso!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("/Categoria/{id?}")]
        public async Task<IActionResult> GetCategoriasId(int id = 0)
        {
            try
            {
                if (id != 0)
                    return Ok(_produtoRepositorio.ObterTodos().Where(
                        p => p.CategoriaId == id
                    ));

                return Ok(_produtoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}