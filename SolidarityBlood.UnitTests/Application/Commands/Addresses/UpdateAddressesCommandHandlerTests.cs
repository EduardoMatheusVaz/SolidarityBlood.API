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
            //addressRepository.Verify(pr => pr.UpdateAddress(
            //    It.Is<int>(id => id == 1),
            //    It.Is<Address>(a =>
            //    a.Id == command.Id &&
            //    a.PublicPlace == command.PublicPlace &&
            //    a.Complement == command.Complement &&
            //    a.Neighborhood == command.Neighborhood &&
            //    a.City == command.City &&
            //    a.State == command.State &&
            //    a.ZipCode == command.ZipCode)
            //    ), Times.Once());

        }





    }
}
