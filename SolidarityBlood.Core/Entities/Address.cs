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
        public Address(string publicPlace, string city, string state, string zipCode)
        {
            PublicPlace = publicPlace;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string PublicPlace { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }


        //PROPRIEDADE DE NAVEGAÇÃO
        public ICollection<Donor>? Donors { get; private set; }

        public void Update(string publicPlace, string city, string state, string zipCode)
        {
            PublicPlace = publicPlace;
            City = city;
            State = state;
            ZipCode = zipCode;
        }


    }
}
