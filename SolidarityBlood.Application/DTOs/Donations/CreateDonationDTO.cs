using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.Donations
{
    public class CreateDonationDTO : BaseEntity
    {
        public int DonorId { get; set; }
        public DateTime DateDonation { get; set; }
        public int QuantityMl { get; set; }
    }
}
