using MediatR;
using SolidarityBlood.Application.DTOs.Donations;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Queries.Donation
{
    public class GetByIdDonationQuerieHandler : IRequestHandler<GetByIdDonationQuerie, GetByIdDonationDTO>
    {
        private readonly IDonationRepository _donationRepository;

        public GetByIdDonationQuerieHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<GetByIdDonationDTO> Handle(GetByIdDonationQuerie request, CancellationToken cancellationToken)
        {
            var get = await _donationRepository.GetById(request.Id);

            var donation = new GetByIdDonationDTO(get.Id, get.DonorId, get.DateDonation, get.QuantityMl);

            return donation;
        }
    }
}
