using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly SolidarityBloodDbContext _dbcontext;

        public BloodStockRepository(SolidarityBloodDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> CreateBloodStock(BloodStock bloodStock)
        {
            var bl = new BloodStock(bloodStock.BloodType, bloodStock.RHFactor, bloodStock.QuantityMl);

            await _dbcontext.BloodStock.AddAsync(bl);
            await _dbcontext.SaveChangesAsync();

            return bl.Id;
        }

        public async Task Delete(int id, string reasonUnavailable)
        {
            var stock = await _dbcontext.BloodStock.FirstOrDefaultAsync();

            stock.Unavailable(reasonUnavailable);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<BloodStock> GeByIdBloodStock(int id)
        {
            var stock = await _dbcontext.BloodStock.FirstOrDefaultAsync(bs => bs.Id == id);

            return stock;
        }

        public async Task<List<BloodStock>> GetAllBloodStocks()
        {
            var bloodStock = await _dbcontext.BloodStock.ToListAsync();

            return bloodStock;
        }

        public async Task<int> GetTotalBlood()
        {
            // ACREDITO QUE AINDA PODEMOS MELHORAR E UTILIZAR O DAPPER PARA ESCREVER UMA QUERY ONDE
            // CONSIGAMOS RETORNAR O TOTAL DE SANGUE PARA UM DETERMINADO TIPO, ACHO MAIS VÁLIDO ASSIM...

            var totalBlood = await _dbcontext.Donation.Select(q => q.QuantityMl).ToListAsync();

            return totalBlood.Sum();
        }

        public async Task Update(int id, BloodStock bloodStock)
        {
            var stock = await _dbcontext.BloodStock.FirstOrDefaultAsync(bs => bs.Id == id);

            stock.Update(bloodStock.BloodType, bloodStock.RHFactor, bloodStock.QuantityMl);

            await _dbcontext.SaveChangesAsync();
        }


    }
}
