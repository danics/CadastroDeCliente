using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeClientes.Models.Value_Objects
{
    public class Email : ValueObject
    {
        public string EnderecoEmail { get; private set; }

        public Email(string enderecoEmail)
        {
            EnderecoEmail = enderecoEmail;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return EnderecoEmail;            
        }
    }
}
