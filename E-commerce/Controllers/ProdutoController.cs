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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositrio;

        public ProdutoController(IProdutoRepositorio produto, ICategoriaRepositorio categoria)
        {
            _produtoRepositorio = produto;
            _categoriaRepositrio = categoria;
        }


        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ProdutoResponse> produto = new List<ProdutoResponse>();
                var itens = _produtoRepositorio.ObterTodos();

                foreach (var item in itens)
                {
                    produto.Add(new ProdutoResponse()
                    {
                        NomeProduto = item.Nome,
                        UnidadeProduto = item.Unidade,
                        MarcaProduto = item.Marca,
                        CorProduto = item.Cor,
                        DescricaoProduto = item.Descricao,
                        TamanhoProduto = item.Tamanho,
                        QuantidadeProduto = item.Quantidade,
                        CategoriaId = item.CategoriaId,
                        PrecoProduto = item.Preco,
                        ModeloProduto = item.Categoria.Modelo,
                        GeneroProduto = item.Categoria.Genero
                    });
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                List<ProdutoResponse> produto = new List<ProdutoResponse>();
                var itemProduto = _produtoRepositorio.ObterPorId(id);

                if (itemProduto == null)
                    throw new Exception("Id Produto não existe");

                produto.Add(new ProdutoResponse()
                {
                    NomeProduto = itemProduto.Nome,
                    UnidadeProduto = itemProduto.Unidade,
                    MarcaProduto = itemProduto.Marca,
                    CorProduto = itemProduto.Cor,
                    DescricaoProduto = itemProduto.Descricao,
                    TamanhoProduto = itemProduto.Tamanho,
                    QuantidadeProduto = itemProduto.Quantidade,
                    CategoriaId = itemProduto.CategoriaId,
                    PrecoProduto = itemProduto.Preco,
                    ModeloProduto = itemProduto.Categoria.Modelo,
                    GeneroProduto = itemProduto.Categoria.Genero
                });

                return Ok(produto);
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
                prod.Categoria = _categoriaRepositrio.ObterPorId(produto.CategoriaId);
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
                _produtoRepositorio.Atualizar(produto);
                return Ok(produto);
                if (produto == null)
                    throw new Exception("Id Produto não existe");
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
                if (produto == null)
                    throw new Exception("Id Produto não existe");
                _produtoRepositorio.Remover(produto);
                return Ok(produto);
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