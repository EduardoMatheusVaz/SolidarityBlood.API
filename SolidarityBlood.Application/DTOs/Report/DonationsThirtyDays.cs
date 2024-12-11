using SolidarityBlood.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.Report
{
    [JsonSerializable]
    public class DonationsThirtyDays
    {
        // Of Donations
        public int Id { get; set; }
        public int DonorId { get; set; }
        public DateTime DateDonation { get; set; }
        public int QuantityMl { get; set; }
        public DonationStatusEnum Status { get; set; }
        public string? ReasonCanceled { get; set; }

        //
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public string BloodTypes { get; set; }
        public string RHFactor { get; set; }
    }
}
