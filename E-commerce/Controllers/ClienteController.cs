using Dominio.Entidades;
using Dominio.Interfaces;
using E_commerce.Request;
using E_commerce.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        
        public ClienteController(IClienteRepositorio cliente)
        {
            _clienteRepositorio = cliente;
        }

        // GET obter todos
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ClienteResponse> cliente = new List<ClienteResponse>();
                var clientes = _clienteRepositorio.ObterTodos();

                foreach (var item in clientes)
                {
                    cliente.Add(new ClienteResponse()
                    {
                        NomeCliente = item.Nome,
                        TelefoneCliente = item.Telefone,
                        EmailCliente = item.Email,
                        CPFCNPJCliente = item.CPFCNPJ,
                        EnderecoCliente = item.Endereco,
                        DataDeNascimentoCliente = item.DataDeNascimento,
                        SexoCliente = item.Sexo,
                    }) ;
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteRequest cliente)
        {
            try
            {
                Cliente clien = new Cliente();

                clien.Nome = cliente.Nome;
                clien.Telefone = cliente.Telefone;
                clien.Email = cliente.Email;
                clien.CPFCNPJ = cliente.CPFCNPJ;
                clien.Endereco = cliente.Endereco;
                clien.DataDeNascimento = cliente.DataDeNascimento;
                clien.Sexo = cliente.Sexo;

                _clienteRepositorio.Adicionar(clien);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString()); 
            }
        }
        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteRequest cliente)
        {
            try
            {
                Cliente clien = new Cliente();
                var item = _clienteRepositorio.ObterPorId(id);

                if (item == null)
                {
                    throw new Exception("O ID é diferente do ID do Cliente");
                }

                clien.Nome = cliente.Nome;
                clien.Telefone = cliente.Telefone;
                clien.Email = cliente.Email;
                clien.CPFCNPJ = cliente.CPFCNPJ;
                clien.Endereco = cliente.Endereco;
                clien.DataDeNascimento = cliente.DataDeNascimento;
                clien.Sexo = cliente.Sexo;

                _clienteRepositorio.Atualizar(clien);
                return Ok(clien);

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
                var cliente = _clienteRepositorio.ObterPorId(id);

                if (cliente == null)
                    throw new Exception("ID não encontrado!");

                _clienteRepositorio.Remover(cliente);
                return Ok("Cliente excluido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}