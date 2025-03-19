using Moq;
using SolidarityBlood.Application.Commands.Donors;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Commands.Donors
{
    public class DeleteDonorCommandHandlerTests
    {

        [Fact] // Indica que o método ou task a seguir se trata de um caso de teste unitário
        public async Task If_EverythingIsOkay_ThenTheMethod_ShouldBeCalled()
        {

            // ARRANGE

            var donorRepository = new Mock<IDonorRepository>();
            donorRepository.Setup(rep => rep.Delete(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            var command = new DeleteDonorCommand(1, "Porque sim!!!!!!");
            var commandHandler = new DeleteDonorCommandHandler(donorRepository.Object);


            // ACT => é a ação em si que vamos executar
            var delete = await commandHandler.Handle(command, new CancellationToken());


            // ASSERT
            donorRepository.Verify(pre => pre.Delete(It.IsAny<int>(), It.IsAny<string>()), Times.Once());

        }

    }
}
