using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donations
{
    public class DeleteDonationCommand : IRequest<Unit>
    {
        public DeleteDonationCommand(int id, string reasonCanceled)
        {
            Id = id;
            ReasonCanceled = reasonCanceled;
        }

        public int Id { get; set; }
        public string ReasonCanceled { get; set; }
    }
}
