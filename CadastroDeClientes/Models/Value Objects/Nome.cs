using System.Collections.Generic;

namespace CadastroDeClientes.Models.Value_Objects
{
    public class Nome : ValueObject
    {
        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }

        public string NomeCompleto => PrimeiroNome + "" + Sobrenome;        

        public Nome(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return PrimeiroNome;
            yield return Sobrenome;
        }
    }
}
