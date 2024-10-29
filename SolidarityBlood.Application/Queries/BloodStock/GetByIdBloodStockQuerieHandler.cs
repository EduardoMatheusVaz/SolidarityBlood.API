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
    public class GetByIdBloodStockQuerieHandler : IRequestHandler<GetByIdBloodStockQuerie, GetByIdBloodStockDTO>
    {
        private readonly IBloodStockRepository _repository;

        public GetByIdBloodStockQuerieHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdBloodStockDTO> Handle(GetByIdBloodStockQuerie request, CancellationToken cancellationToken)
        {
            var get = await _repository.GeByIdBloodStock(request.Id);

            var stock = new GetByIdBloodStockDTO(get.Id, get.BloodType, get.RHFactor, get.QuantityMl, get.Status, get.ReasonUnavailable);

            return stock;
        }
    }
}
