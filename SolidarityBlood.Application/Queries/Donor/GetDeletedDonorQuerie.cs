using MediatR;
using SolidarityBlood.Application.DTOs.Donors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Queries.Donor
{
    public class GetDeletedDonorQuerie : IRequest<List<GetAllDonorsDTO>>
    {

    }
}
