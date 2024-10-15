    using Microsoft.EntityFrameworkCore;
using SolidarityBlood.Application.DTOs.BloodStocks;
using SolidarityBlood.Application.Services.Interfaces;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Services.Implementations
{
    public class BloodStockService : IBloodStockService
    {
        private readonly SolidarityBloodDbContext _dbcontext;

        public BloodStockService(SolidarityBloodDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int Create(CreateBloodStockDTO bloodStock)
        {
            var bl = new BloodStock(bloodStock.BloodType, bloodStock.RHFactor, bloodStock.QuantityMl);

            _dbcontext.BloodStock.Add(bl);
            _dbcontext.SaveChanges();

            return bl.Id;
        }

        public void Delete(int id)
        {
            var stock = _dbcontext.BloodStock.SingleOrDefault(d => d.Id == id);

            _dbcontext.BloodStock.Remove(stock);
            _dbcontext.SaveChanges();
        }

        public List<GetAllBloodStockDTO> GetAll()
        {
            var bloodStock = _dbcontext.BloodStock.Select(bl => new GetAllBloodStockDTO(
                bl.Id,
                bl.BloodType,
                bl.RHFactor,
                bl.QuantityMl
                )).ToList();

            return bloodStock;
        }

        public GetByIdBloodStockDTO GetById(int id)
        {
            var stock = _dbcontext.BloodStock.SingleOrDefault(bs => bs.Id == id);

            var newStock = new GetByIdBloodStockDTO(stock.Id, stock.BloodType, stock.RHFactor, stock.QuantityMl);

            return newStock;
        }

        public void Update(int id, UpdateBloodStockDTO bloodStock)
        {
            var stock = _dbcontext.BloodStock.SingleOrDefault(bs => bs.Id == id);

            stock.Update(bloodStock.BloodType, bloodStock.RHFactor, bloodStock.QuantityMl);
        
            _dbcontext.SaveChanges(true);
        }
    }
}
