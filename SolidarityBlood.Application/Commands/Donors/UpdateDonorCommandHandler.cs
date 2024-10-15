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
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, Unit>
    {
        private readonly IDonorRepository _donorRepository;

        public UpdateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<Unit> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = new Donor(request.FullName, request.Email, request.DateBirth, request.Gender, request.Weight, request.BloodTypes, request.RHFactor, request.AddressId);

            await _donorRepository.Update(request.Id, donor);

            return Unit.Value;   
        }
    }
}
