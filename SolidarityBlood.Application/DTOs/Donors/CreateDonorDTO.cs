using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.Donors
{
    public class CreateDonorDTO : BaseEntity
    {
        public CreateDonorDTO(string fullName, string email, DateTime dateBirth, string gender, double weight, string bloodTypes, string rHFactor)
        {
            FullName = fullName;
            Email = email;
            DateBirth = dateBirth;
            Gender = gender;
            Weight = weight;
            BloodTypes = bloodTypes;
            RHFactor = rHFactor;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender{ get; set; }
        public double Weight { get; set; }
        public string BloodTypes { get; set; }
        public string RHFactor { get; set; }
    }
}
