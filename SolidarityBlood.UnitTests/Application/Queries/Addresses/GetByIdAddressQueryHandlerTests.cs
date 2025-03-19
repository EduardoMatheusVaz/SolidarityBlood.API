using Moq;
using SolidarityBlood.Application.Queries.Address;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Queries.Addresses
{
    public class GetByIdAddressQueryHandlerTests
    {

        [Fact] // Indica que o método a seguir se trata de um teste unitário/de unidade
        public async Task If_ThereIs_AAddress_ThenShouldBeReturned()
        {

            // ARRANGE => etapa de preparação do nosso ambiente
            Address address = new Address("Rua Antonio dos Cocais", "101", "Vila Nova", "Machadinho", "RS", "88059-229");

            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(rep => rep.GetByIdAddress(It.IsAny<int>()).Result).Returns(address);

            var command = new GetByIdAddressQuerie(1);
            var commandHandler = new GetByIdAddressQuerieHandler(addressRepository.Object);


            // ACT => seria a ação em si
            var act = await commandHandler.Handle(command, new CancellationToken());


            // ASSERT
            addressRepository.Verify(rep => rep.GetByIdAddress(1), Times.Once());
        }


        [Fact] // Indica que o método a seguir se trata de um teste unitário/de unidade
        public async Task If_TheDataIsWrong_ThenItShould_ReturnFalse()
        {

            // ARRANGE => etapa de preparação do nosso ambiente
            Address address = new Address("Rua Antonio dos Cocais", "101", "Vila Nova", "Machadinho", "RS", "88059-229");

            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(rep => rep.GetByIdAddress(It.IsAny<int>()).Result).Returns(address);

            var command = new GetByIdAddressQuerie(1);
            var commandHandler = new GetByIdAddressQuerieHandler(addressRepository.Object);


            // ACT => seria a ação em si
            var act = await commandHandler.Handle(command, new CancellationToken());


            // ASSERT
            Assert.False(address.PublicPlace == "rua das ostras");
            Assert.False(address.City == "marmelada");
            Assert.False(address.State == "mussarela");
            Assert.False(address.ZipCode == "mortadela");
        }



        [Fact] // Indica que o método a seguir se trata de um teste unitário/de unidade
        public async Task If_TheDataIsCorrect_ThenItShould_ReturnTrue()
        {

            // ARRANGE => etapa de preparação do nosso ambiente
            Address address = new Address("Rua Antonio dos Cocais", "101", "Vila Nova", "Machadinho", "RS", "88059-229");

            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(rep => rep.GetByIdAddress(It.IsAny<int>()).Result).Returns(address);

            var command = new GetByIdAddressQuerie(1);
            var commandHandler = new GetByIdAddressQuerieHandler(addressRepository.Object);


            // ACT => seria a ação em si
            var act = await commandHandler.Handle(command, new CancellationToken());


            // ASSERT
            Assert.Equal(address.PublicPlace , act.PublicPlace);
            Assert.Equal(address.City , act.City);
            Assert.Equal(address.State , act.State);
            Assert.Equal(address.ZipCode , act.ZipCode);
        }

    }
}
