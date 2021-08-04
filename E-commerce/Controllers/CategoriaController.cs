using Dominio.Entidades;
using Dominio.Interfaces;
using E_commerce.Request;
using E_commerce.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        // GET obter todos
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<CategoriaResponse> categoria = new List<CategoriaResponse>();
                var categorias = _categoriaRepositorio.ObterTodos();

                foreach (var item in categorias)
                {
                    categoria.Add(new CategoriaResponse()
                    {
                        ModeloCategoria = item.Modelo,
                        GeneroCategoria = item.Genero
                    }) ;
                }

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // GET por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {

                List<CategoriaResponse> categoria = new List<CategoriaResponse>();
                var itemCategoria = _categoriaRepositorio.ObterPorId(id);

                if (itemCategoria == null)
                    throw new Exception("Id Categoria não existe");

                categoria.Add(new CategoriaResponse()
                {
                    ModeloCategoria = itemCategoria.Modelo,
                    GeneroCategoria = itemCategoria.Genero
                });

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaRequest categoria)
        {
            try
            {
                Categoria categ = new Categoria();

                categ.Genero = categoria.Genero;
                categ.Modelo = categoria.Modelo;

                _categoriaRepositorio.Adicionar(categ);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoriaRequest categoria)
        {
            try
            {
                Categoria categ = new Categoria();
                var item = _categoriaRepositorio.ObterPorId(id);

                if (item == null) 
                    throw new Exception ("O id é diferente do id categoria");

                categ.Genero = categoria.Genero;
                categ.Modelo = categoria.Modelo;

                _categoriaRepositorio.Atualizar(categ);
                return Ok(categ);
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

                if (categoria == null)
                    throw new Exception("ID categoria não existe");

                _categoriaRepositorio.Remover(categoria);
                return Ok("Categoria excluída!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}