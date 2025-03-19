using Moq;
using SolidarityBlood.Application.Commands.Addresses;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Commands.Addresses
{
    public class DeleteAddressCommandHandlerTests
    {

        [Fact]
        public async Task If_EverythingIsOkay_WithAddress_ThenTheMethod_ShouldBeCalled()
        {

            // ARRANGE
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(rep => rep.Delete(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            var command = new DeleteAddressCommand(1, "AAAAAAAA");
            var commandHandler = new DeleteAddressCommandHandler(addressRepository.Object);

            // ACT
            var delete = await commandHandler.Handle(command, new CancellationToken());

            // ASSERT
            addressRepository.Verify(rep => rep.Delete(It.IsAny<int>(), It.IsAny<string>()), Times.Once());
        }

    }
}
