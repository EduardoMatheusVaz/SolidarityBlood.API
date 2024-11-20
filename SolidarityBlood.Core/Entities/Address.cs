using SolidarityBlood.Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Core.Entities
{
    public class Address : BaseEntity
    {
        public Address(string publicPlace, string? complement, string neighborhood, string city, string state, string zipCode)
        {
            PublicPlace = publicPlace;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;

            Status = AddressStatusEnum.Active;
        }

        public string PublicPlace { get; private set; }
        public string? Complement{ get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public AddressStatusEnum Status{ get; private set; }
        public string? ReasonExclusion { get; set; }



        //PROPRIEDADE DE NAVEGAÇÃO
        public ICollection<Donor>? Donors { get; private set; }

        public void Update(string publicPlace, string city, string state, string zipCode)
        {
            PublicPlace = publicPlace;
            City = city;
            State = state;
            ZipCode = zipCode;

        }


        // PASSING STATUS

        public void Inactive()
        {
            if (Status == AddressStatusEnum.Active)
            {
                Status = AddressStatusEnum.Inactive;
            }
        }

        public void Deleted(string reasonExclusion)
        {
            ReasonExclusion = reasonExclusion;

            if (Status == AddressStatusEnum.Active || Status == AddressStatusEnum.Inactive)
            {
                Status = AddressStatusEnum.Deleted;
            }
        }

    }
}
