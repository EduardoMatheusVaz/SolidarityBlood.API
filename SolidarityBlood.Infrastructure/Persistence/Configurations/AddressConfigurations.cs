using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Infrastructure.Persistence.Configurations
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
            .ToTable("tb_Address")
            .HasKey(a => a.Id);

            builder
                .HasMany(d => d.Donors)
                .WithOne(a => a.Address)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
