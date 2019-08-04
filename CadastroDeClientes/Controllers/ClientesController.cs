using System;
using System.Collections.Generic;
using System.Linq;
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
                    PrimeiroNome = cliente.Nome.PrimeiroNome,
                    Sobrenome = cliente.Nome.Sobrenome,
                    Cpf = cliente.Cpf,
                    TelefoneDDD = cliente.TelefoneDDD,
                    TelefoneNumero = cliente.TelefoneNumero,
                    Endereco = cliente.Endereco,
                    Bairro = cliente.Bairro,
                    Cidade = cliente.Cidade,
                    Estado = cliente.Estado,
                    EnderecoNumero = cliente.EnderecoNumero,
                    Cep = cliente.Cep,
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
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente
                {                    
                    Nome = new Nome(clienteViewModel.PrimeiroNome, clienteViewModel.Sobrenome),
                    Cpf = clienteViewModel.Cpf,
                    TelefoneDDD = clienteViewModel.TelefoneDDD,
                    TelefoneNumero = clienteViewModel.TelefoneNumero,
                    Endereco = clienteViewModel.Endereco,
                    Bairro = clienteViewModel.Bairro,
                    Cidade = clienteViewModel.Cidade,
                    Estado = clienteViewModel.Estado,
                    EnderecoNumero = clienteViewModel.EnderecoNumero,
                    Cep = clienteViewModel.Cep,
                    DataDeNascimento = clienteViewModel.DataDeNascimento,
                    Email = clienteViewModel.Email
                };

                _contexto.Add(cliente);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
                Cpf = cliente.Cpf,
                TelefoneDDD = cliente.TelefoneDDD,
                TelefoneNumero = cliente.TelefoneNumero,
                Endereco = cliente.Endereco,
                Bairro = cliente.Bairro,
                Cidade = cliente.Cidade,
                Estado = cliente.Estado,
                EnderecoNumero = cliente.EnderecoNumero,
                Cep = cliente.Cep,
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
          
            if (ModelState.IsValid)
            {
                var cliente = await _contexto.Clientes.FindAsync(Id);               
                
                ClienteViewModel.Id = cliente.Id;
                ClienteViewModel.PrimeiroNome = cliente.Nome.PrimeiroNome;
                ClienteViewModel.Sobrenome = cliente.Nome.Sobrenome;
                ClienteViewModel.Cpf = cliente.Cpf;
                ClienteViewModel.Endereco = cliente.Endereco;
                ClienteViewModel.TelefoneDDD = cliente.TelefoneDDD;
                ClienteViewModel.TelefoneNumero = cliente.TelefoneNumero;
                ClienteViewModel.Bairro = cliente.Bairro;
                ClienteViewModel.Cidade = cliente.Cidade;
                ClienteViewModel.Estado = cliente.Estado;
                ClienteViewModel.EnderecoNumero = cliente.EnderecoNumero;
                ClienteViewModel.Cep = cliente.Cep;
                ClienteViewModel.DataDeNascimento = cliente.DataDeNascimento;
                ClienteViewModel.Email = cliente.Email;

                _contexto.Update(cliente);
                await _contexto.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(ClienteViewModel);
        }

        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var clientes = await _contexto.Clientes.FindAsync(Id);
            return View(clientes);
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

            return View(cliente);
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
