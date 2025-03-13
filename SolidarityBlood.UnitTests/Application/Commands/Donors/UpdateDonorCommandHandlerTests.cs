using Moq;
using SolidarityBlood.Application.Commands.Donors;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crmf;

namespace SolidarityBlood.UnitTests.Application.Commands.Donors
{
    public class UpdateDonorCommandHandlerTests 
    {
        [Fact] // indica que a task a seguir se trata de um teste de unidade
        public async Task IfThere_IsDataToBe_UpdatedThenThe_MethodMustBeTriggered()
        {
            // ARRANGE: preparação do ambiente

            var command = new UpdateDonorCommand
                (
                "Miguel Diaz",
                "elserpiente@cobrakai.com",
                new DateTime(2002, 02, 02),
                "Masculino",
                67,
                "O",
                "+",
                3);

            command.Id = 1;


            // Vou precisar manter a variavel donor para conseguir passar o método Update no meu Mock, beleza?
            var donor = new Donor(
                "El Serpiente",
                "cobrakai@cobrakai.com",
                new DateTime(2002, 02, 02),
                "Masculino",
                80,
                "O",
                "+",
                2);

            var donorRepository = new Mock<IDonorRepository>();
            donorRepository
                .Setup(pr => pr.Update(1, donor))
                .Returns(Task.CompletedTask);

            var commandHandler = new UpdateDonorCommandHandler(donorRepository.Object);
            

            // ACT
            var act = await commandHandler.Handle(command, new CancellationToken());


            // ASSERT

            donorRepository.Verify(pr => pr.Update(
                It.Is<int>(id => id == 1),
                It.Is<Donor>(d =>
                d.FullName == "Miguel Diaz" &&
                d.Email == "elserpiente@cobrakai.com" &&
                d.DateBirth == new DateTime(2002, 02, 02) &&
                d.Weight == 67 &&
                d.BloodTypes == "O" &&
                d.RHFactor == "+" &&
                d.AddressId == 3
                )), Times.Once());

            // a LÓGIOCA do Verify acima
            // No primeiro It.Is, ele vai garantir que o primeiro argumento (no caso o Id) seja 1
            // No segundo It.Is, ele vai conferir se o segundo elemento tem as mesmas propriedades esperadas que a minha variavel COMMAND
            // quanto a linha acima, o command contém os dados necessários pra atualização, entao a verificação vai comparar estes dois valores
            // no objeto Donor, o teste em si VALIDA SE o Update está sendo chamado corretamente com os dados do COMMAND

        }




        [Fact] // indica que a task a seguir se trata de um teste de unidade
        public async Task IfData_HaveAMistake_ThenHaveBreak()
        {
            // ARRANGE: preparação do ambiente

            var command = new UpdateDonorCommand
                (
                "Miguel Diaz",
                "elserpiente@cobrakai.com",
                new DateTime(2002, 02, 02),
                "Masculino",
                67,
                "O",
                "+",
                3);

            command.Id = 1;


            // Vou precisar manter a variavel donor para conseguir passar o método Update no meu Mock, beleza?
            Donor donorUpdate = null;

            var donorRepository = new Mock<IDonorRepository>();
            donorRepository
                .Setup(pr => pr.Update(It.IsAny<int>(), It.IsAny<Donor>()))
                .Callback<int, Donor>((id, donor) => donorUpdate = donor) // diz que estamos esperando um método com dois parametros, um int e um DONOR
                .Returns(Task.CompletedTask);                             // quando o update for chamado, o segundo parametro será armazenado na variavel donorUpdate

            var commandHandler = new UpdateDonorCommandHandler(donorRepository.Object);


            // ACT
            var act = await commandHandler.Handle(command, new CancellationToken());


            // ASSERT
            Assert.False(donorUpdate.FullName == "GustavoLima");
            Assert.False(donorUpdate.RHFactor == "Sábado na balada");
            Assert.False(donorUpdate.DateBirth == new DateTime(2023, 02, 02));
            Assert.False(donorUpdate.AddressId == 111);
            Assert.False(donorUpdate.RHFactor == "SSSSSSSSSSSSSSSSSSSSS");
        }




    }
}
