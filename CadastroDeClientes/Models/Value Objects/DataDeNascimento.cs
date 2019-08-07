using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeClientes.Models.Value_Objects
{
    public class DataDeNascimento : ValueObject
    {
        public DateTime? DataNascimento { get; private set; }

        public DataDeNascimento(DateTime? dataNascimento)
        {
            DataNascimento = dataNascimento;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return DataNascimento;
        }
    }
}
