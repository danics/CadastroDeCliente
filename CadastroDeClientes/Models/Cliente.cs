﻿using CadastroDeClientes.Models.Enums;
using CadastroDeClientes.Models.Value_Objects;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeClientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }            
        public Nome Nome { get; set; }        
        [Required]
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
        public string EnderecoNumero { get; set; }
        public string Cep { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime? DataDeNascimento { get; set; }
        public string Email { get; set; }

    }
}
