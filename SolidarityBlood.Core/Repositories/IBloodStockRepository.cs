using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Core.Repositories
{
    public interface IBloodStockRepository
    {
        Task<int> CreateBloodStock(BloodStock bloodStock);
        Task<List<BloodStock>> GetAllBloodStocks();
        Task<BloodStock> GeByIdBloodStock(int id);
        Task Update(int id, BloodStock bloodStock);
        Task Delete(int id);
    }
}
