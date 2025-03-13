using Moq;
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
    public class UpdateBloodStockCommandHandlerTests
    {

        [Fact] // indica que o método a seguir  se trata de um caso de teste de unidade
        public async Task If_TheBloodStock_IsCorrectThen_ItShouldBeUpdated()
        {

            // ARRANGE => fase de preparação do ambiente
            var updateStock = new UpdateBloodStockCommand
            {
                Id = 1,
                BloodType = "AB",
                RHFactor = "+",
                QuantityMl = 444
            };

            BloodStock bloodStock = null;

            var bloodStockRepository = new Mock<IBloodStockRepository>();
            bloodStockRepository
                .Setup(pr => pr.Update(It.IsAny<int>(), It.IsAny<BloodStock>()))
                .Callback<int, BloodStock>((id, stock) => bloodStock = stock)
                .Returns(Task.CompletedTask);

            var commandHandler = new UpdateBloodStockCommandHandler(bloodStockRepository.Object);


            // ACT

            var act = await commandHandler.Handle(updateStock, new CancellationToken());



            // ASSERT

            bloodStockRepository.Verify(rep => rep.Update(
                It.Is<int>(id => id == 1),
                It.Is<BloodStock>(bl =>
                bl.BloodType == bloodStock.BloodType &&
                bl.RHFactor == bloodStock.RHFactor &&
                bl.QuantityMl == bloodStock.QuantityMl
                )), Times.Once());


        }



        [Fact] // indica que o método ou task a seguir se trata de um caso de teste unitário, entendeu
        public async Task If_DataIsWrong_ShouldBeReturned()
        {

            // ARRANGE => etapa de preparação do ambiente para os testes
            var updateCommand = new UpdateBloodStockCommand
            {
                Id = 1,
                BloodType = "AB",
                RHFactor = "+",
                QuantityMl = 444
            };

            BloodStock bloodStock = null;

            var stockRepository = new Mock<IBloodStockRepository>();
            stockRepository
                .Setup(pr => pr.Update(It.IsAny<int>(), It.IsAny<BloodStock>()))
                .Callback<int, BloodStock>((id, stock) => bloodStock = stock)
                .Returns(Task.CompletedTask);

            var commandHandler = new UpdateBloodStockCommandHandler(stockRepository.Object);


            // ACT
            var act = await commandHandler.Handle(updateCommand, new CancellationToken());


            // ASSERT
            Assert.False(bloodStock.Id == 200);
            Assert.False(bloodStock.BloodType == "Gustavo Lima");
            Assert.False(bloodStock.RHFactor == "Programa Panico na Band");
            Assert.False(bloodStock.QuantityMl == 50000);
        }




    }
}
