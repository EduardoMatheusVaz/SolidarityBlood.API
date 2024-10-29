using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Addresses
{
    public class DeleteAddressCommand : IRequest<Unit>
    {
        public DeleteAddressCommand(int id, string reasonExclusion)
        {
            Id = id;
            ReasonExclusion = reasonExclusion;
        }

        public int Id { get; set; }
        public string ReasonExclusion { get; set; }
    }
}
