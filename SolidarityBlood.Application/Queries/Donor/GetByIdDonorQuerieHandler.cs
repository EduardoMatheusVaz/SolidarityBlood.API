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
    public class GetByIdDonorQuerieHandler : IRequestHandler<GetByIdDonorQuerie, GetByIdDonorDTO>
    {
        private readonly IDonorRepository _donorRepository;

        public GetByIdDonorQuerieHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<GetByIdDonorDTO> Handle(GetByIdDonorQuerie request, CancellationToken cancellationToken)
        {
            var getById = await _donorRepository.GetByIdDonor(request.Id);

            var donor = new GetByIdDonorDTO(getById.Id, getById.FullName, getById.Email, getById.DateBirth, getById.Gender, getById.Weight, getById.BloodTypes, getById.RHFactor, getById.AddressId, getById.Status);

            return donor;
        }
    }
}
