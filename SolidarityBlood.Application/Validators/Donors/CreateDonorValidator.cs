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

        }

    }
}
