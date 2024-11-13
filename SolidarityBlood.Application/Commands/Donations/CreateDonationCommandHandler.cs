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
        private readonly SolidarityBloodDbContext _dbcontext;

        public CreateDonationCommandHandler(IDonationRepository donationRepository, SolidarityBloodDbContext dbContext)
        {
            _donationRepository = donationRepository;
            _dbcontext = dbContext;
        }

        public async Task<int> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            // 1- buscar o donor no banco de dados
            // 2- buscar a ultima doação do doador
            // 3- chamar o método que criei dentro da entidade Donor, se pode ou nao fazer a doação
            // 4- caso o return seja false lançar uma exceção, o céu é o limite

            // 1- buscar o donor no banco de dados
            var donor = await _dbcontext.Donor.FirstOrDefaultAsync(d => d.Id == request.DonorId);

            // 2- buscar a ultima doação do doador
            var lastDonation = _dbcontext.Donation.Where(d => d.DonorId == donor.Id).
                OrderByDescending(d => d.DateDonation).
                Select(d => d.DateDonation).
                FirstOrDefault();

            // 3- chamar o método que criei dentro da entidade Donor, se pode ou nao fazer a doação, junto da chamada de outros métodos no processo
            donor.ValidateIntervalDays(lastDonation);
            donor.ValidateAge();
            donor.ValidateWeight();

            var newDonation = new Donation(request.DonorId, request.DateDonation, request.QuantityMl);

            await _donationRepository.CreateDonation(newDonation);

            return newDonation.Id;
        }
    }
}
