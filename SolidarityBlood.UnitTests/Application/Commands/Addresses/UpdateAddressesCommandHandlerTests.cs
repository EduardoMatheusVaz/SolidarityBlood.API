using Moq;
using SolidarityBlood.Application.Commands.Addresses;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Commands.Addresses
{
    public class UpdateAddressesCommandHandlerTests
    {


        [Fact] // indica que o método a seguir se trata de um caso de teste de unidade entende
        public async Task If_DataIsCorrect_ThenItShouldBe_Updated()
        {

            // ARRANGE => fase de preparação do ambiente
            var command = new UpdateAddressCommand
            {
                Id = 1,
                PublicPlace = "Rua Senador Pinheiro",
                Complement = "112",
                Neighborhood = "Vila Rodrigues",
                City = "Passo Fundo",
                State = "RS",
                ZipCode = "99070-220"
            };

            Address addressUpdate = null;

            var addressRepository = new Mock<IAddressRepository>();
            addressRepository
                .Setup(pr => pr.UpdateAddress(It.IsAny<int>(), It.IsAny<Address>()))
                .Callback<int, Address>((id, address) => addressUpdate = address)
                .Returns(Task.CompletedTask);

            var commandHandler = new UpdateAddressCommandHandler(addressRepository.Object);


            // ACT => é a ação em si, a faze em que estamos
            var act = await commandHandler.Handle(command, new CancellationToken());


            // ASSERTS => são as validações que queremos averiguar com os nossos testes né

            addressRepository.Verify(pr => pr.UpdateAddress(It.IsAny<int>(), It.IsAny<Address>()), Times.Once());
        }


        [Fact] // indica que o método a seguir se trata de um caso de teste unitário, ou em outras palavras de um teste de unidade
        public async Task If_DataIsWrong_ThenTheReturn_ShouldBeFalse()
        {
            // ARRANGE => etapa de preparação do ambiente

            Address addressUpdate = null;

            var command = new UpdateAddressCommand
            {
                Id = 1,
                PublicPlace = "Rua Senador Pinheiro",
                Complement = "112",
                Neighborhood = "Vila Rodrigues",
                City = "Passo Fundo",
                State = "RS",
                ZipCode = "99070-220"
            };

            var addressRepository = new Mock<IAddressRepository>();
            addressRepository
                .Setup(rep => rep.UpdateAddress(It.IsAny<int>(), It.IsAny<Address>()))
                .Callback<int, Address>((id, address) => addressUpdate = address)
                .Returns(Task.CompletedTask);

            var commandHandler = new UpdateAddressCommandHandler(addressRepository.Object);

            // ACT
            var act = await commandHandler.Handle(command, new CancellationToken());


            // ASSERT => etapa das validações em si
            Assert.False(addressUpdate.PublicPlace == "Gremio");
            Assert.False(addressUpdate.Complement == "Pepo");
            Assert.False(addressUpdate.Neighborhood == "Caie Paulista");
            Assert.False(addressUpdate.City == "Rochel");
            Assert.False(addressUpdate.State == "BALNEARIO CAMBORIU");
            Assert.False(addressUpdate.ZipCode == "99211-285");
        }




        [Fact] // indica que o método a seguir se trata de um caso de teste unitário, ou em outras palavras de um teste de unidade
        public async Task If_DataIsCorrect_SoThenTheReturn_ShouldBeTrue_OnThisShit()
        {
            // ARRANGE => etapa de preparação do ambiente

            Address addressUpdate = null;

            var command = new UpdateAddressCommand
            {
                Id = 1,
                PublicPlace = "Rua Senador Pinheiro",
                Complement = "112",
                Neighborhood = "Vila Rodrigues",
                City = "Passo Fundo",
                State = "RS",
                ZipCode = "99070-220"
            };

            var addressRepository = new Mock<IAddressRepository>();
            addressRepository
                .Setup(rep => rep.UpdateAddress(It.IsAny<int>(), It.IsAny<Address>()))
                .Callback<int, Address>((id, address) => addressUpdate = address)
                .Returns(Task.CompletedTask);

            var commandHandler = new UpdateAddressCommandHandler(addressRepository.Object);

            // ACT
            var act = await commandHandler.Handle(command, new CancellationToken());


            // ASSERT => etapa das validações em si
            Assert.True(addressUpdate.PublicPlace == "Rua Senador Pinheiro");
            Assert.True(addressUpdate.Complement == "112");
            Assert.True(addressUpdate.Neighborhood == "Vila Rodrigues");
            Assert.True(addressUpdate.City == "Passo Fundo");
            Assert.True(addressUpdate.State == "RS");
            Assert.True(addressUpdate.ZipCode == "99070-220");
        }

    }
}
