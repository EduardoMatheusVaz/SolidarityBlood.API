using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.Donations
{
    public class GetByIdDonationDTO : BaseEntity
    {
        public GetByIdDonationDTO(int id, int donorId, DateTime dateDonation, int quantityMl, DonationStatusEnum status, string? reasonCanceled)
        {
            Id = id;
            DonorId = donorId;
            DateDonation = dateDonation;
            QuantityMl = quantityMl;
            Status = status;
            ReasonCanceled = reasonCanceled;
        }

        public int Id { get; set; }
        public int DonorId { get; set; }
        public DateTime DateDonation { get; set; }
        public int QuantityMl { get; set; }
        public DonationStatusEnum Status { get; set; }
        public string? ReasonCanceled{ get; set; }
    }
}
