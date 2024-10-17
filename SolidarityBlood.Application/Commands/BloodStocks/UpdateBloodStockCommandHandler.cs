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
    public class UpdateBloodStockCommandHandler : IRequestHandler<UpdateBloodStockCommand, Unit>
    {
        private readonly IBloodStockRepository _repository;

        public UpdateBloodStockCommandHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var stock = new BloodStock(request.BloodType, request.RHFactor, request.QuantityMl);

            await _repository.Update(request.Id, stock);

            return Unit.Value;
        }
    }
}
