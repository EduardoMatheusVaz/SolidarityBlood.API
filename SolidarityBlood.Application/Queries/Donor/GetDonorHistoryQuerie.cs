using MediatR;
using SolidarityBlood.Application.DTOs.Donors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Queries.Donor
{
    public class GetDonorHistoryQuerie : IRequest<List<GetHistoryDonorDTO>>
    {
        public GetDonorHistoryQuerie(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
