using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Core.Entities
{
    public class Donor : BaseEntity
    {
        public Donor(string fullName, string email, DateTime dateBirth, string gender, double weight, string bloodTypes, string rHFactor, int addressId)
        {
            FullName = fullName;
            Email = email;
            DateBirth = dateBirth;
            Gender = gender;
            Weight = weight;
            BloodTypes = bloodTypes;
            RHFactor = rHFactor;
            AddressId = addressId;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime DateBirth { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodTypes { get; private set; }
        public string RHFactor { get; private set; }

        // FOREIGN KEYS
        public int AddressId { get; private set; }

        //PROPRIEDADES DE NAVEGAÇÃO
        public List<Donation>? Donation { get; private set; }
        public Address? Address { get; private set; }


       public void Update(string fullName, string email, DateTime dateBirth, string gender, double weight, string bloodTypes, string rHFactor, int addressId)
        {
            FullName = fullName;
            Email = email;
            DateBirth = dateBirth;
            Gender = gender;
            Weight = weight;
            BloodTypes = bloodTypes;
            RHFactor = rHFactor;
            AddressId = addressId;
        }

    }   
}
