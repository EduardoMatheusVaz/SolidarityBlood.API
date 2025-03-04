using Moq;
using SolidarityBlood.Application.Commands.Addresses;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Commands.Addresses
{
    public class CreateAddressCommandHandlerTests
    {

        [Fact] // indica que o método a seguir se trata de um caso de teste unitário
        public async Task If_AnAddress_IsEntered_Then_TheCreationMethod_MustBeTriggered()
        {
            // Padrão AAA
            // Arrange: preparação do ambiente para os testes
            var command = new CreateAddressCommand()
            {
                ZipCode = "99070-220"
            };

            var addressRepository = new Mock<IAddressRepository>()
                .Setup(pr => pr.AddresQuery("99070-220"))
                .ReturnsAsync(new Address("Rua Senador Pinheiro", "112", "Vila Rodrigues", "Passo Fundo", "RS", "99070-220"));
                ;
            //addressRepository.Setup(pr => pr.CreateAddress(It.IsAny<Address>())).ReturnsAsync());
            var commandHandler = await new CreateAddressCommandHandler(addressRepository);

            // ACT: seria a ação em si, ou melhor, a fase em que nos encontramos
            var act = await commandHandler.Handle(command, new CancellationToken());

            // Assert: são as validações que desejamos fazer, morou?
            //addressRepository.Verify(pro => pro.CreateAddress(It.IsAny<Address>()), Times.Once());
            Assert.True(act > 0);

        }


    }
}
