using SolidarityBlood.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Core.Entities
{
    public class Donation : BaseEntity
    {
        public Donation(int donorId, DateTime dateDonation, int quantityMl)
        {
            DonorId = donorId;
            DateDonation = dateDonation;
            QuantityMl = quantityMl;

            Status = DonationStatusEnum.Pending;
        }

        public DateTime DateDonation { get; private set; }
        public int QuantityMl { get; private set; }
        public DonationStatusEnum Status { get; private set; }
        public string? ReasonCanceled { get; set; }


        // FOREIGN KEYS
        public int DonorId { get; private set; }

        // PROPRIEDADE DE NAVEGAÇÃO
        public Donor? Donor { get; private set; }

        public void Update(int donorId, DateTime dateDonation, int quantityMl)
        {
            DonorId = donorId;
            DateDonation = dateDonation;
            QuantityMl = quantityMl;
        }


        // PASSING STATUS
        public void Completed()
        {
            if (Status == DonationStatusEnum.Pending)
            {
                Status = DonationStatusEnum.Complete;
            }
        }
    
        public void Canceled(string canceled)
        {
            ReasonCanceled = canceled;

            if (Status == DonationStatusEnum.Complete || Status == DonationStatusEnum.Pending)
            {
                Status = DonationStatusEnum.Canceled;
            }
        }




    }
}
