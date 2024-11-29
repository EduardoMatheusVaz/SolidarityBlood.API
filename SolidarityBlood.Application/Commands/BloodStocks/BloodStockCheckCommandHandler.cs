using MediatR;
using Microsoft.EntityFrameworkCore;
using SolidarityBlood.Application.DTOs.BloodStocks;
using SolidarityBlood.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.BloodStocks
{
    public class BloodStockCheckCommandHandler : IRequestHandler<BloodStockCheckCommand, bool>
    {
        private readonly SolidarityBloodDbContext _dbContext;

        public BloodStockCheckCommandHandler(SolidarityBloodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(BloodStockCheckCommand request, CancellationToken cancellationToken)
        {
            var quantitysMl = await _dbContext.Donation.Select(qm => qm.QuantityMl).ToListAsync();
            var minimunQuantity = quantitysMl.Sum();

            return minimunQuantity >= request.MinimumQuantityMl;

        }
    }
}
