using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donors
{
    internal class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand, Unit>
    {
        public Task<Unit> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
