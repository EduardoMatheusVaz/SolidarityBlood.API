using Microsoft.EntityFrameworkCore;
using Moq;
using SolidarityBlood.Application.Commands.Donors;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using SolidarityBlood.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Commands.Donors
{
    public class CreateDonorsCommandHandlerTests
    {

        [Fact]
        public async Task InputDataIsOk_Executed_ReturnedId()
        {
            // PAdrão AAA
            var dateBirth = new DateTime(2002, 10, 10);

            // Arrange: preparação do ambiente, configurar as coisas para conseguir testar

            var command = new CreateDonorCommand
            {
                FullName = "Gremio",
                Email = "pepo@gmail.com",
                DateBirth = dateBirth,
                Gender = "Masculino",
                Weight = 80,
                BloodTypes = "O",
                RHFactor = "-",
                AddressId = 1
            };

            var donorRepository = new Mock<IDonorRepository>();
            donorRepository.Setup(pr => pr.VerifyEmail(It.IsAny<string>())).ReturnsAsync(false);
            var commandHandler = new CreateDonorCommandHandler(donorRepository.Object);
 

            // ACT: é a ação em si, a faze em que nos 
            var id = await commandHandler.Handle(command, new CancellationToken());


            // Assert
            // Eu quero verificar que o createDonor para QUALQUER doador foi chamado pelo menos uma vez!!
            donorRepository.Verify(pr => pr.CreateDonor(It.IsAny<Donor>()), Times.Once);

        }



        [Fact] // indica que o método/task a seguir é um caso de teste unitario
        public async Task If_TheEmail_IsDuplicated_ThenTheMessage_ShouldBeDisprayed()
        {
            // PAdrão AAA
            var dateBirth = new DateTime(2002, 10, 10);

            // Arrange: preparação do ambiente, configurar as coisas para conseguir testar

            var command = new CreateDonorCommand
            {
                FullName = "Gremio",
                Email = "Pepo@gmail.com",
                DateBirth = dateBirth,
                Gender = "Masculino",
                Weight = 80,
                BloodTypes = "O",
                RHFactor = "-",
                AddressId = 1
            };

            var donorRepository = new Mock<IDonorRepository>();
            donorRepository.Setup(pr => pr.VerifyEmail(It.IsAny<string>())).ReturnsAsync(true);
            var commandHandler = new CreateDonorCommandHandler(donorRepository.Object);


            // ACT: é a ação em si, a faze em que nos estamos, esse esta junto com o Assert, mas SOMENTE neste caso específico
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => commandHandler.Handle(command, new CancellationToken()));

        }
    }
}