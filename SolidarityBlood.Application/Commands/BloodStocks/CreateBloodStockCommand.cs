using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.BloodStocks
{
    public class CreateBloodStockCommand : IRequest<int>
    {
        public string BloodType { get; set; }
        public string RHFactor { get; set; }
        public int QuantityMl { get; set; }
    }
}
