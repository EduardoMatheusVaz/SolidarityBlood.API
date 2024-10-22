using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.BloodStocks
{
    public class UpdateBloodStockDTO : BaseEntity
    {
        public string BloodType { get; set; }
        public string RHFactor { get; set; }
        public int QuantityMl { get; set; }
        public BloodStockStatusEnum Status { get; set; }
    }
}
