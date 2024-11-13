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
    public class GetDonorHistoryQuerieHandler : IRequestHandler<GetDonorHistoryQuerie, List<GetHistoryDonorDTO>>
    {
        private readonly IDonorRepository _repository;

        public GetDonorHistoryQuerieHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetHistoryDonorDTO>> Handle(GetDonorHistoryQuerie request, CancellationToken cancellationToken)
        {

            var get = await _repository.GetDonorHistory(request.Id);

            var list = get.Select(d => new GetHistoryDonorDTO(
                d.Id,
                d.DonorId,
                d.DateDonation,
                d.QuantityMl,
                d.Status,
                d.ReasonCanceled
                )).ToList();

            return list;
        }
    }
}
