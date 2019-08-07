using CadastroDeClientes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeClientes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Clientes {get ; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().OwnsOne(c => c.Nome);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().OwnsOne(cpf => cpf.Cpf);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().OwnsOne(tel => tel.Telefone);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().OwnsOne(endereco => endereco.Endereco);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().OwnsOne(date => date.DataDeNascimento);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().OwnsOne(e => e.Email);
            base.OnModelCreating(modelBuilder);
        }
    }
}
