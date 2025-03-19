using Moq;
using SolidarityBlood.Application.Commands.Donations;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Commands.Donations
{
    public class DeleteDonationCommandHandlerTests
    {

        [Fact]
        public async Task If_EverythingIsOkay_WithDonations_ThenTheMethod_ShouldBeCalled()
        {
            // ARRANGE
            var donationRepository = new Mock<IDonationRepository>();
            donationRepository.Setup(rep => rep.Delete(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            var command = new DeleteDonationCommand(1, "Porque sim cara");
            var commandHandler = new DeleteDonationCommandHandler(donationRepository.Object);

            // ACT
            var delete = await commandHandler.Handle(command, new CancellationToken());

            // ASSERT
            donationRepository.Verify(or => or.Delete(It.IsAny<int>(), It.IsAny<string>()), Times.Once());
        }


    }
}
