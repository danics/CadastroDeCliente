using CadastroDeClientes.Models.Value_Objects;
using CadastroDeClientes.Models.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeClientes.Validations
{
    public class ClienteViewModelValidations : AbstractValidator<ClienteViewModel>
    {
        public ClienteViewModelValidations()
        {
            RuleFor(x => x.PrimeiroNome).MinimumLength(2).WithMessage("Primeiro Nome deve ter pelo menos 2 caracteres");
            RuleFor(x => x.Sobrenome).MinimumLength(2);
            RuleFor(x => x.TelefoneDDD).MinimumLength(2);
            RuleFor(x => x.TelefoneNumero).MinimumLength(9);
            RuleFor(x => x.Endereco).MinimumLength(2);
            RuleFor(x => x.Cidade).MinimumLength(2);
            RuleFor(x => x.Bairro).MinimumLength(2);            
            RuleFor(x => x.Cep).MinimumLength(8);
            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Cpf).Custom((cpf, context) =>
            {
                Cpf validacpf = Cpf.Vazio;
                if(!validacpf.Valida(cpf))
                {
                    context.AddFailure("Número de CPF inválido.");
                }
            });

        }
    }
}
