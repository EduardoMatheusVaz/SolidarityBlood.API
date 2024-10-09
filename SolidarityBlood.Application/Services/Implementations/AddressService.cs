using Microsoft.EntityFrameworkCore;
using SolidarityBlood.Application.DTOs.Addresses;
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
    public class AddressService : IAddressService
    {
        private readonly SolidarityBloodDbContext _dbcontext;

        public AddressService(SolidarityBloodDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int Create(CreateAddressDTO address)
        {
            var newAddress = new Address(address.PublicPlace, address.City, address.State, address.ZipCode);

            _dbcontext.Addresses.Add(newAddress);
            _dbcontext.SaveChanges();

            return newAddress.Id;
        }

        public void Delete(int id)
        {
            var address = _dbcontext.Addresses.FirstOrDefault(a => a.Id == id);

            _dbcontext.Addresses.Remove(address);
            _dbcontext.SaveChanges();
        }

        public List<GetAllAddressDTO> GetAll()
        {
            var addresses = _dbcontext.Addresses.Select(a => new GetAllAddressDTO(
                a.Id,
                a.PublicPlace,
                a.City,
                a.State,
                a.ZipCode
                )).ToList();

            return addresses;
        }

        public GetByIdAddressDTO GetById(int id)
        {
            var address = _dbcontext.Addresses.FirstOrDefault(a => a.Id == id);

            var newAddress = new GetByIdAddressDTO(address.Id, address.PublicPlace, address.City, address.State, address.ZipCode);

            return newAddress;
        }

        public void Update(int id, UpdateAddressDTO address)
        {
            var addressss = _dbcontext.Addresses.FirstOrDefault(a => a.Id == id);

            addressss.Update(address.PublicPlace, address.City, address.State, address.ZipCode);
            _dbcontext.SaveChanges();
        }
    }
}
