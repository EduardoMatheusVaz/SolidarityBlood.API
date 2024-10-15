using Microsoft.EntityFrameworkCore;
using SolidarityBlood.Application.DTOs.Donors;
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
    public class DonorService : IDonorService
    {
        private readonly SolidarityBloodDbContext _dbcontext;

        public DonorService(SolidarityBloodDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int Create(CreateDonorDTO donor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var donor = _dbcontext.Donor.SingleOrDefault(d => d.Id == id);

            _dbcontext.Donor.Remove(donor);
            _dbcontext.SaveChanges();
        }

        public List<GetAllDonorsDTO> GetAllDonors()
        {
            throw new NotImplementedException();
        }

        public GetByIdDonorDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, UpdateDonorDTO donor)
        {
            throw new NotImplementedException();
        }
    }
}
