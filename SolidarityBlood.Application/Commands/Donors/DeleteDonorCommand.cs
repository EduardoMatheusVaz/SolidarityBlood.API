using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donors
{
    public class DeleteDonorCommand : IRequest<Unit>
    {
        public DeleteDonorCommand(int id, string reasonExclusion)
        {
            Id = id;
            ReasonExclusion = reasonExclusion;
        }

        public int Id { get; set; }
        public string ReasonExclusion{ get; set; }
    }
}
