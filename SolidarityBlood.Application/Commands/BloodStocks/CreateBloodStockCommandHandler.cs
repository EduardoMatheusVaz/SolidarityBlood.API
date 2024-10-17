using MediatR;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.BloodStocks
{
    public class CreateBloodStockCommandHandler : IRequestHandler<CreateBloodStockCommand, int>
    {
        private readonly IBloodStockRepository _repository;

        public CreateBloodStockCommandHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var stock = new BloodStock(request.BloodType, request.RHFactor, request.QuantityMl);

            await _repository.CreateBloodStock(stock);

            return stock.Id;
        }
    }
}
