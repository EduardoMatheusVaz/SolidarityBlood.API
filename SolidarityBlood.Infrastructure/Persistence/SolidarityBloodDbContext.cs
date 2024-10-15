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
        public SolidarityBloodDbContext(DbContextOptions<SolidarityBloodDbContext> options) : base(options)
        {

        }

        public DbSet<Donor> Donor { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<BloodStock> BloodStock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelBuilder modelBuilder1 = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
 
        }
    }
}
