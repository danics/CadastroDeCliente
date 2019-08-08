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
using AutoMapper;

namespace CadastroDeClientes.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _contexto;
        private readonly IMapper _mapper;

        public ClientesController(ApplicationDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        //INDEX
        public async Task<IActionResult> Index()
        {
            var clientes = await _contexto.Clientes.ToListAsync();            
            var clientesViewModel = _mapper.Map<List<ClienteViewModel>>(clientes);           
            
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
                    var cliente = _mapper.Map<Cliente>(clienteViewModel);                    

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
            var cliente = await _contexto.Clientes.FindAsync(Id);

            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);

            if (cliente == null)
            {
                return NotFound();
            }            

            return View(clienteViewModel);
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
                    var cliente = _mapper.Map<Cliente>(ClienteViewModel);                    

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
            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);            

            return View(clienteViewModel);
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

            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);            

            return View(clienteViewModel);
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
