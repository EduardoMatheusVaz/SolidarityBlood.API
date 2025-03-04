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
    public  class GetAllAddressesQueryHandlerTests
    {

        
        [Fact] // tudo o que eu digitar após ele será testado
        public async Task IfThereAre_Addreses_TheyMustBeReturned()
        {

            // Arrange : é a etapa de preparação dos testes, configurando e criando os objetos necessários
            var listAddresses = new List<Address>
            {
                new Address("Rua Senador Pinherio", "apto 501", "Vila Rodrigues", "Passo Fundo", "RS", "99070-220"),
                new Address("Avenida Borge de Medeiros", "2697", "Centro", "Gramado", "RS", "99070-220"),
                new Address("Rua Senador Pompeu", "2508", "Benfica", "Fortaleza", "CE", "99070-220")
            };


            var addressRepositoryMock = new Mock<IAddressRepository>();   // Mock do repositório, serve para simular a interface do repositório, mas é só um objeto Moq
            addressRepositoryMock.Setup(ar => ar.GetAllAddress().Result).Returns(listAddresses);

            var getAll = new GetAllAddressQuerie();
            var getAllHandler = new GetAllAddressQuerieHandler(addressRepositoryMock.Object);


            // Act : Executa a ação a ser testada, aqui chama o método do Handle no handler(getAllHandler) passando a query(getAll)
            var result = await getAllHandler.Handle(getAll, new CancellationToken());


            // Assert : compara o resultado obtido com o resultado esperado, no caso verifica os resultados do teste
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(listAddresses.Count, result.Count);



        }

    }
}
