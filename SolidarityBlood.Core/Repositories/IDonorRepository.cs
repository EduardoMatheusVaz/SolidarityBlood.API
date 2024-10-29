using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Core.Repositories
{
    public interface IDonorRepository
    {
        Task<int> CreateDonor(Donor donor);
        Task<List<Donor>> GetAllDonors();
        Task<Donor> GetByIdDonor(int id);
        Task Update(int id, Donor donor);
        Task Delete(int id, string reasonExclusion);
    }
}
