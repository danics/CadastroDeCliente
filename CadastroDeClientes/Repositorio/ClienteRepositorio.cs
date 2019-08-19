using AutoMapper;
using CadastroDeClientes.Data;
using CadastroDeClientes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeClientes.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ApplicationDbContext _contexto;        

        public ClienteRepositorio(ApplicationDbContext contexto)
        {
            _contexto = contexto;            
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _contexto.Clientes.ToListAsync();
        }

        public async Task<Cliente> Add(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            await _contexto.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> FindById(int Id)
        {
            var cliente = await _contexto.Clientes.FindAsync(Id);           
            return cliente;
        }

        public async Task<Cliente> Update(Cliente cliente)
        {            
            _contexto.Clientes.Update(cliente);
            await _contexto.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Remove(int Id)
        {
            var cliente = await FindById(Id);
            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();
            return cliente;
        }
    }
}
