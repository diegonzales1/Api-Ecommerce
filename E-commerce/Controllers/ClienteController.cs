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

        // GET por nome
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var cli = _clienteRepositorio.ObterTodos().Where(
                        c => c.Nome.ToLower().Equals(nome.ToLower())
                    );

                return Ok(cli);
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
               ClienteResponse cliente = new ClienteResponse();
               var item = _clienteRepositorio.ObterPorId(id);

                if (item == null)
                    throw new Exception("Id Cliente não existe");

                 cliente.NomeCliente = item.Nome;
                 cliente.TelefoneCliente = item.Telefone;
                 cliente.EmailCliente = item.Email;
                 cliente.CPFCNPJCliente = item.CPFCNPJ;
                 cliente.EnderecoCliente = item.Endereco;
                 cliente.DataDeNascimentoCliente = item.DataDeNascimento;
                 cliente.SexoCliente = item.Sexo;
    
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
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
                return Ok(clien.Id);
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
                var item = _clienteRepositorio.ObterPorId(id);

                if (item == null)
                    throw new Exception("O ID é diferente do ID do Cliente");

                Cliente clien = item;

                clien.Nome = cliente.Nome;
                clien.Telefone = cliente.Telefone;
                clien.Email = cliente.Email;
                clien.CPFCNPJ = cliente.CPFCNPJ;
                clien.Endereco = cliente.Endereco;
                clien.DataDeNascimento = cliente.DataDeNascimento;
                clien.Sexo = cliente.Sexo;

                _clienteRepositorio.Atualizar(clien);
                return Ok("Alteração feita com sucesso!!");

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