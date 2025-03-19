using Moq;
using SolidarityBlood.Application.Queries.Donor;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SolidarityBlood.UnitTests.Application.Queries.Donors
{
    public class GetByIdDonorQueryHandlerTests
    {

        [Fact] // indica que o método ou Task a seguir se trata de um caso de teste unitário
        public async Task If_ThereIsA_DonorThenIt_MustBeReturned()
        {
            // ARRANGE => preparação do nosso ambiente de testes
            var date = new DateTime(2002, 10, 10);

            var donorGet = new Donor("Mordecai", "mordecai@regularshow.com", date, "Masculino", 72.5, "O", "+", 4);

            var donorRepository = new Mock<IDonorRepository>();
            donorRepository.Setup(rep => rep.GetByIdDonor(It.IsAny<int>()).Result).Returns(donorGet);

            var command = new GetByIdDonorQuerie(1);
            var commandHandler = new GetByIdDonorQuerieHandler(donorRepository.Object);

            // ACT => seria a ação em si né meu jovem
            var act = await commandHandler.Handle(command, new CancellationToken());

            // ASSERT
            donorRepository.Verify(rep => rep.GetByIdDonor(1), Times.Once());

        }


        [Fact]
         public async Task If_ThereIs_ADonorThen_HisDataShould_BeReturned()
        {
            // ARRANGE => preparação do nosso ambiente de testes
            var date = new DateTime(2002, 10, 10);

            var donorGet = new Donor("Mordecai", "mordecai@regularshow.com", date, "Masculino", 72.5, "O", "+", 4);

            var donorRepository = new Mock<IDonorRepository>();
            donorRepository.Setup(rep => rep.GetByIdDonor(It.IsAny<int>()).Result).Returns(donorGet);

            var command = new GetByIdDonorQuerie(1);
            var commandHandler = new GetByIdDonorQuerieHandler(donorRepository.Object);

            // ACT => seria a ação em si né meu jovem
            var act = await commandHandler.Handle(command, new CancellationToken());

            // ASSERT
            Assert.NotNull(act);
            Assert.Equal(act.FullName , donorGet.FullName);
            Assert.Equal(act.Email , donorGet.Email);
            Assert.Equal(act.DateBirth , donorGet.DateBirth);
            Assert.Equal(act.Gender , donorGet.Gender);
            Assert.Equal(act.Weight , donorGet.Weight);
            Assert.Equal(act.BloodTypes , donorGet.BloodTypes);
            Assert.Equal(act.RHFactor , donorGet.RHFactor);
            Assert.Equal(act.AddressId , donorGet.AddressId);
        }

    }
}
