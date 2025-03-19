using Moq;
using SolidarityBlood.Application.Queries.BloodStock;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Queries.BloodStocks
{
    public class GetByIdBloodStockQueryHandlerTests
    {

        [Fact] // Indica que o método ou task a seguir vai se tratar de um teste unitário
        public async Task If_ThereIsA_BloodStockThenIt_MustBeReturned()
        {

            // ARRANGE
            BloodStock stock = new BloodStock("AB", "+", 700);

            var bloodStockRepository = new Mock<IBloodStockRepository>();
            bloodStockRepository.Setup(rep => rep.GeByIdBloodStock(It.IsAny<int>()).Result).Returns(stock);

            var command = new GetByIdBloodStockQuerie(1);
            var commandHandler = new GetByIdBloodStockQuerieHandler(bloodStockRepository.Object);

            // ACT => seria a ação em si
            var act = await commandHandler.Handle(command, new CancellationToken());

            // ASSERT => são as validações que queremos averiguar no teste
            bloodStockRepository.Verify(pre => pre.GeByIdBloodStock(It.IsAny<int>()), Times.Once());

        }


        [Fact] // Indica que o método ou task a seguir vai se tratar de um teste unitário
        public async Task If_ThereIs_AStockThen_HisDataShould_BeReturned()
        {

            // ARRANGE
            BloodStock stock = new BloodStock("AB", "+", 700);

            var bloodStockRepository = new Mock<IBloodStockRepository>();
            bloodStockRepository.Setup(rep => rep.GeByIdBloodStock(It.IsAny<int>()).Result).Returns(stock);

            var command = new GetByIdBloodStockQuerie(1);
            var commandHandler = new GetByIdBloodStockQuerieHandler(bloodStockRepository.Object);

            // ACT => seria a ação em si
            var act = await commandHandler.Handle(command, new CancellationToken());

            // ASSERT => são as validações que queremos averiguar no teste
            Assert.NotNull(act);
            Assert.Equal(stock.BloodType, act.BloodType);
            Assert.Equal(stock.RHFactor, act.RHFactor);
            Assert.Equal(stock.QuantityMl, act.QuantityMl);
        }


        [Fact] // Indica que o método ou task a seguir vai se tratar de um teste unitário
        public async Task If_TheDataIsWrong_ThenItShouldBe_ReturnFalse()
        {

            // ARRANGE
            BloodStock stock = new BloodStock("AB", "+", 700);

            var bloodStockRepository = new Mock<IBloodStockRepository>();
            bloodStockRepository.Setup(rep => rep.GeByIdBloodStock(It.IsAny<int>()).Result).Returns(stock);

            var command = new GetByIdBloodStockQuerie(1);
            var commandHandler = new GetByIdBloodStockQuerieHandler(bloodStockRepository.Object);

            // ACT => seria a ação em si
            var act = await commandHandler.Handle(command, new CancellationToken());

            // ASSERT => são as validações que queremos averiguar no teste
            Assert.NotNull(act);
            Assert.False(stock.BloodType == "Tenis");
            Assert.False(stock.RHFactor == "ZekiGou");
            Assert.False(stock.QuantityMl == 100000);
        }

    }
}
