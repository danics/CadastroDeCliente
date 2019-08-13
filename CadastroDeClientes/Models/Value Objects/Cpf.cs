using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeClientes.Models.Value_Objects
{
    public class Cpf : ValueObject
    {
            public static readonly Cpf Vazio = new Cpf();

            public string Numero { get; private set; }

            public Cpf(string numero)
            {
                if (!Valida(numero))
                {
                    throw new ArgumentException("Número de CPF inválido");
                }

                Numero = Normaliza(numero);
            }

            protected Cpf() { }

            public bool EstaVazio()
            {
                return string.IsNullOrEmpty(Numero) ? true : false;
            }

            public bool Valida(string numero)
            {
                if (string.IsNullOrEmpty(numero))
                    return false;

                string cpf = numero;

                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                cpf = Normaliza(cpf);
                if (cpf.Length != 11)
                    return false;

                for (int j = 0; j < 10; j++)
                    if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                        return false;

                string tempCpf = cpf.Substring(0, 9);
                int soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                int resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                string digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cpf.EndsWith(digito);
            }

            private string Normaliza(string cpf)
            {
                return cpf.Trim().Replace(".", "").Replace("-", "");
            }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
    }

