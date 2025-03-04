using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Core.Repositories
{
    public interface IDonationRepository 
    {
        Task<int> CreateDonation(Donation donation);
        Task<List<Donation>> GetAllDonations();
        Task<Donation> GetById(int id);
        Task<List<Donation>> GetDeletedDonations();
        Task Update(int id, Donation donation);
        Task Delete(int id, string canceled);
        Task TimeLimitForDonation(int id);
    }
}
