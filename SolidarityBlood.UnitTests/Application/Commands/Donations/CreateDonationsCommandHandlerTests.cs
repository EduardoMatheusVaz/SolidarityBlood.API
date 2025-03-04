using Moq;
using SolidarityBlood.Application.Commands.Donations;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Commands.Donations
{
    public class CreateDonationsCommandHandlerTests
    {

        [Fact] // Indica que o método a seguir se trata de um caso de teste de unidade
        public async Task If_ADonation_IsRegisteredThe_MethodMust_BeCalled()
        {
            // Padrao usado: AAA
            // Arrange
            var date = new DateTime(2025, 01, 01);

            var command = new CreateDonationCommand()
            {
                DonorId = 1,
                DateDonation = date,
                QuantityMl = 470
            };

            var donationRepository = new Mock<IDonationRepository>();
            donationRepository.Setup(pr => pr.CreateDonation(It.IsAny<Donation>()));
            var commandHandler = new CreateDonationCommandHandler(donationRepository.Object);

            // ACT: é a ação em si, tipo a execução da query, do command, etc
            var action = await commandHandler.Handle(command, new CancellationToken());

            // ASSERT
            donationRepository.Verify(pr => pr.CreateDonation(It.IsAny<Donation>()), Times.Once());

        }

    }
}
