using MediatR;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.BloodStocks
{
    public class DeleteBloodStockCommandHandler : IRequestHandler<DeleteBloodStockCommand, Unit>
    {
        private readonly IBloodStockRepository _repository;

        public DeleteBloodStockCommandHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(DeleteBloodStockCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
