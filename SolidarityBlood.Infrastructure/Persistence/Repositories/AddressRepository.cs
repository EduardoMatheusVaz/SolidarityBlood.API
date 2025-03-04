using Azure.Core;
using Microsoft.EntityFrameworkCore;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using SolidarityBlood.Infrastructure.Integration.Interfaces;
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
        private readonly IViaCepIntegration _viaCepIntegration;

        public AddressRepository(SolidarityBloodDbContext dbcontext, IViaCepIntegration viaCepIntegration)
        {
            _dbcontext = dbcontext;
            _viaCepIntegration = viaCepIntegration;
        }

        public async Task<Address> AddresQuery(string zipcode)
        {
            var responseViaCep = await _viaCepIntegration.GetDataViaCep(zipcode);
            var address = new Address(responseViaCep.Logradouro, responseViaCep.Complemento, responseViaCep.Bairro, responseViaCep.Localidade, responseViaCep.Uf, responseViaCep.Cep);

            return address;

        }

        public async Task<int> CreateAddress(Address address)
        {
            var newAddress = new Address(address.PublicPlace, address.Complement, address.Neighborhood,address.City, address.State, address.ZipCode);

            await _dbcontext.Address.AddAsync(newAddress);
            await _dbcontext.SaveChangesAsync();

            return newAddress.Id;
        }

        public async Task Delete(int id, string reasonExclusion)
        {
            var address = await _dbcontext.Address.FirstOrDefaultAsync(a => a.Id == id);

            address.Deleted(reasonExclusion);

            await _dbcontext.SaveChangesAsync();
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

        public async Task<List<Address>> GetDeletedAddress()
        {
            var addresses = await _dbcontext.Address.ToListAsync();

            return addresses;
        }

        public async Task UpdateAddress(int id, Address address)
        {
            var addressss = await _dbcontext.Address.FirstOrDefaultAsync(a => a.Id == id);

            addressss.Update(address.PublicPlace, address.City, address.State, address.ZipCode);
            
            await _dbcontext.SaveChangesAsync();
        }
    }
}
