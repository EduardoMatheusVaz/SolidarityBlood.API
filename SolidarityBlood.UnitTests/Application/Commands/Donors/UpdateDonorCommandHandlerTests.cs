using Moq;
using SolidarityBlood.Application.Commands.Donors;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Commands.Donors
{
    public class UpdateDonorCommandHandlerTests : Donor
    {

        [Fact] // indica que a task a seguir se trata de um teste de unidade
        public async Task IfThere_IsDataToBe_UpdatedThenThe_MethodMustBeTriggered()
        {
            // ARRANGE: preparação do ambiente

            var command = new UpdateDonorCommand
                (
                "El Serpiente",
                "cobrakai@cobrakai.com",
                new DateTime(2002, 02, 02),
                "Masculino",
                80,
                "O",
                "+",
                2);

            command.Id = 1;

            var donor = new Donor(
                "El Serpiente",
                "cobrakai@cobrakai.com",
                new DateTime(2002, 02, 02),
                "Masculino",
                80,
                "O",
                "+",
                2);

            var donorRepository = new Mock<IDonorRepository>();
            donorRepository
                .Setup(pr => pr.Update(1, donor))
                .Returns(Task.CompletedTask);

            var commandHandler = new UpdateDonorCommandHandler(donorRepository.Object);
            

            // ACT
            var act = await commandHandler.Handle(command, new CancellationToken()); 


            // ASSERT
            donorRepository.Verify(a => a.Update(1, donor), Times.Once());


        }

    }
}
