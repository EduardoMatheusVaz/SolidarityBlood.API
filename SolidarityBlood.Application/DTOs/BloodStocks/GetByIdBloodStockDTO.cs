using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.BloodStocks
{
    public class GetByIdBloodStockDTO : BaseEntity
    { 
        public GetByIdBloodStockDTO(int id, string bloodType, string rHFactor, int quantityMl)
        {
            Id = id;
            BloodType = bloodType;
            RHFactor = rHFactor;
            QuantityMl = quantityMl;
        }

        public int Id { get; set; }
        public string BloodType { get; set; }
        public string RHFactor { get; set; }
        public int QuantityMl { get; set; }
    }
}
