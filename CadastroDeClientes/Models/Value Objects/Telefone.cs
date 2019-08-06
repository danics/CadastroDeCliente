using System.Collections.Generic;

namespace CadastroDeClientes.Models.Value_Objects
{
    public class Telefone : ValueObject
    {
        public string DDD { get; private set;}
        public string TelefoneNumero { get; private set; }

        public string TelefoneCompleto => DDD + "" + TelefoneNumero;

        public Telefone()
        {
        }

        public Telefone(string ddd, string telefonenumero)
        {
            DDD = ddd;
            TelefoneNumero = telefonenumero;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return DDD;
            yield return TelefoneNumero;
        }
    }
}
