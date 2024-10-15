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
    public class DonationConfigurations : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder
                .ToTable("tb_Donation")
                .HasKey(a => a.Id);

            builder
                .HasOne(d => d.Donor)
                .WithMany(d => d.Donation)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
