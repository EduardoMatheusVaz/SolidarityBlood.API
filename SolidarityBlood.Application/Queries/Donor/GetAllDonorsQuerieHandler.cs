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
    internal class GetAllDonorsQuerieHandler : IRequestHandler<GetAllDonorsQuerie, List<GetAllDonorsDTO>>
    {
        private readonly IDonorRepository _donorRepository;

        public GetAllDonorsQuerieHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<List<GetAllDonorsDTO>> Handle(GetAllDonorsQuerie request, CancellationToken cancellationToken)
        {
            var getAll = await _donorRepository.GetAllDonors();

            var newList = getAll.Select(l => new GetAllDonorsDTO(
                l.Id,
                l.FullName,
                l.Email,
                l.DateBirth,
                l.Gender,
                l.Weight,
                l.BloodTypes,
                l.RHFactor,
                l.AddressId
                )).ToList();

            return newList;
        }
    }
}
