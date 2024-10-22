using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.Addresses
{
    public class UpdateAddressDTO : BaseEntity
    {
        public string PublicPlace { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public AddressStatusEnum Status { get; set; }

    }
}
