using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.BloodStocks
{
    public class GetByIdBloodStockDTO : BaseEntity
    { 
        public GetByIdBloodStockDTO(int id, string bloodType, string rHFactor, int quantityMl, BloodStockStatusEnum status, string? reasonUnavailable)
        {
            Id = id;
            BloodType = bloodType;
            RHFactor = rHFactor;
            QuantityMl = quantityMl;
            Status = status;
            ReasonUnavailable = reasonUnavailable;
        }

        public int Id { get; set; }
        public string BloodType { get; set; }
        public string RHFactor { get; set; }
        public int QuantityMl { get; set; }
        public BloodStockStatusEnum Status { get; set; }
        public string? ReasonUnavailable{ get; set; }
    }
}
