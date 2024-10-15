using MediatR;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donors
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, int>
    {
        private readonly IDonorRepository _donorRepository;

        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<int> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var newDonor = new Donor(request.FullName, request.Email, request.DateBirth, request.Gender, request.Weight, request.BloodTypes, request.RHFactor, request.AddressId);

            await _donorRepository.CreateDonor(newDonor);

            return newDonor.Id;
        }
    }
}
