using Moq;
using SolidarityBlood.Application.Queries.Donor;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using SolidarityBlood.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Queries.Donors
{
    public class GetAllDonorsQueryHandlerTests
    {

        [Fact]
        public async Task IfThereAre_Donors_TheyMustBeReturned()
        {
            DateTime date = new DateTime(1995,02,03);

            // Arrange
            var donorsList = new List<Donor>
            {
                new Donor("Mordecai", "mordecai@regularshow.com", date, "Masculino", 72.5, "O", "+", 4),
                new Donor("Mordecai", "mordecai@regularshow.com", date, "Masculino", 72.5, "O", "+", 4),
                new Donor("Mordecai", "mordecai@regularshow.com", date, "Masculino", 72.5, "O", "+", 4),
                new Donor("Mordecai", "mordecai@regularshow.com", date, "Masculino", 72.5, "O", "+", 4)
            };

            var donorRepositoryMock = new Mock<IDonorRepository>(); // Esse aqui é o objeto Moq, ele nao é de fato o repository, DÁÁÁÁÁR
            donorRepositoryMock.Setup(pr => pr.GetAllDonors().Result).Returns(donorsList);


            var getAllQuery = new GetAllDonorsQuerie();
            var getAllHandler = new GetAllDonorsQuerieHandler(donorRepositoryMock.Object);


            // Act
            var result = await getAllHandler.Handle(getAllQuery, new CancellationToken());


            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result);
            Assert.Equal(donorsList.Count, result.Count);

            donorRepositoryMock.Verify(pr => pr.GetAllDonors().Result, Times.Once);
        }

    }
}
