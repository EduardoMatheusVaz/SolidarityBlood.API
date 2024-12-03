using MediatR;
using SolidarityBlood.Application.DTOs.Donors;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Queries.Donor
{
    public class GetDeletedDonorQuerieHandler : IRequestHandler<GetDeletedDonorQuerie, List<GetAllDonorsDTO>>
    {
        private readonly IDonorRepository _donorRepository;

        public GetDeletedDonorQuerieHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<List<GetAllDonorsDTO>> Handle(GetDeletedDonorQuerie request, CancellationToken cancellationToken)
        {
            var get = await _donorRepository.GetDeletedDonor();

            var list = get.Select(l => (new GetAllDonorsDTO(
                l.Id,
                l.FullName,
                l.Email,
                l.DateBirth,
                l.Gender,
                l.Weight,
                l.BloodTypes,
                l.RHFactor,
                l.AddressId,
                l.Status,
                l.ReasonExclusion
                ))).Where(l => l.Status != Core.Enums.DonorStatusEnum.Active).ToList();

            return list;
        }
    
    }
}
