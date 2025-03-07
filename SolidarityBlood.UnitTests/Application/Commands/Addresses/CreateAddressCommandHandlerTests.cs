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
            string zipcode = "99070-220";

            var command = new CreateAddressCommand()
            {
                ZipCode = zipcode
            };

            var addressRepository = new Mock<IAddressRepository>();
            
            addressRepository
                .Setup(pr => pr.AddresQuery(It.IsAny<string>()))
                .ReturnsAsync(new Address("Rua Senador Pinheiro", "112", "Vila Rodrigues", "Passo Fundo", "RS", "99070-220"));
            addressRepository.Setup(pr => pr.CreateAddress(It.IsAny<Address>()));

            var commandHandler = new CreateAddressCommandHandler(addressRepository.Object);

            // ACT: seria a ação em si, ou melhor, a fase em que nos encontramos
            var act = commandHandler.Handle(command, new CancellationToken());

            // Assert: são as validações que desejamos fazer, morou?
            addressRepository.Verify(pro => pro.CreateAddress(It.IsAny<Address>()), Times.Once());
            addressRepository.Verify(pro => pro.AddresQuery(It.IsAny<string>()), Times.Once());
        }


        [Fact] // indica que o método a seguir se trata de um caso de teste unitário
        public async Task If_theZipCode_IsWrong_ThenAnException_MustBeThrown()
        {
            // Padrão AAA
            // Arrange: preparação do ambiente para os testes
            string zipcode = "AAAAAAAAAAAAAAAAA";

            var command = new CreateAddressCommand()
            {
                ZipCode = zipcode
            };

            var addressRepository = new Mock<IAddressRepository>();

            addressRepository
                .Setup(pr => pr.AddresQuery(It.IsAny<string>())) // quando este método for chamado com qualquer string, ele deve lançar uma exceção
                .Throws(new Exception());   // isso vai simular o erro no repositório mais ou menos como se estivesse tendo erro ao buscar um endereço             
            addressRepository.Setup(pr => pr.CreateAddress(It.IsAny<Address>()));

            var commandHandler = new CreateAddressCommandHandler(addressRepository.Object);

            // ACT: seria a ação em si, ou melhor, a fase em que nos encontramos
            var act = commandHandler.Handle(command, new CancellationToken());

            // Assert: são as validações que desejamos fazer, morou?
            // O assert abaixo verifica se realmente o Handle lançou uma exceção, inclusive, o commandHandler.Handle está dentro da expressão abaixo
            // porque é essa chamada que deve gerar o erro esperado
            await Assert.ThrowsAsync<Exception>(() => commandHandler.Handle(command, new CancellationToken()));

        }
    }
}
