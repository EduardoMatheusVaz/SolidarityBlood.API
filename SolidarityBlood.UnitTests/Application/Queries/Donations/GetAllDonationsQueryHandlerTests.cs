using Moq;
using SolidarityBlood.Application.Queries.Donation;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Queries.Donations
{
    public class GetAllDonationsQueryHandlerTests
    {

        [Fact] // indica que o método é um caso de teste unitario
        public async Task IfThereAre_Donations_TheyMustBeReturned()
        {
            // PADRÃO AAA

            var date1 = new DateTime(2024, 1, 1);
            var date2 = new DateTime(2024, 2, 4);
            var date3 = new DateTime(2024, 10, 9);

            // Arrange, é a etapa de preparação dos testes, onde configuramos o ambiente e criamos os objetos necessários 
            var listDonations = new List<Donation>
            {
                new Donation(1, date1, 450),
                new Donation(1, date2, 455),
                new Donation(1, date3, 460),
                new Donation(1, date2, 470)
            };

            var donationRepositoryMock = new Mock<IDonationRepository>();
            donationRepositoryMock.Setup(pr => pr.GetAllDonations().Result).Returns(listDonations);

            var getAllQuery = new GetAllDonationsQuerie();
            var getAllHandler = new GetAllDonationsQuerieHandler(donationRepositoryMock.Object);


            // Act | é a minha ação em si
            var result = await getAllHandler.Handle(getAllQuery, new CancellationToken());

            // Assert
            Assert.NotEmpty(result);
            Assert.NotNull(result);
            Assert.Equal(listDonations.Count, result.Count);

            donationRepositoryMock.Verify(pr => pr.GetAllDonations().Result, Times.Once);
        }


    }
}
