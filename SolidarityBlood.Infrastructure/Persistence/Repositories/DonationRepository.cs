using Microsoft.EntityFrameworkCore;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly SolidarityBloodDbContext _dbcontext;

        public DonationRepository(SolidarityBloodDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> CreateDonation(Donation donation)
        {
            var newDonation = new Donation(donation.DonorId, donation.DateDonation, donation.QuantityMl);

            await _dbcontext.Donation.AddAsync(newDonation);
            await _dbcontext.SaveChangesAsync();

            return newDonation.Id;
        }

        public async Task Delete(int id, string canceled)
        {
            var donation = await _dbcontext.Donation.FirstOrDefaultAsync(d => d.Id == id);

            donation.Canceled(canceled);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Donation>> GetAllDonations()
        {
            var list = await _dbcontext.Donation.ToListAsync();

            return list;
        }

        public async Task<Donation> GetById(int id)
        {
            var donation = await _dbcontext.Donation.FirstOrDefaultAsync(d => d.Id == id);

            return donation;
        }

        public async Task Update(int id, Donation donation)
        {
            var newDonor = await _dbcontext.Donation.FirstOrDefaultAsync(d => d.Id == id);

            newDonor.Update(donation.DonorId, donation.DateDonation, donation.QuantityMl);
            
            await _dbcontext.SaveChangesAsync();
        }
    }
}
