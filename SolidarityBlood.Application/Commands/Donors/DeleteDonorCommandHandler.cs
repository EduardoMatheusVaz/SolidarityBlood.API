using MediatR;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donors
{
    public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand, Unit>
    {
        private readonly IDonorRepository _donorRepository;

        public DeleteDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<Unit> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            await _donorRepository.Delete(request.Id, request.ReasonExclusion);

            return Unit.Value;
        }
    }
}
