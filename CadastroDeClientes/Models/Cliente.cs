﻿using CadastroDeClientes.Models.Enums;
using CadastroDeClientes.Models.Value_Objects;

namespace CadastroDeClientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }            
        public Nome Nome { get; set; }                
        public Cpf Cpf { get; set; }       
        public Telefone Telefone { get; set; }
        public Endereco Endereco { get; set; }        
        public Estado Estado { get; set; }                               
        public DataDeNascimento DataDeNascimento { get; set; }
        public Email Email { get; set; }

    }
}
