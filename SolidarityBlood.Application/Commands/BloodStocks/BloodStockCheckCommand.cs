using MediatR;
using SolidarityBlood.Application.DTOs.BloodStocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.BloodStocks
{
    public class BloodStockCheckCommand : IRequest<Unit>
    {
        public int MinimumQuantityMl { get; } = 10000;
        public int CurrentTotalQuantityMl { get; set; }
        public string? BloodType { get; set; }
    }
}
