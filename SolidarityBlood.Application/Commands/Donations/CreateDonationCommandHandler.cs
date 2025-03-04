using MediatR;
using Microsoft.EntityFrameworkCore;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using SolidarityBlood.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donations
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, int>
    {
        private readonly IDonationRepository _donationRepository;

        public CreateDonationCommandHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<int> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            _donationRepository.TimeLimitForDonation(request.DonorId);

            var newDonation = new Donation(request.DonorId, request.DateDonation, request.QuantityMl);

            await _donationRepository.CreateDonation(newDonation);

            return newDonation.Id;
        }
    }
}
