﻿using CadastroDeClientes.Models.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeClientes.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }        
        [Required(AllowEmptyStrings = false, ErrorMessage = "CPF é obrigatório.")]
        public string Cpf { get; set; }
        [DisplayName("DDD")]
        public string TelefoneDDD { get; set; }
        [DisplayName("Telefone")]
        public string TelefoneNumero { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Estado Estado { get; set; }
        [DisplayName("Numero")]
        public int? EnderecoNumero { get; set; }
        public string Cep { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime? DataDeNascimento { get; set; }
        public string Email { get; set; }
    }    
}
