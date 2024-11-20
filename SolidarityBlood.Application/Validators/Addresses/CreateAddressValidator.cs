using FluentValidation;
using SolidarityBlood.Application.Commands.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Validators.Addresses
{
    public class CreateAddressValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressValidator()
        {

            //RuleFor(pp => pp.PublicPlace)
            //    .NotEmpty()
            //    .WithMessage("A Rua do Endereço não pode ser vazia nem nula!")
            //    .MaximumLength(58)
            //    .WithMessage("Limite de 58 caracteres foi excedido! Sugiro que tente encurtar o nome da sua Rua!");

            //RuleFor(c => c.City)
            //    .NotEmpty()
            //    .WithMessage("Cidade não pode ser vazia nem nula!")
            //    .MaximumLength(58)
            //    .WithMessage("Limite de 58 caracteres foi excedido! O nome da cidade que você está tentando inserir é inválido!!!");

            //RuleFor(s => s.State)
            //    .NotEmpty()
            //    .WithMessage("O Estado não pode ser vazio nem nulo!")
            //    .Length(2,2)
            //    .WithMessage("Estado deve conter 2 caracteres (por exemplo, RJ, RS, SP)");

            RuleFor(zc => zc.ZipCode)
                .NotEmpty()
                .WithMessage("CEP não pode ser vazio nem nulo!")
                .Length(9, 9)
                .WithMessage("O CEP deve conter 9 caracteres (formato padrão XXXXX-XXX)");

        }

    }
}
