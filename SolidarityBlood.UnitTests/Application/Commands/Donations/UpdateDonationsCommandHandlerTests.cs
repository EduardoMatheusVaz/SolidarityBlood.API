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
    public class UpdateDonationsCommandHandlerTests
    {

        [Fact]
        public async Task If_DataIsCorrect_ThenIt_ShouldPass()
        {

            // ARRANGE => preparação do nosso ambiente de testes
            var updateCommand = new UpdateDonationCommand
            {
                Id = 1,
                DonorId = 2,
                DateDonation = new DateTime(2010, 10, 01),
                QuantityMl = 460
            };

            Donation donation = null;

            var donationRepository = new Mock<IDonationRepository>();
            donationRepository
                .Setup(pr => pr.Update(It.IsAny<int>(), It.IsAny<Donation>()))
                .Callback<int, Donation>((id, don) => donation = don)
                .Returns(Task.CompletedTask);

            var commandHandler = new UpdateDonationCommandHandler(donationRepository.Object);
            
            // ACT => seria a ação em si

            var act = await commandHandler.Handle(updateCommand, new CancellationToken());


            // ASSERT ou ainda que eu tenho usado bastante, o Verify

            Assert.True(donation.QuantityMl == 460);
            Assert.True(donation.DateDonation == new DateTime(2010, 10, 01));
            Assert.True(donation.DonorId == 2);

            //donationRepository.Verify(pr => pr.Update(
            //    It.Is<int>(id => id == 1),
            //    It.Is<Donation>(d =>
            //    d.Id == 1 &&
            //    d.DonorId == 1 &&
            //    d.DateDonation == new DateTime(2010, 10, 01) &&
            //    d.QuantityMl == 460
            //    )), Times.Once());
        }




        [Fact]
        public async Task If_DataIsCorrect_ThenIt_Updated()
        {

            // ARRANGE => preparação do nosso ambiente de testes
            var updateCommand = new UpdateDonationCommand
            {
                Id = 1,
                DonorId = 2,
                DateDonation = new DateTime(2010, 10, 01),
                QuantityMl = 460
            };

            Donation donation = null;

            var donationRepository = new Mock<IDonationRepository>();
            donationRepository
                .Setup(pr => pr.Update(It.IsAny<int>(), It.IsAny<Donation>()))
                .Callback<int, Donation>((id, don) => donation = don)
                .Returns(Task.CompletedTask);

            var commandHandler = new UpdateDonationCommandHandler(donationRepository.Object);

            // ACT => seria a ação em si

            var act = await commandHandler.Handle(updateCommand, new CancellationToken());


            // ASSERT ou ainda que eu tenho usado bastante, o Verify

            donationRepository.Verify(pr => pr.Update(
                It.Is<int>(id => id == 1),
                It.Is<Donation>(d =>
                d.DonorId == donation.DonorId &&
                d.DateDonation == donation.DateDonation &&
                d.QuantityMl == donation.QuantityMl
                )), Times.Once());
        }



        [Fact]
        public async Task If_DataIsWrong_ThenIt_ShouldFail()
        {

            // ARRANGE => preparação do nosso ambiente de testes
            var updateCommand = new UpdateDonationCommand
            {
                Id = 1,
                DonorId = 2,
                DateDonation = new DateTime(2010, 10, 01),
                QuantityMl = 460
            };

            Donation donation = null;

            var donationRepository = new Mock<IDonationRepository>();
            donationRepository
                .Setup(pr => pr.Update(It.IsAny<int>(), It.IsAny<Donation>()))
                .Callback<int, Donation>((id, don) => donation = don)
                .Returns(Task.CompletedTask);

            var commandHandler = new UpdateDonationCommandHandler(donationRepository.Object);

            // ACT => seria a ação em si

            var act = await commandHandler.Handle(updateCommand, new CancellationToken());


            // ASSERT ou ainda que eu tenho usado bastante, o Verify

            Assert.False(donation.QuantityMl == 600);
            Assert.False(donation.DateDonation == new DateTime(2011, 03, 05));
            Assert.False(donation.DonorId == 5);

            
        }





    }
}
