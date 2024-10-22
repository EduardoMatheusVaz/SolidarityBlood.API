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
    internal class GetAllDonationsQuerieHandler : IRequestHandler<GetAllDonationsQuerie, List<GetAllDonationDTO>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetAllDonationsQuerieHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<List<GetAllDonationDTO>> Handle(GetAllDonationsQuerie request, CancellationToken cancellationToken)
        {
            var get = await _donationRepository.GetAllDonations();

            var list = get.Select(l => new GetAllDonationDTO(
                l.Id,
                l.DonorId,
                l.DateDonation,
                l.QuantityMl,
                l.Status
                )).ToList();

            return list;
        }
    }
}
