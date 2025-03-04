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
    public class GetAllBloodStockQuerieHandlerTests
    {

        [Fact] // Indica que o método abaixo é um caso de teste unitario

        public async Task IfThereAreStocks_TheyMustBeReturned()
        {

            // Padrão utilizado: AAA

            // Arrange: etapa de preparação do ambiente para execução dos testes

            var listStocks = new List<BloodStock>
            {
                new BloodStock("O", "-", 470),
                new BloodStock("AB", "+", 460),
                new BloodStock("O", "=", 455)
            };

            var stockRepository = new Mock<IBloodStockRepository>();
            stockRepository.Setup(pr => pr.GetAllBloodStocks().Result).Returns(listStocks); // o setup vai definir um comportamento para o Mock, no caso um comportamento que devemos esperar dele
            // o pr vai simular o método assicrono de get all
            // o Result vai obter o resultado retornado pelo meu método
            // e o Returns vai definir que, ao chamar o método anterior com o result, o mock vai retornar a lista que eu criei ali em cima

            var querie = new GetAllBloodStocksQuerie();
            var querieHandler = new GetAllBloodStocksQuerieHandler(stockRepository.Object);

            // ACT, ação a ser executada, no caso, a faze em que vamos atuar

            // aqui vou instanciar o handler que vai fazer a consulta, afinal o handler é minha ação
            // em seguida eu chamo o método handle passando a minha querie com os parametros da consulta (que eu defini logo acima)
            // e isso foi opcional meu, coloquei um cancelation token apenas para cancelar a operação assincrona
            var result = await querieHandler.Handle(querie, new CancellationToken());


            // ASSERT: aqui é a faze onde eu vou aplicar as minhas validações dessa joça, morou?

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            Assert.Equal(listStocks.Count, result.Count);
        }


    }
}
