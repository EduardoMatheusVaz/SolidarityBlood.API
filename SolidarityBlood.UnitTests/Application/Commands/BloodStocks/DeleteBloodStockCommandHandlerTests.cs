using Moq;
using SolidarityBlood.Application.Commands.BloodStocks;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Application.Commands.BloodStocks
{
    public class DeleteBloodStockCommandHandlerTests
    {

        [Fact]
        public async Task If_EverythingIsOkay_WithStock_ThenTheMethod_ShouldBeCalled()
        {
            // ARRANGE
            var stockRepository = new Mock<IBloodStockRepository>();
            stockRepository.Setup(rep => rep.Delete(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.CompletedTask);


            var command = new DeleteBloodStockCommand(1, "ja falei que é porque sim cara");
            var commandHandler = new DeleteBloodStockCommandHandler(stockRepository.Object);

            
            // ACT
            var delete = await commandHandler.Handle(command, new CancellationToken());


            // ASSERT
            stockRepository.Verify(rep => rep.Delete(It.IsAny<int>(), It.IsAny<string>()), Times.Once());
        }


    }
}
