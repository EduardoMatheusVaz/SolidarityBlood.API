using FluentValidation;
using SolidarityBlood.Application.Commands.Donors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Validators.Donors
{
    public class CreateDonorValidator : AbstractValidator<CreateDonorCommand>
    {

        public CreateDonorValidator()
        {

            RuleFor(fn => fn.FullName)
                .NotEmpty()
                .WithMessage("Nome do Doador não pode ser vazio nem nulo!")
                .MaximumLength(80)
                .WithMessage("Nome do Doador deve conter NO MÁXIMO 80 caracteres")
                .MinimumLength(6)
                .WithMessage("Nome do Doador deve conter no mínimo 6 caracteres");

            RuleFor(e => e.Email)
                .NotEmpty()
                .WithMessage("Email não pode ser vazio nem nulo!")
                .EmailAddress()
                .WithMessage("Email digitado é inválido!")
                .MaximumLength(65)
                .WithMessage("Email informado excedeu o limite de 65 caracteres");

            RuleFor(db => db.DateBirth)
                .NotEmpty()
                .WithMessage("ÓBVIO que a data de aniversário não pode ser vazia e nem nula meu campeão, mas isso é ÓBVIO!");

            RuleFor(g => g.Gender)
                .NotEmpty()
                .WithMessage("Gênero não pode ser vazio nem nulo!")
                .Must(g => g == "Masculino" || g == "Feminino")
                .WithMessage("Gênero deve ser Masculino ou Feminino");

            RuleFor(w => w.Weight)
                .NotEmpty()
                .WithMessage("Peso não pode ser vazio e nem nulo!")
                .GreaterThanOrEqualTo(50.0)
                .WithMessage("Para você se cadastrar deve conter NO MÍNIMO 50kg, afinal esse é o péso MÍNIMO para se poder doar sangue...");

            RuleFor(bt => bt.BloodTypes)
                .NotEmpty()
                .WithMessage("Tipo sanguíneo não pode ser vazio nem nulo ")
                .Must(bt => bt == "A" || bt == "B" || bt == "AB" || bt == "O")
                .WithMessage("Tipo sanguíneo não pode ser diferente de: A, B, AB ou O!");

            RuleFor(fr => fr.RHFactor)
                .NotEmpty()
                .WithMessage("Fator RH não pode ser vazio nem nulo!")
                .Must(mm => mm == "+" || mm == "-")
                .WithMessage("Fator RH não pode ser diferente de + ou -, entendeu?");
            

                                

        }

    }
}
