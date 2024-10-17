using MediatR;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donations
{
    public class UpdateDonationCommandHandler : IRequestHandler<UpdateDonationCommand, Unit>
    {
        private readonly IDonationRepository _donationRepository;

        public UpdateDonationCommandHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<Unit> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = new Donation(request.DonorId, request.DateDonation, request.QuantityMl);

            await _donationRepository.Update(request.Id, donation);
        
            return Unit.Value;
        }
    }
}
