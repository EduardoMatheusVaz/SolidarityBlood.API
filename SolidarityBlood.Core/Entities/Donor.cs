using SolidarityBlood.Core.Enums;
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

            Status = DonorStatusEnum.Active;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime DateBirth { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodTypes { get; private set; }
        public string RHFactor { get; private set; }
        public DonorStatusEnum Status { get; private set; }
        public string? ReasonExclusion { get; set; }


        // FOREIGN KEYS
        public int AddressId { get; private set; }


        // NAVIGATION PROPERTIES
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


        // METHODS


        public bool ValidateWeight()
        {
            if (Weight >= 50)
            {
                return true;
            }
            else
            {
                throw new InvalidOperationException("Peso mínimo para efetuar a doação seria de 50 kg!");
            }
        }


        public bool ValidateAge()
        {
            var age = DateTime.Now.Year - DateBirth.Year;

            if(age >= 18)
            {
                return true;
            }
            else
            {
                throw new InvalidOperationException("Menores de idade não podem efetuar nenhuma doação, contudo nós permitimos o cadastro em nosso sistema até que tenhas idade apropriada para doar");
            }
        }

        public bool ValidateIntervalDays(DateTime date)
        {
            if (Gender.Equals("Masculino"))
            {
                TimeSpan intervalDays = DateTime.Now - date;

                if (intervalDays.Days >= 60)
                {
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("Doadores do gênero Masculino somente podem doar sangue de 60 em 60 dias");
                }

            }
            if (Gender.Equals("Feminino"))
            {
                TimeSpan intervalDays = DateTime.Now - date;

                if (intervalDays.Days >= 90)
                {
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("Doadoras do gênero Feminino somente podem doar sangue de 90 em 90 dias");
                }
            }

            return false;

        }


        // PASSING STATUS

        public void Inactive()
        {
            if (Status == DonorStatusEnum.Active)
            {
                Status = DonorStatusEnum.Inactive;
            }
        }

        public void Deleted(string reasonExclusion)
        {
            ReasonExclusion = reasonExclusion;

            if (Status == DonorStatusEnum.Active || Status == DonorStatusEnum.Inactive)
            {
                Status = DonorStatusEnum.Deleted;
            }
        }

        


    }   
}
