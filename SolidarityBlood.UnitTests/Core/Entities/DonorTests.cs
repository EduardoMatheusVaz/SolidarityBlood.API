using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.UnitTests.Core.Entities
{
    public class DonorTests
    {

        [Fact] // é uma anotação que indica que esse método deverá ser executado pelo TestRunner
        public void TestIfDonorActiveWorks()
        {
            var date = new DateTime(2000, 07, 03, 22, 59, 59);

            var donor = new Donor("Peniano", "peniano@gmail.com", date, "Masculino", 78, "AB", "-", 3 );

            Assert.NotNull(donor.FullName);
            Assert.NotNull(donor.Email);
            Assert.NotNull(donor.DateBirth);
            Assert.NotNull(donor.Gender);
            Assert.NotNull(donor.Weight);
            Assert.NotNull(donor.BloodTypes);
            Assert.NotNull(donor.RHFactor);
            Assert.NotNull(donor.AddressId);

            // O ASSERT é uma Verificação
            // O primeiro parâmetro é o valor esperado, e o segundo é o valor que estou comparando
            Assert.Equal(DonorStatusEnum.Active, donor.Status);

            
        }

    }
}
