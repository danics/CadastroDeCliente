using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroDeClientes.Models;
using CadastroDeClientes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
            return View(await _contexto.Clientes.ToListAsync());
        }

        //GET CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(cliente);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        //GET EDIT
        public async Task<IActionResult> Edit (int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var cliente = await _contexto.Clientes.FindAsync(Id);

            if(cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int Id, Cliente cliente)
        {
          
            if (ModelState.IsValid)
            {
                _contexto.Update(cliente);
                await _contexto.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

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
