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
    public class GetDeletedDonationsQuerieHandler : IRequestHandler<GetDeletedDonationsQuerie, List<GetAllDonationDTO>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetDeletedDonationsQuerieHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<List<GetAllDonationDTO>> Handle(GetDeletedDonationsQuerie request, CancellationToken cancellationToken)
        {
            var get = await _donationRepository.GetDeletedDonations();

            var list = get.Select(l => new GetAllDonationDTO(
                l.Id,
                l.DonorId,
                l.DateDonation,
                l.QuantityMl,
                l.Status,
                l.ReasonCanceled
                )).Where(l => l.Status == Core.Enums.DonationStatusEnum.Canceled).ToList();

            return list;
        }
    }
}
