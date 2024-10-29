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
        public DeleteBloodStockCommand(int id, string reasonUnavailable)
        {
            Id = id;
            ReasonUnavailable = reasonUnavailable;
        }

        public int Id { get; set; }
        public string ReasonUnavailable { get; set; }
    }
}
