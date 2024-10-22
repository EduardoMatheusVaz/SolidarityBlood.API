using SolidarityBlood.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Core.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodStock(string bloodType, string rHFactor, int quantityMl)
        {
            BloodType = bloodType;
            RHFactor = rHFactor;
            QuantityMl = quantityMl;

            Status = BloodStockStatusEnum.Available;
        }

        public string BloodType { get; private set; }
        public string RHFactor { get; private set; }
        public int QuantityMl { get; private set; }
        public BloodStockStatusEnum Status{ get; private set; }


        public void Update(string bloodType, string rHFactor, int quantityMl, BloodStockStatusEnum status)
        {
            BloodType = bloodType;
            RHFactor = rHFactor;
            QuantityMl = quantityMl;
            Status = status;
        }

        // PASSING STATUS

        public void UnderReview()
        {
            if (Status == BloodStockStatusEnum.Available || Status == BloodStockStatusEnum.Unavailable)
            {
                Status = BloodStockStatusEnum.UnderReview;
            }
        }

        public void Unavailable()
        {
            if (Status == BloodStockStatusEnum.Available || Status == BloodStockStatusEnum.UnderReview)
            {
                Status = BloodStockStatusEnum.Unavailable;
            }
        }
    }
}
