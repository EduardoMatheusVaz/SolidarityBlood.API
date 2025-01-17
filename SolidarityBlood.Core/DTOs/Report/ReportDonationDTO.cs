using SolidarityBlood.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Core.DTOs.Report
{
    public class ReportDonationDTO
    {

        // Donation
        public int Id { get; set; }
        public DateTime DateDonation { get; set; }
        public int QuantityMl { get; set; }
        public DonationStatusEnum Status { get; set; }

        // Donor
        public int DonorId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string BloodTypes { get; set; }
        public string RHFactor { get; set; }

    }
}
