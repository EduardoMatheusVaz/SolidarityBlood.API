using Azure.Core;
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

            // vai executar a procedure diretamente no banco de dados, vai atualizar o estoque e nao vai dar o erro do OUTPUT
            await _dbcontext.Database.ExecuteSqlRawAsync("EXEC UpdateBloodStock");

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

        public async Task<List<Donation>> GetDeletedDonations()
        {
            var list = await _dbcontext.Donation.ToListAsync();

            return list;
        }

        public async Task TimeLimitForDonation(int id)
        {

            // 1- buscar o donor no banco de dados
            // 2- buscar a ultima doação do doador
            // 3- chamar o método que criei dentro da entidade Donor, se pode ou nao fazer a doação
            // 4- caso o return seja false lançar uma exceção, o céu é o limite

            // 1- buscar o donor no banco de dados
            var donor = await _dbcontext.Donor.FirstOrDefaultAsync(d => d.Id == id);

            // 2- buscar a ultima doação do doador
            var lastDonation = _dbcontext.Donation.Where(d => d.DonorId == donor.Id).
                OrderByDescending(d => d.DateDonation).
                Select(d => d.DateDonation).
                FirstOrDefault();

        }

        public async Task Update(int id, Donation donation)
        {
            var newDonor = await _dbcontext.Donation.FirstOrDefaultAsync(d => d.Id == id);

            newDonor.Update(donation.DonorId, donation.DateDonation, donation.QuantityMl);
            
            await _dbcontext.SaveChangesAsync();
        }
    }
}
