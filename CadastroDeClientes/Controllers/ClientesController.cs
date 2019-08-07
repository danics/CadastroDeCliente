using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroDeClientes.Models;
using CadastroDeClientes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CadastroDeClientes.Models.ViewModels;
using CadastroDeClientes.Models.Value_Objects;

namespace CadastroDeClientes.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public ClientesController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        //INDEX
        public async Task<IActionResult> Index()
        {
            var clientes = await _contexto.Clientes.ToListAsync();
            List<ClienteViewModel> clientesViewModel = new List<ClienteViewModel>();

            foreach (var cliente in clientes)
            {
                clientesViewModel.Add(new ClienteViewModel
                {
                    Id = cliente.Id,
                    PrimeiroNome = cliente.Nome.PrimeiroNome,
                    Sobrenome = cliente.Nome.Sobrenome,
                    Cpf = cliente.Cpf.Numero,
                    TelefoneDDD = cliente.Telefone.DDD,
                    TelefoneNumero = cliente.Telefone.TelefoneNumero,
                    Endereco = cliente.Endereco.Rua,
                    Bairro = cliente.Endereco.Bairro,
                    Cidade = cliente.Endereco.Cidade,
                    Estado = cliente.Estado,
                    EnderecoNumero = cliente.Endereco.Numero,
                    Cep = cliente.Endereco.Cep,
                    DataDeNascimento = cliente.DataDeNascimento,
                    Email = cliente.Email
                });
            }
            return View(clientesViewModel);
        }

        //GET CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cliente cliente = new Cliente
                    {
                        Nome = new Nome(clienteViewModel.PrimeiroNome, clienteViewModel.Sobrenome),
                        Cpf = new Cpf(clienteViewModel.Cpf),                        
                        Telefone = new Telefone(clienteViewModel.TelefoneDDD, clienteViewModel.TelefoneNumero),
                        Endereco = new Endereco(clienteViewModel.Endereco, clienteViewModel.Bairro, clienteViewModel.Cidade, clienteViewModel.EnderecoNumero, clienteViewModel.Cep),
                        //Bairro = clienteViewModel.Bairro,
                        //Cidade = clienteViewModel.Cidade,
                        Estado = clienteViewModel.Estado,
                        //EnderecoNumero = clienteViewModel.EnderecoNumero,
                        //Cep = clienteViewModel.Cep,
                        DataDeNascimento = clienteViewModel.DataDeNascimento,
                        Email = clienteViewModel.Email
                    };

                    _contexto.Add(cliente);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(ArgumentException ex)
            {
                ModelState.AddModelError("Cpf", ex.Message);                
            }            
            return View(clienteViewModel);
        }

        //GET EDIT
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var cliente = await _contexto.Clientes.FindAsync(Id);

            if (cliente == null)
            {
                return NotFound();
            }

            ClienteViewModel ClienteViewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                PrimeiroNome = cliente.Nome.PrimeiroNome,
                Sobrenome = cliente.Nome.Sobrenome,
                Cpf = cliente.Cpf.Numero,
                TelefoneDDD = cliente.Telefone.DDD,
                TelefoneNumero = cliente.Telefone.TelefoneNumero,
                Endereco = cliente.Endereco.Rua,
                Bairro = cliente.Endereco.Bairro,
                Cidade = cliente.Endereco.Cidade,
                Estado = cliente.Estado,
                EnderecoNumero = cliente.Endereco.Numero,
                Cep = cliente.Endereco.Cep,
                DataDeNascimento = cliente.DataDeNascimento,
                Email = cliente.Email
            };

            return View(ClienteViewModel);
        }
    
        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int Id, ClienteViewModel ClienteViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cliente cliente = new Cliente
                    {
                        Id = ClienteViewModel.Id,
                        Nome = new Nome(ClienteViewModel.PrimeiroNome, ClienteViewModel.Sobrenome),
                        Cpf = new Cpf(ClienteViewModel.Cpf),
                        Telefone = new Telefone(ClienteViewModel.TelefoneDDD, ClienteViewModel.TelefoneNumero),                        
                        Endereco = new Endereco(ClienteViewModel.Endereco, ClienteViewModel.Bairro, ClienteViewModel.Cidade, ClienteViewModel.EnderecoNumero, ClienteViewModel.Cep),
                        //Bairro = ClienteViewModel.Bairro,
                        //Cidade = ClienteViewModel.Cidade,
                        Estado = ClienteViewModel.Estado,
                        //EnderecoNumero = ClienteViewModel.EnderecoNumero,
                        //Cep = ClienteViewModel.Cep,
                        DataDeNascimento = ClienteViewModel.DataDeNascimento,
                        Email = ClienteViewModel.Email,
                    };

                    _contexto.Update(cliente);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Cpf", ex.Message);
            }

            return View(ClienteViewModel);
        }

        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var cliente = await _contexto.Clientes.FindAsync(Id);
            ClienteViewModel ClienteViewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                PrimeiroNome = cliente.Nome.PrimeiroNome,
                Sobrenome = cliente.Nome.Sobrenome,
                Cpf = cliente.Cpf.Numero,
                TelefoneDDD = cliente.Telefone.DDD,
                TelefoneNumero = cliente.Telefone.TelefoneNumero,
                Endereco = cliente.Endereco.Rua,
                Bairro = cliente.Endereco.Bairro,
                Cidade = cliente.Endereco.Cidade,
                Estado = cliente.Estado,
                EnderecoNumero = cliente.Endereco.Numero,
                Cep = cliente.Endereco.Cep,
                DataDeNascimento = cliente.DataDeNascimento,
                Email = cliente.Email
            };            

            return View(ClienteViewModel);
        }

        //GET DELETE
        public async Task<IActionResult> Delete(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }

            var cliente = await _contexto.Clientes.FindAsync(Id);

            if (cliente == null)
            {
                return NotFound();
            }

            ClienteViewModel ClienteViewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                PrimeiroNome = cliente.Nome.PrimeiroNome,
                Sobrenome = cliente.Nome.Sobrenome,
                Cpf = cliente.Cpf.Numero,
                TelefoneDDD = cliente.Telefone.DDD,
                TelefoneNumero = cliente.Telefone.TelefoneNumero,
                Endereco = cliente.Endereco.Rua,
                Bairro = cliente.Endereco.Bairro,
                Cidade = cliente.Endereco.Cidade,
                Estado = cliente.Estado,
                EnderecoNumero = cliente.Endereco.Numero,
                Cep = cliente.Endereco.Cep,
                DataDeNascimento = cliente.DataDeNascimento,
                Email = cliente.Email
            };

            return View(ClienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            var cliente = await _contexto.Clientes.FindAsync(Id);
            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
