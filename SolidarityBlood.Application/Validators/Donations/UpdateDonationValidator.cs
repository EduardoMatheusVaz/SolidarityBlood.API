using FluentValidation;
using SolidarityBlood.Application.Commands.Donations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Validators.Donations
{
    public class UpdateDonationValidator : AbstractValidator<UpdateDonationCommand>
    {
        public UpdateDonationValidator()
        {
                   
        }

    }
}
