using Moq;
using SolidarityBlood.Application.Queries.Donation;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SolidarityBlood.UnitTests.Application.Queries.Donations
{
    public class GetByIdDonationQueryHandlerTests
    {

        [Fact]
        public async Task If_ThereIs_ADonationThenIt_MustBeReturned()
        {
            // ARRANGE
            var date = new DateTime(2025, 01, 01);
            var donation = new Donation(1, date, 450);

            var donationRepository = new Mock<IDonationRepository>();
            donationRepository.Setup(rep => rep.GetById(1).Result).Returns(donation);

            var command = new GetByIdDonationQuerie(1);
            var commandHandler = new GetByIdDonationQuerieHandler(donationRepository.Object);

            // ACT
            var result = await commandHandler.Handle(command, new CancellationToken());

            // ASSERT
            donationRepository.Verify(pr => pr.GetById(1).Result, Times.Once());
        }


        [Fact]
        public async Task If_ThereIs_ADonationThe_DataMustBeCorrect()
        {
            // ARRANGE
            var date = new DateTime(2025, 01, 01);
            var donation = new Donation(1, date, 450);

            var donationRepository = new Mock<IDonationRepository>();
            donationRepository.Setup(rep => rep.GetById(1).Result).Returns(donation);

            var command = new GetByIdDonationQuerie(1);
            var commandHandler = new GetByIdDonationQuerieHandler(donationRepository.Object);

            // ACT
            var result = await commandHandler.Handle(command, new CancellationToken());

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(result.DonorId, donation.DonorId);
            Assert.Equal(result.DateDonation, donation.DateDonation);
            Assert.Equal(result.QuantityMl, donation.QuantityMl);
        }


        [Fact]
        public async Task If_ThereIs_TheDataIsWrong_ThenShouldBeFalse()
        {
            // ARRANGE
            var date = new DateTime(2025, 01, 01);
            var donation = new Donation(1, date, 450);

            var donationRepository = new Mock<IDonationRepository>();
            donationRepository.Setup(rep => rep.GetById(1).Result).Returns(donation);

            var command = new GetByIdDonationQuerie(1);
            var commandHandler = new GetByIdDonationQuerieHandler(donationRepository.Object);

            // ACT
            var result = await commandHandler.Handle(command, new CancellationToken());

            // ASSERT
            Assert.False(result.DonorId == 100);
            Assert.False(result.DateDonation == new DateTime(2000, 10, 01));
            Assert.False(result.QuantityMl == 10000);
        }
    }
}
