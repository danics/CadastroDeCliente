using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeClientes.Models.Value_Objects
{
    public class Endereco : ValueObject
    {
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public int Numero { get; private set; }
        public string Cep { get; private set; }

        public Endereco(string rua, string bairro, string cidade, int numero, string cep)
        {
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Numero = numero;
            Cep = cep;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Rua;
            yield return Bairro;
            yield return Cidade;
            yield return Numero;
            yield return Cep;           
        }
    }
}
