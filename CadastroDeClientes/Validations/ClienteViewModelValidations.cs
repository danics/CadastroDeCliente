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
            RuleFor(x => x.PrimeiroNome).MinimumLength(2).WithMessage("Nome deve ter ao menos 2 caracteres.");
            RuleFor(x => x.Sobrenome).MinimumLength(2).WithMessage("Sobrenome deve ter ao menos 2 caracteres.");
            RuleFor(x => x.TelefoneDDD).MinimumLength(2).WithMessage("DDD deve ter ao menos 2 números.");
            RuleFor(x => x.TelefoneNumero).MinimumLength(8).WithMessage("Telefone deve ter ao menos 8 números.");
            RuleFor(x => x.Endereco).MinimumLength(2).WithMessage("Endereço deve ter ao menos 2 caracteres.");
            RuleFor(x => x.Cidade).MinimumLength(2).WithMessage("Cidade deve ter ao menos 2 caracteres.");
            RuleFor(x => x.Bairro).MinimumLength(2).WithMessage("Cidade deve ter ao menos 2 caracteres.");            
            RuleFor(x => x.Cep).MinimumLength(8).WithMessage("Cep deve ter ao menos 8 caracteres.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Endereço de email inválido.");

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
