using MediatR;
using SolidarityBlood.Application.DTOs.BloodStocks;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Queries.BloodStock
{
    public class GetAllBloodStocksQuerieHandler : IRequestHandler<GetAllBloodStocksQuerie, List<GetAllBloodStockDTO>>
    {
        private readonly IBloodStockRepository _repository;

        public GetAllBloodStocksQuerieHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBloodStockDTO>> Handle(GetAllBloodStocksQuerie request, CancellationToken cancellationToken)
        {
            var get = await _repository.GetAllBloodStocks();

            var list = get.Select(l => new GetAllBloodStockDTO(
                l.Id,
                l.BloodType,
                l.RHFactor,
                l.QuantityMl,
                l.Status
                )).ToList();

            return list;
        }
    }
}
