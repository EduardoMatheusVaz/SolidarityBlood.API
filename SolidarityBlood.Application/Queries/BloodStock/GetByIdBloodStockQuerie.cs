using MediatR;
using SolidarityBlood.Application.DTOs.BloodStocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Queries.BloodStock
{
    public class GetByIdBloodStockQuerie : IRequest<GetByIdBloodStockDTO>
    {
        public GetByIdBloodStockQuerie(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
