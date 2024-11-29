using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Core.Repositories
{
    public interface IAddressRepository
    {
        Task<int> CreateAddress(Address address);
        Task<List<Address>> GetAllAddress();
        Task <Address> GetByIdAddress(int id);
        Task<List<Address>> GetDeletedAddress();
        Task UpdateAddress(int id, Address address);
        Task Delete(int id, string reasonExclusion);
    }
}
