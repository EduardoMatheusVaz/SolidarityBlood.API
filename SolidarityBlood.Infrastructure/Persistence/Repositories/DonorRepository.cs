﻿using Microsoft.EntityFrameworkCore;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly SolidarityBloodDbContext _dbcontext;

        public DonorRepository(SolidarityBloodDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> CreateDonor(Donor donor)
        {
            var newDonor = new Donor(donor.FullName, donor.Email, donor.DateBirth, donor.Gender, donor.Weight, donor.BloodTypes, donor.RHFactor, donor.AddressId);

            await _dbcontext.Donor.AddAsync(donor);
            await _dbcontext.SaveChangesAsync();

            return donor.Id;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Donor>> GetAllDonors()
        {
            var list = await _dbcontext.Donor.ToListAsync();

            return list;
        }

        public async Task<Donor> GetByIdDonor(int id)
        {
            var donor = await _dbcontext.Donor.FirstOrDefaultAsync(d => d.Id == id);

            return donor;
        }

        public async Task Update(int id, Donor donor)
        {
            var diskdonor = await _dbcontext.Donor.FirstOrDefaultAsync(d => d.Id == id);

            diskdonor.Update(donor.FullName, donor.Email, donor.DateBirth, donor.Gender, donor.Weight, donor.BloodTypes, donor.RHFactor, donor.AddressId);

            await _dbcontext.SaveChangesAsync();
        }
    }
}