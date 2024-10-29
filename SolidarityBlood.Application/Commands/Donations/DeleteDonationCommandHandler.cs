using MediatR;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donations
{
    public class DeleteDonationCommandHandler : IRequestHandler<DeleteDonationCommand, Unit>
    {
        private readonly IDonationRepository _donationRepository;

        public DeleteDonationCommandHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<Unit> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
        {
            await _donationRepository.Delete(request.Id, request.ReasonCanceled);

            return Unit.Value;
        }
    }
}
