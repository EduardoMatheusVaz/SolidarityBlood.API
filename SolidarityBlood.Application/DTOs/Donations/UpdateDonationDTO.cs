using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.Donations
{
    public class UpdateDonationDTO : BaseEntity
    {
        public int DonorId { get; set; }
        public DateTime DateDonation { get; set; }
        public int QuantityMl { get; set; }
    }
}
