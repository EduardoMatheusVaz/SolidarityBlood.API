using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.BloodStocks
{
    public class BloodStockCheckDTO
    {
        public int MinimumQuantityMl { get; } = 10000;
        public int CurrentTotalQuantityMl { get; set; }
        public string? BloodType { get; set; }
    }
}
