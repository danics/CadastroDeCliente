using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeClientes.Models
{
    public interface IClienteRepositorio
    {
        Task<IEnumerable<Cliente>> GetAllListAsync();
        Cliente Add(Cliente cliente);
        Task<Cliente> FindById(int Id);
        Task<Cliente> Update(int Id);
        Task<Cliente> Remove(int Id);
    }
}
