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
            var newDonor = new Donor(donor.FullName, donor.Email, donor.DateBirth, donor.Gender, donor.Weight, donor.BloodTypes, donor.RHFactor);

            _dbcontext.Donors.Add(newDonor);
            _dbcontext.SaveChanges();

            return newDonor.Id;
        }

        public void Delete(int id)
        {
            var donor = _dbcontext.Donors.SingleOrDefault(d => d.Id == id);

            _dbcontext.Donors.Remove(donor);
            _dbcontext.SaveChanges();
        }

        public List<GetAllDonorsDTO> GetAllDonors()
        {
            var list = _dbcontext.Donors.Select(gad => new GetAllDonorsDTO(
                gad.Id,
                gad.FullName,
                gad.Email,
                gad.DateBirth,
                gad.Gender,
                gad.Weight,
                gad.BloodTypes,
                gad.RHFactor
                )).ToList();


            return list;
        }

        public GetByIdDonorDTO GetById(int id)
        {
            var donor = _dbcontext.Donors.SingleOrDefault(d => d.Id == id);

            var donorrr = new GetByIdDonorDTO(donor.Id, donor.FullName, donor.Email, donor.DateBirth, donor.Gender, donor.Weight, donor.BloodTypes, donor.RHFactor);
        
            return donorrr;
        }

        public void Update(int id, UpdateDonorDTO donor)
        {
            var diskdonor = _dbcontext.Donors.SingleOrDefault(d => d.Id == id);

            diskdonor.Update(donor.FullName, donor.Email, donor.DateBirth, donor.Gender, donor.Weight, donor.BloodTypes, donor.RHFactor);
            
            _dbcontext.SaveChanges();
        }
    }
}
