using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.BloodStocks
{
    public class DeleteBloodStockCommand : IRequest<Unit>
    {
        public DeleteBloodStockCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
