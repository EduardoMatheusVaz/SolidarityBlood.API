using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using SolidarityBlood.Application.Commands.BloodStocks;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Commands.BloodStocks
{
    public class CreateBloodStockCommandHandlerTests
    {
        [Fact] // Indica que o método a seguir se trata de um teste de unidade
        public async Task If_AStock_HasBeenCreated_ThenTheCreation_Method_Must_BeTriggered()
        {
            //Padrao AAA
            // Arrange: parte de configuração do ambiente

            var command = new CreateBloodStockCommand
            {
                BloodType = "O",
                RHFactor = "-",
                QuantityMl = 550
            };

            var bloodStockRepository = new Mock<IBloodStockRepository>();
            bloodStockRepository.Setup(pr => pr.CreateBloodStock(It.IsAny<BloodStock>()));
            var commandHandler = new CreateBloodStockCommandHandler(bloodStockRepository.Object);

            // Act
            var create = await commandHandler.Handle(command, new CancellationToken());

            //Assert
            bloodStockRepository.Verify(pr => pr.CreateBloodStock(It.IsAny<BloodStock>()), Times.Once());
        }



    }
}
