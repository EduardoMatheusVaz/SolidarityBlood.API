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
        }

        public string BloodType { get; private set; }
        public string RHFactor { get; private set; }
        public int QuantityMl { get; private set; }


        public void Update(string bloodType, string rHFactor, int quantityMl)
        {
            BloodType = bloodType;
            RHFactor = rHFactor;
            QuantityMl = quantityMl;
        }


    }
}
