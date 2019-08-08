using AutoMapper;
using CadastroDeClientes.Models;
using CadastroDeClientes.Models.Value_Objects;
using CadastroDeClientes.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeClientes.Mapping
{
    public class ClientesProfile : Profile
    {
        public ClientesProfile()
        {
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.PrimeiroNome, opt => opt.MapFrom(x => x.Nome.PrimeiroNome))
                .ForMember(x => x.Sobrenome, opt => opt.MapFrom(x => x.Nome.Sobrenome))
                .ForMember(x => x.Cpf, opt => opt.MapFrom(x => x.Cpf.Numero))
                .ForMember(x => x.TelefoneDDD, opt => opt.MapFrom(x => x.Telefone.DDD))
                .ForMember(x => x.TelefoneNumero, opt => opt.MapFrom(x => x.Telefone.TelefoneNumero))
                .ForMember(x => x.Endereco, opt => opt.MapFrom(x => x.Endereco.Rua))
                .ForMember(x => x.Bairro, opt => opt.MapFrom(x => x.Endereco.Bairro))
                .ForMember(x => x.Cidade, opt => opt.MapFrom(x => x.Endereco.Cidade))
                .ForMember(x => x.Estado, opt => opt.MapFrom(x => x.Estado))
                .ForMember(x => x.EnderecoNumero, opt => opt.MapFrom(x => x.Endereco.Numero))
                .ForMember(x => x.Cep, opt => opt.MapFrom(x => x.Endereco.Cep))
                .ForMember(x => x.DataDeNascimento, opt => opt.MapFrom(x => x.DataDeNascimento.DataNascimento))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email.EnderecoEmail));

            CreateMap<ClienteViewModel, Cliente>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Nome, opt => opt.MapFrom(x => new Nome(x.PrimeiroNome, x.Sobrenome)))
                .ForMember(x => x.Cpf, opt => opt.MapFrom(x => new Cpf(x.Cpf)))
                .ForMember(x => x.Telefone, opt => opt.MapFrom(x => new Telefone(x.TelefoneDDD, x.TelefoneNumero)))
                .ForMember(x => x.Endereco, opt => opt.MapFrom(x => new Endereco(x.Endereco, x.Bairro, x.Cidade, x.EnderecoNumero, x.Cep)))
                .ForMember(x => x.Estado, opt => opt.MapFrom(x => x.Estado))
                .ForMember(x => x.DataDeNascimento, opt => opt.MapFrom(x => new DataDeNascimento(x.DataDeNascimento)))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => new Email(x.Email)));
        }
    }
}
