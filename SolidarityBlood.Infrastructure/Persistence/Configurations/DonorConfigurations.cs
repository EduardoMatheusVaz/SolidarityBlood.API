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
    internal class DonorConfigurations : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder
            .ToTable("tb_Donor")
            .HasKey(d => d.Id);

            builder
                .HasOne(a => a.Address)
                .WithMany(d => d.Donors)
                .HasForeignKey(a => a.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(d => d.Donation)
                .WithOne(d => d.Donor)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
