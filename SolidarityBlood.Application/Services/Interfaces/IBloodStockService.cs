using SolidarityBlood.Application.DTOs.BloodStocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Services.Interfaces
{
    public interface IBloodStockService
    {
        int Create(CreateBloodStockDTO bloodStock);
        List<GetAllBloodStockDTO> GetAll();
        GetByIdBloodStockDTO GetById(int id);
        void Update(int id, UpdateBloodStockDTO bloodStock);
        void Delete(int id);
    }
}
