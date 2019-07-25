using System;

namespace CadastroDeClientes.Data
{
    public class Cliente
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string TelefoneDDD { get; set; }
        public string TelefoneNumero { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string EnderecoNumero { get; set; }
        public string Cep { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public string Email { get; set; }

    }
}
