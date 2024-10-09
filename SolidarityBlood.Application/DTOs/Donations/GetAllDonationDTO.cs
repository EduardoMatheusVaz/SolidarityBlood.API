using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.Donations
{
    public class GetAllDonationDTO : BaseEntity
    {
        public GetAllDonationDTO(int id, int donorId, DateTime dateDonation, int quantityMl)
        {
            Id = id;
            DonorId = donorId;
            DateDonation = dateDonation;
            QuantityMl = quantityMl;
        }

        public int Id { get; set; }
        public int DonorId { get; set; }
        public DateTime DateDonation { get; set; }
        public int QuantityMl { get; set; }
    }
}
