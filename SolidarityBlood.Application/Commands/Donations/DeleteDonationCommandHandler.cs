using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donations
{
    public class DeleteDonationCommandHandler : IRequestHandler<DeleteDonnationCommand, Unit>
    {
        public Task<Unit> Handle(DeleteDonnationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
