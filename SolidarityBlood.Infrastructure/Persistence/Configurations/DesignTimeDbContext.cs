using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Infrastructure.Persistence.Configurations
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<SolidarityBloodDbContext>
    {
        public SolidarityBloodDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SolidarityBloodDbContext>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-BPQKIBEO\\SQLSERVER2022;Database=DB_SolidarityBlood;User Id=sa;Password=Mortadela1!;TrustServerCertificate=True");

            return new SolidarityBloodDbContext(optionsBuilder.Options);
        }
    }
}
