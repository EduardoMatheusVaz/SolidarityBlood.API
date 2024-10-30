using FluentValidation;
using SolidarityBlood.Application.Commands.Donations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Validators.Donations
{
    public class CreateDonationValidator : AbstractValidator<CreateDonationCommand>
    {
        public CreateDonationValidator()
        {

            RuleFor(q => q.QuantityMl)
                .NotEmpty()
                .WithMessage("Primeiramente, para você fazer uma doação de sangue você precisa DOAR SANGUE! Então peço que informe a quantidade de sangue que irá doar para prosseguirmos, por favor!")
                .InclusiveBetween(420, 470)
                .WithMessage("Para efetuar a doação, você deve doar NO MÍNIMO 420ml e NO MÁXIMO 470ml...");




        }

    }
}
