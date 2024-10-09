using Microsoft.EntityFrameworkCore;
using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Infrastructure.Persistence
{
    public class SolidarityBloodDbContext : DbContext
    {
        public SolidarityBloodDbContext(DbContextOptions<SolidarityBloodDbContext> options) : base (options)
        {

        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
