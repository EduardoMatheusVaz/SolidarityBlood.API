using FluentValidation;
using SolidarityBlood.Application.Commands.BloodStocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Validators.BloodStocks
{
    public class CreateBloodStockValidator : AbstractValidator<CreateBloodStockCommand>
    {
        public CreateBloodStockValidator()
        {


            RuleFor(bt => bt.BloodType)
                .NotEmpty()
                .WithMessage("Tipo Sanguíneo não pode ser vazio nem nulo!")
                .Must(b => b == "A" || b == "B" || b == "AB" || b == "O")
                .WithMessage("O Tipo Sanguíneo deve ser: A, B, AB ou O!");

            RuleFor(rh => rh.RHFactor)
                .NotEmpty()
                .WithMessage("Fator RH não pode ser vazio nem nulo!")
                .Must(rf => rf == "+" || rf == "-")
                .WithMessage("Fator do RH deve ser: + ou - ");
                


        }


    }
}
