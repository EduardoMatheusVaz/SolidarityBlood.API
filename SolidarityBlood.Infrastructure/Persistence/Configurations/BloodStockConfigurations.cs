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
    public class BloodStockConfigurations : IEntityTypeConfiguration<BloodStock>
    {
        public void Configure(EntityTypeBuilder<BloodStock> builder)
        {
            builder
                .ToTable("tb_BloodStock")
                .HasKey(x => x.Id);
        }
    }
}
