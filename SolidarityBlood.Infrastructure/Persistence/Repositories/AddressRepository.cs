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
    public class AddressRepository : IAddressRepository
    {
        private readonly SolidarityBloodDbContext _dbcontext;

        public AddressRepository(SolidarityBloodDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> CreateAddress(Address address)
        {
            var newAddress = new Address(address.PublicPlace, address.City, address.State, address.ZipCode);

            await _dbcontext.Address.AddAsync(newAddress);
            await _dbcontext.SaveChangesAsync();

            return newAddress.Id;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Address>> GetAllAddress()
        {
            var addresses = await _dbcontext.Address.ToListAsync();

            return addresses;
        }

        public async Task<Address> GetByIdAddress(int id)
        {
            var address = await _dbcontext.Address.FirstOrDefaultAsync(a => a.Id == id);

            return address;
        }

        public async Task UpdateAddress(int id, Address address)
        {
            var addressss = await _dbcontext.Address.FirstOrDefaultAsync(a => a.Id == id);

            addressss.Update(address.PublicPlace, address.City, address.State, address.ZipCode);
            
            await _dbcontext.SaveChangesAsync();
        }
    }
}
