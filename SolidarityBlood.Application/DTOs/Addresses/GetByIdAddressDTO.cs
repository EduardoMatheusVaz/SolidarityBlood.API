﻿using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.Addresses
{
    public class GetByIdAddressDTO : BaseEntity
    {
        public GetByIdAddressDTO(int id, string publicPlace, string city, string state, string zipCode, AddressStatusEnum status, string? reasonExclusion)
        {
            Id = id;
            PublicPlace = publicPlace;
            City = city;
            State = state;
            ZipCode = zipCode;
            Status = status;
            ReasonExclusion = reasonExclusion;
        }

        public int Id { get; set; }
        public string PublicPlace { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public AddressStatusEnum Status { get; set; }
        public string? ReasonExclusion{ get; set; }

    }
}
