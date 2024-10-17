﻿using MediatR;
using SolidarityBlood.Application.DTOs.Donations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Queries.Donation
{
    public class GetByIdDonationQuerie : IRequest<GetByIdDonationDTO>
    {
        public GetByIdDonationQuerie(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
