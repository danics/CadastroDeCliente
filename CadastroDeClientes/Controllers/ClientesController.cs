﻿using System;
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
        //private readonly ApplicationDbContext _contexto;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;          
            _mapper = mapper;
        }

        //INDEX
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteRepositorio.GetAll();           
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

                    await _clienteRepositorio.Add(cliente);
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
            Cliente cliente = await _clienteRepositorio.FindById(Id);            

            if (cliente == null)
            {
                return NotFound();
            }

            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }
    
        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (ClienteViewModel ClienteViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cliente = _mapper.Map<Cliente>(ClienteViewModel);
                    await _clienteRepositorio.Update(cliente);                   
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Cpf", ex.Message);
            }

            return View(ClienteViewModel);
        }

        public async Task<IActionResult> Detail(int Id)
        {            
            var cliente = await _clienteRepositorio.FindById(Id);
            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);            

            return View(clienteViewModel);
        }

        //GET DELETE
        [HttpGet]
        public async Task<IActionResult> Delete (int Id, Cliente cliente)
        {
            cliente = await _clienteRepositorio.FindById(Id);

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
            await _clienteRepositorio.Remove(Id);            
            return RedirectToAction(nameof(Index));
        }
    }
}
